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

    public virtual DbSet<Step> Steps { get; set; }

    public virtual DbSet<StepField> StepFields { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-I0OTQSJ\\SQLEXPRESS;Database=WorkFlows; User Id=UserWorkFlows; Password=123456;TrustServerCertificate=Yes;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Field>(entity =>
        {
            entity.HasKey(e => e.FieldId).HasName("PK__Fields__C8B6FF27C802846A");

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
            entity.HasKey(e => e.FlowId).HasName("PK__Flows__1184B35CA3759E46");

            entity.Property(e => e.FlowId)
                .ValueGeneratedNever()
                .HasColumnName("FlowID");
            entity.Property(e => e.FlowName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Step>(entity =>
        {
            entity.HasKey(e => e.StepId).HasName("PK__Steps__24343337BA3C1B15");

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
                .HasConstraintName("FK__Steps__FlowID__38996AB5");
        });

        modelBuilder.Entity<StepField>(entity =>
        {
            entity.HasKey(e => new { e.StepId, e.FieldId }).HasName("PK__StepFiel__48BF5CC56E5786FE");

            entity.Property(e => e.StepId).HasColumnName("StepID");
            entity.Property(e => e.FieldId).HasColumnName("FieldID");

            entity.HasOne(d => d.Field).WithMany(p => p.StepFields)
                .HasForeignKey(d => d.FieldId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StepField__Field__3E52440B");

            entity.HasOne(d => d.Step).WithMany(p => p.StepFields)
                .HasForeignKey(d => d.StepId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StepField__StepI__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
