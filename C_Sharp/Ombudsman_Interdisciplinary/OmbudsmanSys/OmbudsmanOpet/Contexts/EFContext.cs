using OmbudsmanOpet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OmbudsmanOpet.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") { }
        public DbSet<Manifestation> Manifestations { get; set; }
        public DbSet<AuthorizedEmail> AuthorizedEmails { get; set; }
        public DbSet<User> Users { get; set; }

    }
}