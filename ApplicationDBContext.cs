using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using netlectureAPI.Models;

namespace netlectureAPI
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }


        private static void SeedData(ModelBuilder modelBuilder)
        {
            var aventura = new Genre { Id = Guid.NewGuid(), Name = "Aventura" };
            var novela = new Genre { Id = Guid.NewGuid(), Name = "Novela" };
            var terror = new Genre { Id = Guid.NewGuid(), Name = "Terror" };
            var fantasía = new Genre { Id = Guid.NewGuid(), Name = "Fantasía" };

            modelBuilder.Entity<Genre>()
                        .HasData(new List<Genre>()
                        { aventura, novela, terror, fantasía });

            var jkRowling = new Author { Id = Guid.NewGuid(), Name = "J.K Rowling" };
            var miguelCervantes = new Author { Id = Guid.NewGuid(), Name = "Miguel de Cervantes" };
            var sthephenieMeyer = new Author { Id = Guid.NewGuid(), Name = "Stephenie Meyer" };
            var suzanneCollins = new Author { Id = Guid.NewGuid(), Name = "Suzanne Collins" };

            modelBuilder.Entity<Author>()
                        .HasData(new List<Author>()
                        { jkRowling, miguelCervantes, sthephenieMeyer, suzanneCollins});

            var harryPotter1 = new Book
            {
                Id = Guid.NewGuid(),
                Title = "Harry Potter y La Piedra Filosofal",
                AuthorId = jkRowling.Id,
                GenreId = fantasía.Id,
                Summary = "",
                Qualification = 5,
                Grade = Grade.First
            };
            var quijote = new Book
            {
                Id = Guid.NewGuid(),
                Title = "Don Quijote de la Mancha",
                AuthorId = miguelCervantes.Id,
                GenreId = novela.Id,
                Summary = "",
                Qualification = 3,
                Grade = Grade.First
            };
            var crepusculo = new Book
            {
                Id = Guid.NewGuid(),
                Title = "Crepusculo",
                AuthorId = sthephenieMeyer.Id,
                GenreId = novela.Id,
                Summary = "",
                Qualification = 4,
                Grade = Grade.Second
            };
            var juegos = new Book
            {
                Id = Guid.NewGuid(),
                Title = "Los Juegos del Hambre",
                AuthorId = suzanneCollins.Id,
                GenreId = aventura.Id,
                Summary = "",
                Qualification = 5,
                Grade = Grade.Third
            };

            modelBuilder.Entity<Book>()
                        .HasData(new List<Book>
                        { harryPotter1, quijote, crepusculo, juegos });
        }
    }

}
