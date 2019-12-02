using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Modelo.Entidades;

namespace Modelo.Persistencia
{
    public partial class DBNominaSoftContext : DbContext
    {
        public DBNominaSoftContext()
        {
        }

        public DBNominaSoftContext(DbContextOptions<DBNominaSoftContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Afp> Afp { get; set; }
        public virtual DbSet<BoletaPago> BoletaPago { get; set; }
        public virtual DbSet<ConceptosDePago> ConceptosDePago { get; set; }
        public virtual DbSet<Contrato> Contrato { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<PeriodoPago> PeriodoPago { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Afp>(entity =>
            {
                entity.HasKey(e => e.IdAfp);

                entity.Property(e => e.IdAfp).HasColumnName("idAfp");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.PorcentajeDescuento)
                    .HasColumnName("porcentajeDescuento")
                    .HasColumnType("decimal(2, 2)");
            });

            modelBuilder.Entity<BoletaPago>(entity =>
            {
                entity.HasKey(e => e.IdBoletaPago);

                entity.Property(e => e.IdBoletaPago).HasColumnName("idBoletaPago");

                entity.Property(e => e.AsignacionFamiliar)
                    .HasColumnName("asignacionFamiliar")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.IdConceptosDePago).HasColumnName("idConceptosDePago");

                entity.Property(e => e.IdContrato).HasColumnName("idContrato");

                entity.Property(e => e.IdPeriodoPago).HasColumnName("idPeriodoPago");

                entity.Property(e => e.TotalHoras).HasColumnName("totalHoras");

                entity.Property(e => e.ValorHoras)
                    .HasColumnName("valorHoras")
                    .HasColumnType("decimal(4, 2)");

                entity.HasOne(d => d.ConceptosDePago)
                    .WithMany(p => p.BoletaPago)
                    .HasForeignKey(d => d.IdConceptosDePago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BoletaPago_ConceptosDePago");

                entity.HasOne(d => d.Contrato)
                    .WithMany(p => p.BoletaPago)
                    .HasForeignKey(d => d.IdContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BoletaPago_Contrato");

                entity.HasOne(d => d.PeriodoPago);
                    //.WithMany(p => p.BoletaPago)
                    //.HasForeignKey(d => d.IdPeriodoPago)
                    //.OnDelete(DeleteBehavior.ClientSetNull)
                    //.HasConstraintName("FK_BoletaPago_PeriodoPago");
            });

            modelBuilder.Entity<ConceptosDePago>(entity =>
            {
                entity.HasKey(e => e.IdConceptosDePago);

                entity.Property(e => e.IdConceptosDePago).HasColumnName("idConceptosDePago");

                entity.Property(e => e.IdContrato).HasColumnName("idContrato");

                entity.Property(e => e.IdPeriodoPago).HasColumnName("idPeriodoPago");

                entity.Property(e => e.MontoHorasAusente)
                    .HasColumnName("montoHorasAusente")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.MontoHorasExtra)
                    .HasColumnName("montoHorasExtra")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.MontoReintegros)
                    .HasColumnName("montoReintegros")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.OtrosDescuentos)
                    .HasColumnName("otrosDescuentos")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.OtrosIngresos)
                    .HasColumnName("otrosIngresos")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.TotalAdelantos)
                    .HasColumnName("totalAdelantos")
                    .HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.Contrato)
                    .WithMany(p => p.ConceptosDePago)
                    .HasForeignKey(d => d.IdContrato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_conceptosdepago_contrato");

                entity.HasOne(d => d.PeriodoPago);
                    //.WithMany(p => p.ConceptosDePago)
                    //.HasForeignKey(d => d.IdPeriodoPago)
                    //.OnDelete(DeleteBehavior.ClientSetNull)
                    //.HasConstraintName("FK_conceptosdepago_periodoPago");
            });

            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.HasKey(e => e.IdContrato);

                entity.Property(e => e.IdContrato).HasColumnName("idContrato");

                entity.Property(e => e.AsignacionFamiliar).HasColumnName("asignacionFamiliar");

                entity.Property(e => e.Cargo)
                    .IsRequired()
                    .HasColumnName("cargo")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaFin)
                    .HasColumnName("fechaFin")
                    .HasColumnType("date");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fechaInicio")
                    .HasColumnType("date");

                entity.Property(e => e.HorasSemanales).HasColumnName("horasSemanales");

                entity.Property(e => e.IdAfp).HasColumnName("idAfp");

                entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");

                entity.Property(e => e.ValorHora)
                    .HasColumnName("valorHora")
                    .HasColumnType("decimal(4, 2)");

                entity.HasOne(d => d.Afp)
                    .WithMany(p => p.Contrato)
                    .HasForeignKey(d => d.IdAfp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contrato__idAfp__46E78A0C");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contrato__idEmpl__45F365D3");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado);

                entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("dni")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoCivil)
                    .IsRequired()
                    .HasColumnName("estadoCivil")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("fechaNacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.GradoAcademico)
                    .IsRequired()
                    .HasColumnName("gradoAcademico")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PeriodoPago>(entity =>
            {
                entity.HasKey(e => e.IdPeriodoPago);

                entity.Property(e => e.IdPeriodoPago).HasColumnName("idPeriodoPago");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaFin)
                    .HasColumnName("fechaFin")
                    .HasColumnType("date");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fechaInicio")
                    .HasColumnType("date");
            });
        }
    }
}
