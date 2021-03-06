﻿namespace BuFaKAPI.Models.SubModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Model for the Status-Change Endpoint
    /// </summary>
    public class ChangeCAStatus
    {
        /// <summary>
        /// Gets or sets the UID of the User to change the status from
        /// </summary>
        public string UID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the Conference in Question
        /// </summary>
        public int ConferenceID { get; set; }

        /// <summary>
        /// Gets or sets the Status of the Conference Application
        /// 0: HasApplied
        /// 1: IsRejected
        /// 2: IsAttendee
        /// </summary>
        [EnumDataType(typeof(CAStatus))]
        public CAStatus NewStatus { get; set; }
    }
}
