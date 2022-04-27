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
                    .HasName("PK__Alumno__878A58CDED98A4AC");

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
                    .HasName("PK__Docente__4070D0B1B0D1C2BF");

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
                    .HasName("PK__Grado__B207F32364FCE420");

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
                    .HasName("PK__Materia__06DAB30C955D3EB8");

                entity.Property(e => e.IdMateria).HasColumnName("ID_MATERIA");

                entity.Property(e => e.Materia)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NonimaAlumno>(entity =>
            {
                entity.HasKey(e => e.IdNonimnaAlumno)
                    .HasName("PK__Nonima_A__FC8F6835F03F5A44");

                entity.ToTable("Nonima_Alumno");

                entity.Property(e => e.IdNonimnaAlumno).HasColumnName("ID_NONIMNA_ALUMNO");

                entity.Property(e => e.FkIdAlumno).HasColumnName("FK_ID_ALUMNO");

                entity.Property(e => e.FkIdGrado).HasColumnName("FK_ID_GRADO");

                entity.HasOne(d => d.FkIdAlumnoNavigation)
                    .WithMany(p => p.NonimaAlumnos)
                    .HasForeignKey(d => d.FkIdAlumno)
                    .HasConstraintName("FK__Nonima_Al__FK_ID__6B24EA82");

                entity.HasOne(d => d.FkIdGradoNavigation)
                    .WithMany(p => p.NonimaAlumnos)
                    .HasForeignKey(d => d.FkIdGrado)
                    .HasConstraintName("FK__Nonima_Al__FK_ID__6C190EBB");
            });

            modelBuilder.Entity<NonimaDocente>(entity =>
            {
                entity.HasKey(e => e.IdNonimnaDocente)
                    .HasName("PK__Nonima_D__66E5F80E1B92E082");

                entity.ToTable("Nonima_Docente");

                entity.Property(e => e.IdNonimnaDocente).HasColumnName("ID_NONIMNA_DOCENTE");

                entity.Property(e => e.FkIdDocente).HasColumnName("FK_ID_DOCENTE");

                entity.Property(e => e.FkIdGrado).HasColumnName("FK_ID_GRADO");

                entity.Property(e => e.FkIdMateria).HasColumnName("FK_ID_MATERIA");

                entity.HasOne(d => d.FkIdDocenteNavigation)
                    .WithMany(p => p.NonimaDocentes)
                    .HasForeignKey(d => d.FkIdDocente)
                    .HasConstraintName("FK__Nonima_Do__FK_ID__693CA210");

                entity.HasOne(d => d.FkIdMateriaNavigation)
                    .WithMany(p => p.NonimaDocentes)
                    .HasForeignKey(d => d.FkIdMateria)
                    .HasConstraintName("FK__Nonima_Do__FK_ID__6A30C649");
            });

            modelBuilder.Entity<Notum>(entity =>
            {
                entity.HasKey(e => e.IdNota)
                    .HasName("PK__Nota__AB084D7CABDEC328");

                entity.Property(e => e.IdNota).HasColumnName("ID_NOTA");

                entity.Property(e => e.FkIdAlumno).HasColumnName("FK_ID_ALUMNO");

                entity.Property(e => e.FkIdGrado).HasColumnName("FK_ID_GRADO");

                entity.Property(e => e.FkIdMateria).HasColumnName("FK_ID_MATERIA");

                entity.Property(e => e.Nota1).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Nota2).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Nota3).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.NotaFinal).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.FkIdAlumnoNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.FkIdAlumno)
                    .HasConstraintName("FK__Nota__FK_ID_ALUM__6D0D32F4");

                entity.HasOne(d => d.FkIdGradoNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.FkIdGrado)
                    .HasConstraintName("FK__Nota__FK_ID_GRAD__6E01572D");

                entity.HasOne(d => d.FkIdMateriaNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.FkIdMateria)
                    .HasConstraintName("FK__Nota__FK_ID_MATE__6EF57B66");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
