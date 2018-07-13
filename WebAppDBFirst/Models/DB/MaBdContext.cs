using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppDBFirst.Models.DB
{
    public partial class MaBdContext : DbContext
    {
        public MaBdContext()
        {
        }

        public MaBdContext(DbContextOptions<MaBdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adresse> Adresse { get; set; }
        public virtual DbSet<CarteIdentite> CarteIdentite { get; set; }
        public virtual DbSet<Citoyen> Citoyen { get; set; }
        public virtual DbSet<Compte> Compte { get; set; }
        public virtual DbSet<Pays> Pays { get; set; }
        public virtual DbSet<Relation> Relation { get; set; }
        public virtual DbSet<TypeCarte> TypeCarte { get; set; }
        public virtual DbSet<TypeRelation> TypeRelation { get; set; }
        public virtual DbSet<Ville> Ville { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=(local);Database=MaBd;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adresse>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdresseActuelle)
                    .HasColumnName("adresseActuelle")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CodePostal).HasColumnName("codePostal");

                entity.Property(e => e.IdPays).HasColumnName("idPays");

                entity.Property(e => e.Rue)
                    .HasColumnName("rue")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPaysNavigation)
                    .WithMany(p => p.Adresse)
                    .HasForeignKey(d => d.IdPays)
                    .HasConstraintName("FK_association6");
            });

            modelBuilder.Entity<CarteIdentite>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.IdTypeCarte).HasColumnName("idTypeCarte");

                entity.HasOne(d => d.IdTypeCarteNavigation)
                    .WithMany(p => p.CarteIdentite)
                    .HasForeignKey(d => d.IdTypeCarte)
                    .HasConstraintName("FK_association9");
            });

            modelBuilder.Entity<Citoyen>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateNaissance)
                    .HasColumnName("dateNaissance")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdAdresse).HasColumnName("idAdresse");

                entity.Property(e => e.IdCarte).HasColumnName("idCarte");

                entity.Property(e => e.IdCompte).HasColumnName("idCompte");

                entity.Property(e => e.IdRelation).HasColumnName("idRelation");

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasColumnName("prenom")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .HasColumnName("telephone")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAdresseNavigation)
                    .WithMany(p => p.Citoyen)
                    .HasForeignKey(d => d.IdAdresse)
                    .HasConstraintName("FK_association1");

                entity.HasOne(d => d.IdCarteNavigation)
                    .WithMany(p => p.Citoyen)
                    .HasForeignKey(d => d.IdCarte)
                    .HasConstraintName("FK_association4");

                entity.HasOne(d => d.IdCompteNavigation)
                    .WithMany(p => p.Citoyen)
                    .HasForeignKey(d => d.IdCompte)
                    .HasConstraintName("FK_association3");

                entity.HasOne(d => d.IdRelationNavigation)
                    .WithMany(p => p.Citoyen)
                    .HasForeignKey(d => d.IdRelation)
                    .HasConstraintName("FK_association2");
            });

            modelBuilder.Entity<Compte>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.Mdp)
                    .HasColumnName("mdp")
                    .HasMaxLength(254)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pays>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Libelle)
                    .HasColumnName("libelle")
                    .HasMaxLength(254)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Relation>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdTypeRelation).HasColumnName("idTypeRelation");

                entity.HasOne(d => d.IdTypeRelationNavigation)
                    .WithMany(p => p.Relation)
                    .HasForeignKey(d => d.IdTypeRelation)
                    .HasConstraintName("FK_association7");
            });

            modelBuilder.Entity<TypeCarte>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Libelle)
                    .HasColumnName("libelle")
                    .HasMaxLength(254)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeRelation>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Libelle)
                    .HasColumnName("libelle")
                    .HasMaxLength(254)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ville>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdPays).HasColumnName("idPays");

                entity.Property(e => e.Ville1)
                    .HasColumnName("ville")
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPaysNavigation)
                    .WithMany(p => p.Ville)
                    .HasForeignKey(d => d.IdPays)
                    .HasConstraintName("FK_association8");
            });
        }
    }
}
