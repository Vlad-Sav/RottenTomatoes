using Microsoft.EntityFrameworkCore;
using RottenTomatoes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RottenTomatoes.Data
{
    public class RottenTomatoesDbContext: DbContext
    {
        public RottenTomatoesDbContext()
           : base()
        { }
       

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<DirectorsMovies> DirectorsMovies{ get; set; }
        public DbSet<Genre> Genres{ get; set; }
        public DbSet<GenresMovies> GenresMovies{ get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Tomatoe> Tomatoes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=LAPTOP-AS3UV8CS\\SQLEXPRESS;Database=RottenTomatoes;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DirectorsMovies>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("DMId");

                entity.Property(e => e.DirectorId).HasColumnName("DirectorId");

                entity.Property(e => e.MovieId).HasColumnName("MovieId");
                
                entity.HasOne(d => d.Director)
                    .WithMany(p => p.DirectorsMovies)
                    .HasForeignKey(d => d.DirectorId)
                    .HasConstraintName("FK_DirectorsMovies_Director");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.DirectorsMovies)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_DirectorsMovies_Movie");

            });
            modelBuilder.Entity<GenresMovies>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("GMId");

                entity.Property(e => e.GenreId).HasColumnName("GenreId");

                entity.Property(e => e.MovieId).HasColumnName("MovieId");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.GenresMovies)
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK_GenresMovies_Genre");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.GenresMovies)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_GenresMovies_Movie");
            });
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("CommentId");

                entity.Property(e => e.TomatoeId).HasColumnName("TomatoeId");

                entity.Property(e => e.MovieId).HasColumnName("MovieId");
                entity.Property(e => e.Text)
                    .HasColumnName("Text")
                    .HasMaxLength(1000)
                    .IsFixedLength();

                entity.HasOne(d => d.Tomatoe)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.TomatoeId)
                    .HasConstraintName("FK_Comment_Tomatoe");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("FK_Comment_Movie");

            });
            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("DirectorId");

                entity.Property(e => e.DirectorName)
                    .HasColumnName("DirectorName")
                    .HasMaxLength(100)
                    .IsFixedLength();
                entity.Property(e => e.DirectorSurname)
                   .HasColumnName("DirectorSurname")
                   .HasMaxLength(100)
                   .IsFixedLength();
            });
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("MovieId");

                entity.Property(e => e.MovieName)
                    .HasColumnName("MovieName")
                    .HasMaxLength(100)
                    .IsFixedLength();
                entity.Property(e => e.Time)
                   .HasColumnName("Time")
                   .HasColumnType("time");
                entity.Property(e => e.BannerUrl)
                    .HasColumnName("BannerUrl")
                    .HasMaxLength(100)
                    .IsFixedLength();
                entity.Property(e => e.Year)
                    .HasColumnName("Year");
                  
            });
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("GenreId");

                entity.Property(e => e.GenreName)
                    .HasColumnName("GenreName")
                    .HasMaxLength(100)
                    .IsFixedLength();
               
            });
            modelBuilder.Entity<Tomatoe>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("TomatoeId");

                entity.Property(e => e.TomatoeName)
                    .HasColumnName("TomatoeName")
                    .HasMaxLength(100)
                    .IsFixedLength();
                entity.Property(e => e.Password)
                    .HasColumnName("Password")
                    .HasMaxLength(100)
                    .IsFixedLength();
            });
        }
    }
}
