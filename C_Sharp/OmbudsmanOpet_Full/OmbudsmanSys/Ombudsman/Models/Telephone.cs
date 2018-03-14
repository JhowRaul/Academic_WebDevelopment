using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ombudsman.Models
{
    public class Telephone
    {
        public long TelephoneId { get; set; }
        [Required(ErrorMessage = "Enter the phone DDI")]
        public int DDI { get; set; }
        [Required(ErrorMessage = "Enter the phone DDD")]
        public int DDD { get; set; }
        [Required(ErrorMessage = "Enter phone number")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Enter the phone's type")]
        public string Type { get; set; }
        
        public virtual ICollection<Protester> Protesters { get; set; }
    }
}