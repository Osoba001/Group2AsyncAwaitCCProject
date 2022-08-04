﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSANoteApp.Domain.DTOs
{
    public class FetchUserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public List<FetchNoteDto> UserNotes { get; set; }
    }
}
