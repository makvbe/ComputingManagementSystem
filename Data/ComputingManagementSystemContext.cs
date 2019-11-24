using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ComputingManagementSystem.Models;

namespace ComputingManagementSystem.Data
{
    public class ComputingManagementSystemContext : DbContext
    {
        public ComputingManagementSystemContext (DbContextOptions<ComputingManagementSystemContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<ProfessorSoftware>()
                .HasKey(s => new { s.SoftwareId, s.ProfessorId });

            modelBuilder.Entity<ProfessorSoftware>()
                .HasOne(ps => ps.Professor)
                .WithMany(p => p.ProfessorSoftware)
                .HasForeignKey(ps => ps.ProfessorId);

            modelBuilder.Entity<ProfessorSoftware>()
                .HasOne(ps => ps.Software)
                .WithMany(p => p.ProfessorSoftware)
                .HasForeignKey(ps => ps.SoftwareId);
        }

        public DbSet<ComputingManagementSystem.Models.Professor> Professor { get; set; }

        public DbSet<ComputingManagementSystem.Models.Software> Software { get; set; }

        public DbSet<ComputingManagementSystem.Models.ProfessorSoftware> ProfessorSoftware { get; set; }

    }
}
