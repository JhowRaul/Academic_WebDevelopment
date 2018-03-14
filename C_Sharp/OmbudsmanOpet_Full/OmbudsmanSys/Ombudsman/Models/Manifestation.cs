using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ombudsman.Models
{
    public class Manifestation
    {
        public long ManifestationId { get; set; }
        public string Status { get; set; }
        [Display(Name = "Subject matter")]
        [Required(ErrorMessage = "Enter subject matter")]
        public string SubjectMatter { get; set; }
        [Display(Name = "Type")]
        [Required(ErrorMessage = "Insert the type of event")]
        public string ManifestationType { get; set; }
        [Required(ErrorMessage = "Enter the initial message of the event")]
        public string Content { get; set; }
        [Display(Name = "Open Date")]
        public DateTime OpenDate { get; set; }
        [Display(Name = "Closing Date")]
        public DateTime ClosingDate { get; set; }
        public long? ProtesterId { get; set; }
        public long? UserId { get; set; }
        public long? SectorId { get; set; }
        public Protester Protester { get; set; }
        public User User { get; set; }
        public Sector Sector { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}