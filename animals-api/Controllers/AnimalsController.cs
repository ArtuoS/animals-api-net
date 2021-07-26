using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalAPI.Entities;
using AnimalAPI.Models;
using AnimalAPI.BusinessLayer.Interfaces;
using AnimalAPI.BusinessLayer;

namespace AnimalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly AnimalContext _context;
        private readonly IAnimalBll _animalBll;

        public AnimalsController(AnimalContext context, IAnimalBll animalBll)
        {
            _context = context;
            _animalBll = animalBll;
        }

        // GET: api/Animals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals()
        {
            var response = await _animalBll.GetAll();

            if (response.Data.Any())
            {
                return new JsonResult(response.Data);
            }

            return BadRequest();
        }

        // GET: api/Animals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
            var response = await _animalBll.GetById(id);

            if (response == null)
            {
                return NotFound();
            }

            return new JsonResult(response.Data);
        }

        // PUT: api/Animals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimal(int id, Animal animal)
        {
            if (id != animal.Id)
            {
                return BadRequest();
            }

            _context.Entry(animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            await _animalBll.Update(id, animal);

            return NoContent();
        }

        // POST: api/Animals
        [HttpPost]
        public async Task<ActionResult<Animal>> PostAnimal([FromBody] Animal animal)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                await _animalBll.Create(animal);
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/Animals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Animal>> DeleteAnimal(int id)
        {
            var response = await _animalBll.Delete(id);

            if (!response.Success)
            {
                return NotFound();
            }

            return Ok();
        }

        private bool AnimalExists(int id)
        {
            return _context.Animals.Any(e => e.Id == id);
        }
    }
}
