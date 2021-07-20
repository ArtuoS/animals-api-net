using AnimalAPI.BusinessLayer.Interfaces;
using AnimalAPI.Common;
using AnimalAPI.Entities;
using AnimalAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace AnimalAPI.BusinessLayer
{
    public class AnimalBLL : IAnimalBLL
    {
        private readonly AnimalContext _context;

        public AnimalBLL(AnimalContext context)
        {
            _context = context;
        }

        public async Task<Response<Animal>> Create(Animal item)
        {
            try
            {
                using (var context = _context)
                {
                    Animal animal = new Animal()
                    {
                        Name = item.Name,
                        Alimentation = item.Alimentation,
                        Genre = item.Genre
                    };

                    await _context.Animals.AddAsync(animal);
                    await _context.SaveChangesAsync();
                }

                return new Response<Animal>()
                {
                    Success = true
                };
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Response<Animal>> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseMany<Animal>> GetAll()
        {
            throw new NotImplementedException();
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
