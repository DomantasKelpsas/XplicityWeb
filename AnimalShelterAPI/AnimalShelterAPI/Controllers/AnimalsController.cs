using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
    //[AuthorizeAttr]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalService _animalService;
        private readonly IReportService _reportService;

        public AnimalsController(IAnimalService animalService, IReportService reportService)
        {
            _animalService = animalService;
            _reportService = reportService;
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

        [HttpGet("Act/{id}")]
        public async Task<IActionResult> GetAdmissionAct(int id)
        {
            Stream act = await _reportService.GenerateAdmissionAct(id);

            if (act == null)
                return NotFound();

            return File(act, "application/octet-stream", "generated_act.docx");
        }

        //[HttpGet("Report/{id}")]
        //public async Task<IActionResult> GetAnimalReport(int AnimalType, int Year)
        //{
        //    Stream report = await _reportService.GenerateYearReport(AnimalType, Year);

        //    if (report == null)
        //        return NotFound();

        //    return File(report, "application/octet-stream", "generated_report.docx");
        //}
    }
}
