using BookMyShow.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.Data
{
    public class MovieDbContext : IdentityDbContext<IdentityUser>
    {
        public MovieDbContext(DbContextOptions options) : base(options)
        {

        }
        DbSet<Booking> Booking { get; set; }
        DbSet<Show> Shows { get; set; }
        DbSet<Theatre> Theatres { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<BookingCart> BookingCart { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>().HasData( 
            new Movie
            {
                Id = Guid.Parse("bad19dc3-29b2-4baf-a605-8057e7a94133"),
                Name = "Batman Begins",
                Cast = "Batman",
                MusicDirector = "Andrew",
                Director = "Robert",
                Producer = "Angella",
                Duration = 245,
                AgeRating = "13",
                Genre = "Action, Sci-Fi, Thriller",
                Language = "English",
                Poster = "",
                ReleaseDate = DateOnly.Parse("05-23-2024"),
                Trailer = "",
                MovieState = 2
            },
            new Movie
            {
                Id = Guid.Parse("d4a09cd4-77cc-44ee-a314-36353df7e11f"),
                Name = "Batman Returns",
                Cast = "Batman",
                MusicDirector = "Andrew",
                Director = "Robert",
                Producer = "Angella, Polo",
                Duration = 231,
                AgeRating = "13",
                Genre = "Action, Sci-Fi, Thriller",
                Language = "English",
                Poster = "",
                ReleaseDate = DateOnly.Parse("05-29-2024"),
                Trailer = "",
                MovieState = 2
            },
            new Movie
            {
                Id = Guid.Parse("fd437359-a545-4be5-93b0-fab21b30010f"),
                Name = "Batman vs Superman",
                Cast = "Batman, Superman",
                MusicDirector = "Andrew",
                Director = "Robert",
                Producer = "Angella, Polo, Colon",
                Duration = 341,
                AgeRating = "13",
                Genre = "Action, Sci-Fi, Thriller",
                Language = "English",
                Poster = "",
                ReleaseDate = DateOnly.Parse("07-12-2024"),
                Trailer = "",
                MovieState = 1
            }
            );
            modelBuilder.Entity<Theatre>().HasData(
            new Theatre
            {
                Id = Guid.Parse("612f7744-7535-4ee1-905a-92b8901aee3d"),
                Name = "Abhinav Cinemas",
                Address = "Ujjain road",
                City = "Dewas",
                State = "MP",
                PinCode = "455001"
            },
            new Theatre
            {
                Id = Guid.Parse("13dc6fc9-fb97-4fd6-b700-66f697148447"),
                Name = "Citadel Cinemas",
                Address = "Phoenix Citadel",
                City = "Indore",
                State = "MP",
                PinCode = "244002"
            },
            new Theatre
            {
                Id = Guid.Parse("f16b85a3-8e01-4d23-8335-db615c7beec6"),
                Name = "Sanghavi Cinemas",
                Address = "Ujjain road",
                City = "Dewas",
                State = "MP",
                PinCode = "455001"
            }
            );
        }
    }
    
}
