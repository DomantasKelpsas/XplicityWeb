using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalShelterAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimalShelterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly ApiContext context;

        public AnimalsController(ApiContext _context)
        {
            context = _context;
        }

        // GET: api/Animals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> Get()
        {
            return await context.Animals.ToListAsync();
        }

        // GET api/Animals/5
        [HttpGet("{id}", Name = "GetAnimal")]
        public async Task<ActionResult<Animal>> Get(int id)
        {
            return await context.Animals.FirstOrDefaultAsync(x => x.ID == id);
        }

        // POST api/Animals
        [HttpPost]
        public async Task<ActionResult<Animal>> Post([FromBody] Animal animal)
        {
            var a = context.Animals.Add(animal);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetAnimal", new { id = animal.ID }, animal);
        }

        // PUT api/Animals/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] Animal animal)
        {
            if (animal == null) throw new ArgumentNullException(nameof(animal));

            var itemToUpdate = await context.Animals.FirstOrDefaultAsync(x => x.ID == id);
            if (itemToUpdate == null)
            {
                throw new InvalidOperationException($"Product {id} was not found");
            }

            //context.Animals.Attach(animal);
            await context.SaveChangesAsync();
        }

        // DELETE api/<AnimalsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Animal>> Delete(int id)
        {
            var animal = await context.Animals.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            context.Animals.Remove(animal);
            await context.SaveChangesAsync();

            return animal;
        }
    }
}
