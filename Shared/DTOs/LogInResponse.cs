using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportGroups.Shared.DTOs
{
    public class LogInResponse
    {
        public string? Token {  get; set; }
        public string? Username { get; set; }
    }
}
