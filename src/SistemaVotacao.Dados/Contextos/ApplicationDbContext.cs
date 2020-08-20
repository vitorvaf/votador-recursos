using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SistemaVotacao.Dominio.Funcionarios;
using SistemaVotacao.Dominio.Recursos;
using SistemaVotacao.Dominio.Votos;

namespace SistemaVotacao.Dados.Contextos
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Recurso> Recursos { get; set; }
        public virtual DbSet<Voto> Votos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=password");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.ToTable("funcionarios");

                entity.HasIndex(e => e.Email)
                    .HasName("funcionarios_email_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(255);

                entity.Property(e => e.Senha).HasColumnName("senha");
            });

            modelBuilder.Entity<Recurso>(entity =>
            {
                entity.ToTable("recursos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(255);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Voto>(entity =>
            {
                entity.ToTable("votos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comentario)
                    .HasColumnName("comentario")
                    .HasMaxLength(255);

                entity.Property(e => e.DataVoto)
                    .HasColumnName("data_voto")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.IdFuncionario).HasColumnName("id_funcionario");

                entity.Property(e => e.IdRecurso).HasColumnName("id_recurso");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.Votos)
                    .HasForeignKey(d => d.IdFuncionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_funcionario");

                entity.HasOne(d => d.IdRecursoNavigation)
                    .WithMany(p => p.Votos)
                    .HasForeignKey(d => d.IdRecurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_recurso");
            });
        }
    }
}
