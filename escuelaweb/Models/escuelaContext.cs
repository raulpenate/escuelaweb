using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace escuelaweb.Models
{
    public partial class escuelaContext : DbContext
    {
        public escuelaContext()
        {
        }

        public escuelaContext(DbContextOptions<escuelaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; } = null!;
        public virtual DbSet<Docente> Docentes { get; set; } = null!;
        public virtual DbSet<Grado> Grados { get; set; } = null!;
        public virtual DbSet<Materium> Materia { get; set; } = null!;
        public virtual DbSet<NonimaAlumno> NonimaAlumnos { get; set; } = null!;
        public virtual DbSet<NonimaDocente> NonimaDocentes { get; set; } = null!;
        public virtual DbSet<Notum> Nota { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=holaescuela.database.windows.net,1433;Database=escuela;User ID=CultOfJava503;Password=passIsBanana100!!;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.IdAlumno)
                    .HasName("PK__Alumno__878A58CD04D03C22");

                entity.ToTable("Alumno");

                entity.Property(e => e.IdAlumno).HasColumnName("ID_ALUMNO");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FecNac).HasColumnType("date");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Docente>(entity =>
            {
                entity.HasKey(e => e.IdDocente)
                    .HasName("PK__Docente__4070D0B11BE3847D");

                entity.ToTable("Docente");

                entity.Property(e => e.IdDocente).HasColumnName("ID_DOCENTE");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FecNac).HasColumnType("date");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grado>(entity =>
            {
                entity.HasKey(e => e.IdGrado)
                    .HasName("PK__Grado__B207F323777AE53C");

                entity.ToTable("Grado");

                entity.Property(e => e.IdGrado).HasColumnName("ID_GRADO");

                entity.Property(e => e.Grado1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Grado");
            });

            modelBuilder.Entity<Materium>(entity =>
            {
                entity.HasKey(e => e.IdMateria)
                    .HasName("PK__Materia__06DAB30C7F6EFFBA");

                entity.Property(e => e.IdMateria).HasColumnName("ID_MATERIA");

                entity.Property(e => e.Materia)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NonimaAlumno>(entity =>
            {
                entity.HasKey(e => e.IdNonimnaAlumno)
                    .HasName("PK__Nonima_A__FC8F68357535F74B");

                entity.ToTable("Nonima_Alumno");

                entity.Property(e => e.IdNonimnaAlumno).HasColumnName("ID_NONIMNA_ALUMNO");

                entity.Property(e => e.FkIdAlumno).HasColumnName("FK_ID_ALUMNO");

                entity.Property(e => e.FkIdGrado).HasColumnName("FK_ID_GRADO");
            });

            modelBuilder.Entity<NonimaDocente>(entity =>
            {
                entity.HasKey(e => e.IdNonimnaDocente)
                    .HasName("PK__Nonima_D__66E5F80EAC11572E");

                entity.ToTable("Nonima_Docente");

                entity.Property(e => e.IdNonimnaDocente).HasColumnName("ID_NONIMNA_DOCENTE");

                entity.Property(e => e.FkIdDocente).HasColumnName("FK_ID_DOCENTE");

                entity.Property(e => e.FkIdGrado).HasColumnName("FK_ID_GRADO");

                entity.Property(e => e.FkIdMateria).HasColumnName("FK_ID_MATERIA");

            });

            modelBuilder.Entity<Notum>(entity =>
            {
                entity.HasKey(e => e.IdNota)
                    .HasName("PK__Nota__AB084D7C5D67891A");

                entity.Property(e => e.IdNota).HasColumnName("ID_NOTA");

                entity.Property(e => e.Calificacion).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.FkIdAlumno).HasColumnName("FK_ID_ALUMNO");

                entity.Property(e => e.FkIdDocente).HasColumnName("FK_ID_DOCENTE");

                entity.Property(e => e.FkIdGrado).HasColumnName("FK_ID_GRADO");

                entity.Property(e => e.FkIdMateria).HasColumnName("FK_ID_MATERIA");

                entity.Property(e => e.Trimestre).HasColumnName("TRIMESTRE");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
