using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        
    }
}
