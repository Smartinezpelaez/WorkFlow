using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WorkFlow.DAL.Models;

public partial class WorkFlowsContext : DbContext
{
    public WorkFlowsContext()
    {
    }

    public WorkFlowsContext(DbContextOptions<WorkFlowsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Field> Fields { get; set; }

    public virtual DbSet<Flow> Flows { get; set; }

    public virtual DbSet<FlowStep> FlowSteps { get; set; }

    public virtual DbSet<FlowStepsDepend> FlowStepsDepends { get; set; }

    public virtual DbSet<FlowStepsField> FlowStepsFields { get; set; }

    public virtual DbSet<Step> Steps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-I0OTQSJ\\SQLEXPRESS;Database=WorkFlows; User Id=UserWorkFlows; Password=123456;TrustServerCertificate=Yes;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Field>(entity =>
        {
            entity.HasKey(e => e.FieldId).HasName("PK__Fields__C8B6FF274BC08817");

            entity.Property(e => e.FieldId)
                .ValueGeneratedNever()
                .HasColumnName("FieldID");
            entity.Property(e => e.FieldCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FieldName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Flow>(entity =>
        {
            entity.HasKey(e => e.FlowId).HasName("PK__Flows__1184B35CD5F3D0F6");

            entity.Property(e => e.FlowId)
                .ValueGeneratedNever()
                .HasColumnName("FlowID");
            entity.Property(e => e.FlowName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FlowStep>(entity =>
        {
            entity.HasKey(e => e.FlowsStepId).HasName("PK__FlowStep__37472DAD1E6D6A7B");

            entity.Property(e => e.FlowsStepId).HasColumnName("FlowsStepID");
            entity.Property(e => e.FlowdId).HasColumnName("FlowdID");
            entity.Property(e => e.StepId).HasColumnName("StepID");

            entity.HasOne(d => d.Flowd).WithMany(p => p.FlowSteps)
                .HasForeignKey(d => d.FlowdId)
                .HasConstraintName("FK__FlowSteps__Flowd__03F0984C");

            entity.HasOne(d => d.Step).WithMany(p => p.FlowSteps)
                .HasForeignKey(d => d.StepId)
                .HasConstraintName("FK__FlowSteps__StepI__02FC7413");
        });

        modelBuilder.Entity<FlowStepsDepend>(entity =>
        {
            entity.HasKey(e => e.FlowStepsDependId).HasName("PK__FlowStep__40826B31F7E250CC");

            entity.Property(e => e.FlowStepsDependId).HasColumnName("FlowStepsDependID");
            entity.Property(e => e.FlowsStepId).HasColumnName("FlowsStepID");

            entity.HasOne(d => d.FlowsStep).WithMany(p => p.FlowStepsDepends)
                .HasForeignKey(d => d.FlowsStepId)
                .HasConstraintName("FK__FlowSteps__Flows__0A9D95DB");
        });

        modelBuilder.Entity<FlowStepsField>(entity =>
        {
            entity.HasKey(e => e.FlowStepsFieldId).HasName("PK__FlowStep__8D8DFA590A50F645");

            entity.Property(e => e.FlowStepsFieldId).HasColumnName("FlowStepsFieldID");
            entity.Property(e => e.FieldId).HasColumnName("FieldID");
            entity.Property(e => e.FlowsStepId).HasColumnName("FlowsStepID");

            entity.HasOne(d => d.Field).WithMany(p => p.FlowStepsFields)
                .HasForeignKey(d => d.FieldId)
                .HasConstraintName("FK__FlowSteps__Field__07C12930");

            entity.HasOne(d => d.FlowsStep).WithMany(p => p.FlowStepsFields)
                .HasForeignKey(d => d.FlowsStepId)
                .HasConstraintName("FK__FlowSteps__Flows__06CD04F7");
        });

        modelBuilder.Entity<Step>(entity =>
        {
            entity.HasKey(e => e.StepId).HasName("PK__Steps__2434333724E8FC44");

            entity.Property(e => e.StepId)
                .ValueGeneratedNever()
                .HasColumnName("StepID");
            entity.Property(e => e.FlowId).HasColumnName("FlowID");
            entity.Property(e => e.StepCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StepName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Flow).WithMany(p => p.Steps)
                .HasForeignKey(d => d.FlowId)
                .HasConstraintName("FK__Steps__FlowID__66603565");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
