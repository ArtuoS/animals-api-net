using AnimalAPI.Entities;
using AnimalAPI.Enumerators;
using AnimalAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI
{
    public class DataGenerator
    {
        protected DataGenerator() {}

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AnimalContext(serviceProvider.GetRequiredService<DbContextOptions<AnimalContext>>()))
            {
                context.Animals.AddRange(AnimalFactory());
                context.SaveChangesAsync();
            }
        }

        private static List<Animal> AnimalFactory()
        {
            return new List<Animal>()
            {
                new Animal()
                {
                    Id = 1,
                    Name = "Lion",
                    Genre = "M",
                    Alimentation = EAnimalAlimentation.Carnivore
                },
                new Animal()
                {
                    Id = 2,
                    Name = "Panda",
                    Genre = "F",
                    Alimentation = EAnimalAlimentation.Herbivore
                },
                new Animal()
                {
                    Id = 3,
                    Name = "Tiger",
                    Genre = "M",
                    Alimentation = EAnimalAlimentation.Carnivore
                }
            };
        }
    }
}
