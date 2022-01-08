using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AutoLotModel
{
    public partial class AutoLotEntitiesModel : DbContext
    {
        public AutoLotEntitiesModel()
            : base("name=AutoLotEntitiesModel")
        {
        }

        public virtual DbSet<Angajati> Angajatis { get; set; }
        public virtual DbSet<Caini> Cainis { get; set; }
        public virtual DbSet<Rezervari> Rezervaris { get; set; }
        public virtual DbSet<Sarcini> Sarcinis { get; set; }
        public virtual DbSet<Stapani> Stapanis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Angajati>()
                .HasMany(e => e.Sarcinis)
                .WithOptional(e => e.Angajati)
                .HasForeignKey(e => e.Id_angajat)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Rezervari>()
                .HasMany(e => e.Sarcinis)
                .WithOptional(e => e.Rezervari)
                .WillCascadeOnDelete();
        }
    }
}
