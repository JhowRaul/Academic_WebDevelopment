using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OmbudsmanOpet.Models
{
    public class User
    {
        public long UserId { get; set; }
        public long Cpf { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public long? Pin { get; set; }
        public bool Admin { get; set; }

        public virtual ICollection<Manifestation> Manifestations { get; set; }
    }
}