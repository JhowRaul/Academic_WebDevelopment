using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ombudsman.Models
{
    public class Email
    {
        public long EmailId { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Enter email")]
        public string EmailDescription { get; set; }

        public long? ProtesterId { get; set; }
        public long? UserId { get; set; }

        public Protester Protester { get; set; }
        public User User { get; set; }
    }
}