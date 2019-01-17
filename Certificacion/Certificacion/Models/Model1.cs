namespace Certificacion.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Mesas> Mesas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mesas>()
                .Property(e => e.Ubicacion)
                .IsUnicode(false);

            modelBuilder.Entity<Mesas>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Mesas>()
                .Property(e => e.Consumo)
                .HasPrecision(19, 4);
        }
    }
}
