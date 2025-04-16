﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.DTOs.EnrollmentDTOs
{
    public class EnrollmentDto
    {
        public int UserId { get; set; }
        public int ClubEventId { get; set; }
        public string Phone { get; set; } = string.Empty;
        public DateTime EnrollDate { get; set; }
    }
}
