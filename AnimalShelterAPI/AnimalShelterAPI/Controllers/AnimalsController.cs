using System;
using System.Threading.Tasks;
using AnimalShelterAPI.Constants;
using AnimalShelterAPI.Models;
using AnimalShelterAPI.Models.DTO;
using AnimalShelterAPI.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimalShelterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeAttr]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalsController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        // GET: api/Animals
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var animals = await _animalService.GetAll();
            return Ok(animals);
        }

        // GET api/Animals/5
        [HttpGet("{id}", Name = "GetAnimal")]
        public async Task<IActionResult> Get(int id)
        {
            var animal = await _animalService.GetById(id);
            if (animal == null)
            {
                return NotFound();
            }

            return Ok(animal);

        }

        // POST api/Animals
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AnimalDto newAnimal)
        {
            AnimalDto createdAnimal = await _animalService.Create(newAnimal);
            var animalUri = CreateResourceUri(createdAnimal.Id);
            return Created(animalUri, createdAnimal);
        }

        private Uri CreateResourceUri(int id)
        {
            // ReSharper disable once RedundantAnonymousTypePropertyName
            return new Uri(Url.Link(nameof(RoutingEnum.GetAnimal), new { id = id }));
        }


        // PUT api/Animals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AnimalDto newAnimal)
        {
            await _animalService.Update(id, newAnimal);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<AnimalDto> patch)
        {
            await _animalService.PartialUpdate(id, patch);

            return NoContent();
        }

        // DELETE api/<AnimalsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Animal>> Delete(int id)
        {
            await _animalService.Delete(id);

            return NoContent();
        }
    }
}
