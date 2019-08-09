﻿// <auto-generated />
using BuFaKAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BuFaKAPI.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20190723105601_addedApplicationAuth")]
    partial class addedApplicationAuth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BuFaKAPI.Models.Administrator", b =>
                {
                    b.Property<string>("UID");

                    b.Property<int>("ConferenceID");

                    b.Property<string>("ValidUntil");

                    b.HasKey("UID", "ConferenceID");

                    b.HasIndex("ConferenceID");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("BuFaKAPI.Models.ApplicationAuth", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Conference_ID");

                    b.Property<int>("Council_ID");

                    b.Property<string>("Password");

                    b.Property<int>("Priority");

                    b.HasKey("ID");

                    b.ToTable("ApplicationAuth");
                });

            modelBuilder.Entity("BuFaKAPI.Models.History", b =>
                {
                    b.Property<int>("HistoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HistoryType");

                    b.Property<string>("OldValue");

                    b.Property<string>("ResponsibleUID");

                    b.Property<string>("UserUID");

                    b.HasKey("HistoryID");

                    b.HasIndex("UserUID");

                    b.ToTable("History");
                });

            modelBuilder.Entity("BuFaKAPI.Models.Newsletter", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Sex");

                    b.Property<string>("Studyplace");

                    b.Property<string>("Surname");

                    b.HasKey("ID");

                    b.ToTable("Newsletter");
                });

            modelBuilder.Entity("BuFaKAPI.Models.Sensible", b =>
                {
                    b.Property<int>("SensibleID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BuFaKCount");

                    b.Property<int>("ConferenceID");

                    b.Property<string>("EatingPreferences");

                    b.Property<string>("ExtraNote");

                    b.Property<string>("Intolerances");

                    b.Property<bool>("Invalid");

                    b.Property<string>("SleepingPreferences");

                    b.Property<string>("Telephone");

                    b.Property<string>("Timestamp");

                    b.Property<string>("UID");

                    b.HasKey("SensibleID");

                    b.ToTable("Sensible");
                });

            modelBuilder.Entity("WebApplication1.Models.Auth", b =>
                {
                    b.Property<int>("TokenID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApiKey");

                    b.Property<int>("ConferenceID");

                    b.Property<string>("CreatedOn");

                    b.Property<string>("Note");

                    b.Property<string>("ValidUntil");

                    b.HasKey("TokenID");

                    b.ToTable("Auth");
                });

            modelBuilder.Entity("WebApplication1.Models.Conference", b =>
                {
                    b.Property<int>("ConferenceID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlumnusCost");

                    b.Property<string>("AttendeeCost");

                    b.Property<bool>("ConferenceApplicationPhase");

                    b.Property<int>("CouncilID");

                    b.Property<string>("DateEnd");

                    b.Property<string>("DateStart");

                    b.Property<bool>("Invalid");

                    b.Property<string>("Name");

                    b.Property<bool>("WorkshopApplicationPhase");

                    b.Property<bool>("WorkshopSuggestionPhase");

                    b.HasKey("ConferenceID");

                    b.ToTable("Conference");
                });

            modelBuilder.Entity("WebApplication1.Models.Conference_Application", b =>
                {
                    b.Property<int>("ConferenceID");

                    b.Property<string>("ApplicantUID");

                    b.Property<string>("Hotel");

                    b.Property<bool>("Invalid");

                    b.Property<bool>("IsAlumnus");

                    b.Property<bool>("IsBuFaKCouncil");

                    b.Property<bool>("IsHelper");

                    b.Property<string>("Note");

                    b.Property<int>("Priority");

                    b.Property<string>("Room");

                    b.Property<int>("SensibleID");

                    b.Property<string>("Status");

                    b.Property<string>("Timestamp");

                    b.Property<string>("UserUID");

                    b.HasKey("ConferenceID", "ApplicantUID");

                    b.HasIndex("SensibleID");

                    b.HasIndex("UserUID");

                    b.ToTable("Conference_Application");
                });

            modelBuilder.Entity("WebApplication1.Models.Council", b =>
                {
                    b.Property<int>("CouncilID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("ContactEmail");

                    b.Property<bool>("Invalid");

                    b.Property<string>("Name");

                    b.Property<string>("NameShort");

                    b.Property<string>("State");

                    b.Property<string>("University");

                    b.Property<string>("UniversityShort");

                    b.HasKey("CouncilID");

                    b.ToTable("Council");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.Property<string>("UID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Birthday");

                    b.Property<int>("CouncilID");

                    b.Property<string>("Email");

                    b.Property<bool>("Invalid");

                    b.Property<bool>("IsSuperAdmin");

                    b.Property<string>("Name");

                    b.Property<string>("Note");

                    b.Property<string>("Sex");

                    b.Property<string>("Surname");

                    b.HasKey("UID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebApplication1.Models.Workshop", b =>
                {
                    b.Property<int>("WorkshopID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConferenceID");

                    b.Property<string>("Difficulty");

                    b.Property<int>("Duration");

                    b.Property<string>("HostName");

                    b.Property<string>("HostUID");

                    b.Property<bool>("Invalid");

                    b.Property<string>("MaterialNote");

                    b.Property<int>("MaxVisitors");

                    b.Property<string>("Name");

                    b.Property<string>("NameShort");

                    b.Property<string>("Overview");

                    b.Property<string>("Place");

                    b.Property<string>("Start");

                    b.Property<string>("UserUID");

                    b.HasKey("WorkshopID");

                    b.HasIndex("ConferenceID");

                    b.HasIndex("UserUID");

                    b.ToTable("Workshop");
                });

            modelBuilder.Entity("WebApplication1.Models.Workshop_Application", b =>
                {
                    b.Property<int>("WorkshopID");

                    b.Property<string>("ApplicantUID");

                    b.Property<bool>("Invalid");

                    b.Property<bool>("IsHelper");

                    b.Property<int>("Priority");

                    b.Property<string>("Status");

                    b.Property<string>("UserUID");

                    b.HasKey("WorkshopID", "ApplicantUID");

                    b.HasIndex("UserUID");

                    b.ToTable("Workshop_Application");
                });

            modelBuilder.Entity("BuFaKAPI.Models.Administrator", b =>
                {
                    b.HasOne("WebApplication1.Models.Conference", "Conference")
                        .WithMany()
                        .HasForeignKey("ConferenceID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BuFaKAPI.Models.History", b =>
                {
                    b.HasOne("WebApplication1.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserUID");
                });

            modelBuilder.Entity("WebApplication1.Models.Conference_Application", b =>
                {
                    b.HasOne("WebApplication1.Models.Conference", "Conference")
                        .WithMany()
                        .HasForeignKey("ConferenceID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BuFaKAPI.Models.Sensible", "Sensible")
                        .WithMany()
                        .HasForeignKey("SensibleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserUID");
                });

            modelBuilder.Entity("WebApplication1.Models.Workshop", b =>
                {
                    b.HasOne("WebApplication1.Models.Conference", "Conference")
                        .WithMany()
                        .HasForeignKey("ConferenceID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserUID");
                });

            modelBuilder.Entity("WebApplication1.Models.Workshop_Application", b =>
                {
                    b.HasOne("WebApplication1.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserUID");

                    b.HasOne("WebApplication1.Models.Workshop", "Workshop")
                        .WithMany()
                        .HasForeignKey("WorkshopID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
