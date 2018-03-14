using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OmbudsmanOpet.Models
{
    public class Manifestation
    {
        public long ManifestationId { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string ProtesterName { get; set; }
        public string ProtesterCpf { get; set; }
        public long ProtesterTelephone { get; set; }
        public string ProtesterEmail { get; set; }
        public string ProtesterAdress { get; set; }
        public string SubjectMatter { get; set; }
        public string Content { get; set; }
        public string Attendant { get; set; }
        public string AttendantTelephone { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime OpenDate { get; set; } = DateTime.Now;
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? ClosingDate { get; set; }


        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<AuthorizedEmail> AuthorizedEmails { get; set; }
    }
}