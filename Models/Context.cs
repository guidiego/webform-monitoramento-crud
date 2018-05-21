namespace Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=models")
        {
        }

        public virtual DbSet<Clients> Clients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Clients>()
                .Property(e => e.Description)
                .IsUnicode(false);
        }
    }
}
