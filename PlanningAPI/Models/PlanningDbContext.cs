using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PlanningAPI.Models;

public partial class PlanningDbContext : DbContext
{
    public PlanningDbContext()
    {
    }

    public PlanningDbContext(DbContextOptions<PlanningDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    public virtual DbSet<Workerposition> Workerpositions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=planning_db;Username=postgres;Password=an124hy7");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("department_pkey");

            entity.ToTable("department");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("project_pkey");

            entity.ToTable("project");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("salary_pkey");

            entity.ToTable("salary");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Salary1).HasColumnName("salary");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("task_pkey");

            entity.ToTable("task");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dependsontask).HasColumnName("dependsontask");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Project).HasColumnName("project");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.DependsontaskNavigation).WithMany(p => p.InverseDependsontaskNavigation)
                .HasForeignKey(d => d.Dependsontask)
                .HasConstraintName("task_dependsontask_fkey");

            entity.HasOne(d => d.ProjectNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Project)
                .HasConstraintName("task_project_fkey");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("worker_pkey");

            entity.ToTable("worker");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Department).HasColumnName("department");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Position).HasColumnName("position");

            entity.HasOne(d => d.DepartmentNavigation).WithMany(p => p.Workers)
                .HasForeignKey(d => d.Department)
                .HasConstraintName("worker_department_fkey");

            entity.HasOne(d => d.PositionNavigation).WithMany(p => p.Workers)
                .HasForeignKey(d => d.Position)
                .HasConstraintName("worker_position_fkey");

            entity.HasMany(d => d.Tasks).WithMany(p => p.Workers)
                .UsingEntity<Dictionary<string, object>>(
                    "Workerdotask",
                    r => r.HasOne<Task>().WithMany()
                        .HasForeignKey("Task")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("workerdotask_task_fkey"),
                    l => l.HasOne<Worker>().WithMany()
                        .HasForeignKey("Worker")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("workerdotask_worker_fkey"),
                    j =>
                    {
                        j.HasKey("Worker", "Task").HasName("workerdotask_pkey");
                        j.ToTable("workerdotask");
                        j.IndexerProperty<int>("Worker").HasColumnName("worker");
                        j.IndexerProperty<int>("Task").HasColumnName("task");
                    });
        });

        modelBuilder.Entity<Workerposition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("workerposition_pkey");

            entity.ToTable("workerposition");

            entity.HasIndex(e => e.Salary, "workerposition_salary_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Salary).HasColumnName("salary");

            entity.HasOne(d => d.SalaryNavigation).WithOne(p => p.Workerposition)
                .HasForeignKey<Workerposition>(d => d.Salary)
                .HasConstraintName("workerposition_salary_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
