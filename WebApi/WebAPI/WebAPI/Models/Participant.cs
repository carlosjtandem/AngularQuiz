using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Participant
    {
        [Key]
        public int ParticipantID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Nullable<int> Score { get; set; }
        public Nullable<int> TimeSpent { get; set; }

    }
}
