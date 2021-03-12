namespace DPAContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DPAContextModels : DbContext
    {
        public DPAContextModels()
            : base("name=DPAContextModels")
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRequestComment> UserRequestComments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
