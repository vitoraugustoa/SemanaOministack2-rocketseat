using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api_semanaoministack2.Models;

namespace web_api_semanaoministack2.Data
{
    public class AulasContext : DbContext
    {
        public AulasContext(DbContextOptions<AulasContext> options) : base(options)
        { }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Connections> Connections { get; set; }
        public virtual DbSet<ClassSchedule> ClassSchedules { get; set; }
        public virtual DbSet<DadosUser> DadosUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DadosRegistro>(e =>
            {
                e.HasNoKey();
            });

            modelBuilder.Entity<Users>(e =>
            {
                e.ToTable("Users");
                e.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Classes>(e =>
            {
                e.ToTable("Classes");
                e.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Connections>(e =>
            {
                e.ToTable("Connections");
                e.HasKey(e => e.Id);
            });

            modelBuilder.Entity<ClassSchedule>(e =>
            {
                e.ToTable("ClassSchedule");
                e.HasKey(e => e.Id);
                e.Property(e => e.From).HasColumnName("_From");
                e.Property(e => e.WeekDay).HasColumnName("_WeekDay");
                e.Property(e => e.To).HasColumnName("_To");
                e.HasOne(e => e.Class).WithMany(e => e.ClassSchedules).HasForeignKey(e => e.IdClass);
            });
        }
    }
}
