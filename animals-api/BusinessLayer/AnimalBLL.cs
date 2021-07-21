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
            try
            {
                Animal animal = null;
                using (var context = _context)
                {
                    if (item.Name.IsValidString() || item.Genre.IsValidString())
                        return new Response<Animal>().FailedModel();

                    animal.Name = item.Name;
                    animal.Alimentation = item.Alimentation;
                    animal.Genre = item.Genre;

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

        public async Task<Response<Animal>> Delete(long id)
        {
            try
            {
                Animal animal = null;

                using (var context = _context)
                {
                    animal = await context.Animals.FindAsync(id);

                    if (!animal.Id.IsValidId())
                        return new Response<Animal>().FailedModel();

                    context.Animals.Attach(animal);
                    context.Animals.Remove(animal);

                    await context.SaveChangesAsync();
                }

                return new Response<Animal>().SuccessModel(animal);
            }
            catch
            {
                return new Response<Animal>().FailedModel();
            }
        }

        public async Task<ResponseMany<Animal>> GetAll()
        {
            try
            {
                using (var context = _context)
                {
                    List<Animal> animals = context.Animals.ToList();

                    if (!animals.Any())
                        return new ResponseMany<Animal>().FailedModel();

                    return new ResponseMany<Animal>().SuccessModel(animals);
                }
            }
            catch
            {
                return new ResponseMany<Animal>().FailedModel();
            }
        }

        public async Task<Response<Animal>> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseMany<Animal>> GetMany(List<Animal> items)
        {
            throw new NotImplementedException();
        }
    }
}
