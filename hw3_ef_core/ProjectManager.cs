using hw3_ef_core.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace hw3_ef_core
{
    public partial class ProjectManager : DbContext
    {
        public ProjectManager()
            : base("name=ProjectManager")
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskDetail> TaskDetails { get; set; }
        public DbSet<Team> Teams { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Many to one
            modelBuilder.Entity<Employee>()
                .HasRequired(e => e.Team)
                .WithMany(e => e.Employees)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Task>()
                .HasRequired(t => t.Employee)
                .WithMany(e => e.Tasks)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Task>()
                .HasRequired(t => t.Project)
                .WithMany(p => p.Tasks)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Project>()
                .HasRequired(p => p.Team)
                .WithMany(t => t.Projects)
                .WillCascadeOnDelete(false);
            //One to one
            modelBuilder.Entity<Task>()
                .HasOptional(t => t.Detail)
                .WithRequired(td => td.Task)
                .WillCascadeOnDelete(false);
            //Many to many
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Employees)
                .WithMany(e => e.Projects)
                .Map(pe =>
                {
                    pe.MapLeftKey("ProjectId");
                    pe.MapRightKey("EmployeeId");
                    pe.ToTable("ProjectEmployees");
                });
        }
    }
}
