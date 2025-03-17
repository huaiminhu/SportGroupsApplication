using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Club
    {
        [Key]
        public int ClubId { get; set; }
        public required string Name { get; set; }
        public required Sport Sport { get; set; }


    }
}
