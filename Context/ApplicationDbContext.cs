using demandeAdmin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace demandeAdmin.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Document> Documents { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<State> States { get; set; }
    }
}