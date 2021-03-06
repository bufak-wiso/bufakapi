﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BuFaKAPI.Models;
using BuFaKAPI.Services;
using Microsoft.Extensions.Options;
using BuFaKAPI.Models.SubModels;
using WebApplication1.Models;

namespace BuFaKAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotingAnswersController : ControllerBase
    {
        private readonly MyContext _context;
        private readonly AuthService auth;
        private readonly TelegramBot telBot;
        private readonly TokenService jwtService;

        public VotingAnswersController(MyContext context, IOptions<AppSettings> settings)
        {
            this._context = context;
            this.auth = new AuthService(this._context);
            this.telBot = new TelegramBot();
            this.jwtService = new TokenService(this._context, settings);
        }

        // GET: api/VotingAnswers/5
        [HttpGet("byQuestion/{id}")]
        public async Task<IActionResult> GetVotingAnswer(
            [FromHeader(Name = "conference_id")] int conference_id,
            [FromHeader(Name = "jwttoken")] string jwttoken,
            [FromRoute] int id,
            [FromQuery] string apikey)
        {
            if (this.jwtService.PermissionLevelValid(jwttoken, "superadmin") && this.auth.KeyIsValid(apikey))
            {
                return this.Ok(this._context.VotingAnswer.Where(x => x.QuestionID == id).ToList());
            }

            return this.Unauthorized();
        }

        // POST: api/VotingAnswers
        [HttpPost]
        public async Task<IActionResult> PostVote(
            [FromHeader(Name = "conference_id")] int conference_id,
            [FromHeader(Name = "jwttoken")] string jwttoken,
            [FromQuery] string apikey,
            [FromBody] VoteObject voteObject)
        {
            if (!this.jwtService.PermissionLevelValid(jwttoken, "user") || !this.auth.KeyIsValid(apikey))
            {
                return this.Unauthorized();
            }

            Conference_Application application = await this._context.Conference_Application.FindAsync(conference_id, this.jwtService.GetUIDfromJwtKey(jwttoken));
            if (application == null || application.Status != Conference_ApplicationController.StatusToString(CAStatus.IsAttendee))
            {
                return this.Unauthorized(); // user is not attending the conference
            }

            VotingQuestion question = await this._context.VotingQuestion.FindAsync(voteObject.QuestionID);
            if (!this.ModelState.IsValid || question == null || !question.IsOpen || question.ResolvedOn != null)
            {
                return this.BadRequest(this.ModelState); // modelState not valid, question does not exist or is not open for voting
            }

            if (question.IsSecret && (application.Priority != 1 || application.IsAlumnus || application.IsBuFaKCouncil || application.IsHelper))
            {
                return this.BadRequest("Only user with priority 1 are allowed to vote");
            }

            int councilID = this.jwtService.GetCouncilfromJwtKey(jwttoken);
            VotingAnswer currentAnswer = this._context.VotingAnswer.Where(x => x.CouncilID == councilID && x.QuestionID == voteObject.QuestionID).FirstOrDefault();

            if (currentAnswer == null)
            {
                VotingAnswer votingAnswer = new VotingAnswer() // create new votingAnswer
                {
                    CouncilID = councilID,
                    Priority = application.Priority,
                    QuestionID = voteObject.QuestionID,
                    Vote = question.IsSecret ? string.Empty : voteObject.Vote,
                };
                this._context.VotingAnswer.Add(votingAnswer);

                if (question.IsSecret)
                {
                    // add the vote to the secret question
                    VotingQuestionsController.AddVoteToQuestion(question, VotingQuestionsController.GetVoteType(voteObject.Vote));
                    this._context.Update(question);
                }

                await this._context.SaveChangesAsync();
                return this.CreatedAtAction("PostVote", new { id = votingAnswer.AnswerID }, votingAnswer);
            }

            if (currentAnswer.Priority < application.Priority || question.IsSecret)
            {
                return this.Conflict(); // there is already a vote from that council (with a higher priority or its a secret question)
            }

            currentAnswer.Vote = voteObject.Vote; // update the current Answer to the new vote
            currentAnswer.Priority = application.Priority;
            this._context.Update(currentAnswer);
            await this._context.SaveChangesAsync();
            return this.CreatedAtAction("PostVote", new { id = currentAnswer.AnswerID }, currentAnswer);
        }
    }
}