using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ombudsman.Models
{
    public class Message
    {
        public long? MessageId { get; set; }
        [Required(ErrorMessage = "Enter message")]
        public string Content { get; set; }
        public DateTime DateMessage { get; set; }

        public long? ManifestationId { get; set; }

        public Manifestation Manifestation { get; set; }
    }
}