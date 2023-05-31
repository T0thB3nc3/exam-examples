using Jedlik.EntityFramework.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szinkronstudio.Data
{
    public class MovieContext: JedlikDbContext
    {
        public DbSet<MovieModel> Versenyzok { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conString = "Server=localhost;database=szinkronstudio;uid=root;pwd=;";
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql(conString, ServerVersion.AutoDetect(conString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoryModel>().HasData
                (
                    new CategoryModel() { Id=1, Name="Romantic"},
                    new CategoryModel() { Id=2, Name="Sci-Fi"},
                    new CategoryModel() { Id=3, Name="Action"},
                    new CategoryModel() { Id=4, Name="Comedy"},
                    new CategoryModel() { Id=5, Name="Documentary"},
                    new CategoryModel() { Id=6, Name="Cartoon"}
                );

            modelBuilder.Entity<MovieModel>().HasData
                (
                    new MovieModel() { Id="2020/15", Title="Johnny and the Two A**holes", Length=126, DubProducer="John Doe", CategoryId=4},
                    new MovieModel() { Id = "1998/315", Title = "Nature of Harambe", Length = 234, DubProducer = "Ben Dover", CategoryId = 5 },
                    new MovieModel() { Id = "1972/521", Title = "Space Amoeba", Length = 79, DubProducer = "Bull Shark Testosterone", CategoryId = 2 },
                    new MovieModel() { Id = "2004/032", Title = "Gangs of the Grove Street", Length = 96, DubProducer = "Carl Johnson", CategoryId = 3 },
                    new MovieModel() { Id = "1920/915", Title = "My Fellow Jonathan", Length = 135, DubProducer = "Adolf Stalin", CategoryId = 1 },
                    new MovieModel() { Id = "2020/14", Title = "Mickey and the Nazis", Length = 71, DubProducer = "US Government", CategoryId = 6 }
                );
        }
    }
}
