using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TDB
{
    public partial class TitleDBContext : DbContext
    {
        public TitleDBContext()
        {
        }

        public TitleDBContext(DbContextOptions<TitleDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acting> Acting { get; set; }
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookTypes> BookTypes { get; set; }
        public virtual DbSet<Characters> Characters { get; set; }
        public virtual DbSet<Directors> Directors { get; set; }
        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<Founder> Founder { get; set; }
        public virtual DbSet<Franchaise> Franchaise { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Series> Series { get; set; }
        public virtual DbSet<Studio> Studio { get; set; }
        public virtual DbSet<Title> Title { get; set; }
        public virtual DbSet<TitleToGenre> TitleToGenre { get; set; }
        public virtual DbSet<VoiceActing> VoiceActing { get; set; }
        public virtual DbSet<VoiceActors> VoiceActors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-K5PEQJ0\\SQLEXPRESS; Database=TitleDB; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acting>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CharacterId).HasColumnName("CharacterID");

                entity.Property(e => e.TitleId).HasColumnName("TitleID");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.Acting)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Acting_Characters");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Acting)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Acting_Title");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.TitleId).HasColumnName("TitleID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ranobe_Title1");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ranobe_Title");
            });

            modelBuilder.Entity<BookTypes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Characters>(entity =>
            {
                entity.Property(e => e.AppDescription).IsRequired();

                entity.Property(e => e.FirstApp).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Role).IsRequired();

                entity.Property(e => e.Temper).IsRequired();

                entity.Property(e => e.VoiceActId).HasColumnName("VoiceActID");

                entity.HasOne(d => d.VoiceAct)
                    .WithMany(p => p.Characters)
                    .HasForeignKey(d => d.VoiceActId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Characters_VoiceActors");
            });

            modelBuilder.Entity<Directors>(entity =>
            {
                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Soundtrack).IsRequired();

                entity.Property(e => e.TitleId).HasColumnName("TitleID");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Film)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Film_Title");
            });

            modelBuilder.Entity<Founder>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.TitleId).HasColumnName("TitleID");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Founder)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Founder_Author");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Founder)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Founder_Title");
            });

            modelBuilder.Entity<Franchaise>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Games>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.TitleId).HasColumnName("TitleID");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Games_Title");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Series>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ending).IsRequired();

                entity.Property(e => e.Opening).IsRequired();

                entity.Property(e => e.TitleId).HasColumnName("TitleID");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Series)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Series_Title");
            });

            modelBuilder.Entity<Studio>(entity =>
            {
                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.DirectorId).HasColumnName("DirectorID");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Director)
                    .WithMany(p => p.Studio)
                    .HasForeignKey(d => d.DirectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Studio_Directors");
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.Property(e => e.FranchaiseId).HasColumnName("FranchaiseID");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.StudioId).HasColumnName("StudioID");

                entity.HasOne(d => d.Franchaise)
                    .WithMany(p => p.Title)
                    .HasForeignKey(d => d.FranchaiseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Title_Franchaise");

                entity.HasOne(d => d.Studio)
                    .WithMany(p => p.Title)
                    .HasForeignKey(d => d.StudioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Title_Studio");
            });

            modelBuilder.Entity<TitleToGenre>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.Property(e => e.TitleId).HasColumnName("TitleID");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.TitleToGenre)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TitleToGenre_Genre");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.TitleToGenre)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TitleToGenre_Title");
            });

            modelBuilder.Entity<VoiceActing>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActorId).HasColumnName("ActorID");

                entity.Property(e => e.TitleId).HasColumnName("TitleID");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.VoiceActing)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VoiceActing_VoiceActors");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.VoiceActing)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VoiceActing_Title");
            });

            modelBuilder.Entity<VoiceActors>(entity =>
            {
                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
