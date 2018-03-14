using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmbudsmanOpet.Models
{
    public class AuthorizedEmail
    {
        public long AuthorizedEmailId { get; set; }
        public string Description { get; set; }

        public long ManifestationId { get; set; }
        public Manifestation Manifestation { get; set; }
    }
}