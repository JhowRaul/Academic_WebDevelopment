using Ombudsman.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ombudsman.Contexts
{
    public class EFContext  :   DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") {
            Database.SetInitializer<EFContext>(
                new DropCreateDatabaseIfModelChanges<EFContext>());
        }
        public DbSet<Manifestation> Manifestations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Protester> Protesters { get; set; }
        public DbSet<Telephone> Telephones { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<Ombudsman.Models.Sector> Sectors { get; set; }

        public System.Data.Entity.DbSet<Ombudsman.Models.Account> Accounts { get; set; }
    }
}