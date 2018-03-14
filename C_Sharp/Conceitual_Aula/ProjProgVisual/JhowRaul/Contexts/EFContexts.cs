using JhowRaul.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JhowRaul.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Supply> Supplies { get; set; }
    }
}