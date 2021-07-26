using AnimalAPI.BusinessLayer.Interfaces;
using AnimalAPI.Common;
using AnimalAPI.Entities;
using AnimalAPI.Models;
using AnimalAPI.Common.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AnimalAPI.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnimalAPI.BusinessLayer
{
    public class AnimalBll : IAnimalBll
    {
        private readonly AnimalContext _context;

        public AnimalBll(AnimalContext context)
        {
            _context = context;
        }

        public async Task<Response<Animal>> Create(Animal item)
        {
            Animal animal = new();

            try
            {
                if (item.Name.IsValidString() || item.Genre.IsValidString())
                    return new Response<Animal>().FailedModel();

                animal.Name = item.Name;
                animal.Alimentation = item.Alimentation;
                animal.Genre = item.Genre;

                using (var context = _context)
                {
                    await context.Animals.AddAsync(animal);
                    await context.SaveChangesAsync();
                }

                return new Response<Animal>().SuccessModel();
            }
            catch
            {
                return new Response<Animal>().FailedModel();
            }
        }

        public async Task<Response<Animal>> Update(int id, Animal animal)
        {
            try
            {
                if (animal.Id.IsValidId() || animal.Id != id)
                    return new Response<Animal>().FailedModel();

                using (var context = _context)
                {
                    context.Entry(animal).State = EntityState.Modified;

                    await context.SaveChangesAsync();
                }

                return new Response<Animal>().SuccessModel(animal);
            }
            catch
            {
                return new Response<Animal>().FailedModel();
            }
        }

        public async Task<Response<Animal>> Delete(long id)
        {
            Animal animal = new();

            try
            {
                using (var context = _context)
                {
                    animal = await context.Animals.FindAsync(id);

                    if (!animal.Id.IsValidId())
                        return new Response<Animal>().FailedModel();

                    context.Animals.Attach(animal);
                    context.Animals.Remove(animal);

                    await context.SaveChangesAsync();
                }

                return new Response<Animal>().SuccessModel();
            }
            catch
            {
                return new Response<Animal>().FailedModel();
            }
        }

        public async Task<ResponseMany<Animal>> GetAll()
        {
            List<Animal> animals = new();

            try
            {
                using (var context = _context)
                {
                    animals = context.Animals.ToList();

                    if (!animals.Any())
                        return new ResponseMany<Animal>().FailedModel();
                }

                return new ResponseMany<Animal>().SuccessModel(animals);
            }
            catch
            {
                return new ResponseMany<Animal>().FailedModel();
            }
        }

        public async Task<Response<Animal>> GetById(long id)
        {
            Animal animal = new();

            try
            {
                using (var context = _context)
                {
                    animal = context.Animals.SingleOrDefault(a => a.Id == id);

                    if (animal == null)
                        return new Response<Animal>().FailedModel();
                }

                return new Response<Animal>().SuccessModel(animal);
            }
            catch
            {
                return new Response<Animal>().FailedModel();
            }
        }

    }
}
