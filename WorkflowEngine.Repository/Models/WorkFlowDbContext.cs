using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WorkflowEngine.Repository.Models
{
    public partial class WorkFlowDbContext : DbContext
    {
        public WorkFlowDbContext()
        {
        }

        public WorkFlowDbContext(DbContextOptions<WorkFlowDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<WorkFlowMaster> WorkFlowMaster { get; set; }
        public virtual DbSet<WorkFlowTask> WorkFlowTask { get; set; }
        public virtual DbSet<WorkFlowVariable> WorkFlowVariable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<WorkFlowMaster>(entity =>
            {
                entity.HasKey(e => e.WorkFlowId);

                entity.Property(e => e.LaunchType).HasMaxLength(20);

                entity.Property(e => e.WorkFlowDescription).HasMaxLength(100);

                entity.Property(e => e.WorkFlowName).HasMaxLength(100);
            });

            modelBuilder.Entity<WorkFlowTask>(entity =>
            {
                entity.HasKey(e => e.TaskId);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.Workflow)
                    .WithMany(p => p.WorkFlowTask)
                    .HasForeignKey(d => d.WorkflowId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<WorkFlowVariable>(entity =>
            {
                entity.HasKey(e => e.VariableId);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Value).HasMaxLength(50);

                entity.HasOne(d => d.WorkFlow)
                    .WithMany(p => p.WorkFlowVariable)
                    .HasForeignKey(d => d.WorkFlowId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
