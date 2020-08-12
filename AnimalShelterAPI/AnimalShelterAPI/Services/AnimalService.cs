using AnimalShelterAPI.Infrastructure.Repositories;
using AnimalShelterAPI.Models;
using AnimalShelterAPI.Models.DTO;
using AnimalShelterAPI.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalShelterAPI.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IRepository<Animal> _repository;
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;
        //private readonly ITimeService _timeService;

        public AnimalService(IRepository<Animal> repository,
            IStatusRepository statusRepository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _statusRepository = statusRepository;
        }

        public async Task<NewAnimalDto> GetById(int id)
        {
            var animal = await _repository.GetById(id);
            var animalDto = _mapper.Map<NewAnimalDto>(animal);

            animalDto.AnimalTimeInShelterCounter = FormatAnimalAge((DateTime.Today - animal.AdmissionDate).TotalDays);
            if (animal.Status.Name != "Miręs")
            {
                var CalculationDate = animal.Birthday == null ? animal.AdmissionDate : animal.Birthday.Value;

                if (animal.Status.Name == "Atiduotas")
                    animalDto.AnimalAgeCounter = "Gyvūno amžius, kai jis išvyko iš prieglaudos: " + FormatAnimalAge((animal.StatusDate.Value - CalculationDate).TotalDays);
                else
                    animalDto.AnimalAgeCounter = FormatAnimalAge((DateTime.Now - CalculationDate).TotalDays);
            }
            else
                animalDto.AnimalAgeCounter = FormatAnimalAge((DateTime.Now - animal.StatusDate.Value).TotalDays);

            return animalDto;
        }

        public async Task<ICollection<AnimalListItemDto>> GetAll()
        {
            var animals = await _repository.GetAll();
            var animalDto = _mapper.Map<AnimalListItemDto[]>(animals);
            return animalDto;
        }

        public async Task<AnimalDto> Create(NewAnimalDto newItem)
        {
            if (newItem == null) throw new ArgumentNullException(nameof(newItem));

            var animal = await CreateAnimalPoco(newItem);
            await _repository.Create(animal);

            var animalDto = _mapper.Map<AnimalDto>(animal);
            return animalDto;
        }

        public async Task Update(int id, NewAnimalDto updateData)
        {
            if (updateData == null) throw new ArgumentNullException(nameof(updateData));

            var itemToUpdate = await _repository.GetById(id);
            if (itemToUpdate == null)
            {
                throw new InvalidOperationException($"Animal {id} was not found");
            }

            //var modificationDate = _timeService.GetCurrentTime();
            _mapper.Map(updateData, itemToUpdate);
            //itemToUpdate.LastModified = modificationDate;
            await _repository.Update(itemToUpdate);
        }

        public async Task<bool> PartialUpdate(int id, JsonPatchDocument<NewAnimalDto> itemPatch)
        {
            if (itemPatch == null) throw new ArgumentNullException(nameof(itemPatch));

            var itemToUpdate = await _repository.GetById(id);
            if (itemToUpdate == null)
            {
                throw new InvalidOperationException($"Animal {id} was not found");
            }

            // this is recomended way from microsoft if you don't have domain model
            //var modificationDate = _timeService.GetCurrentTime();
            var updateData = _mapper.Map<NewAnimalDto>(itemToUpdate);
            itemPatch.ApplyTo(updateData);
            _mapper.Map(updateData, itemToUpdate);
            //itemToUpdate.LastModified = modificationDate;
            var updated = await _repository.Update(itemToUpdate);
            return updated;
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _repository.GetById(id);
            if (item == null)
            {
                return false;
            }

            var deleted = await _repository.Delete(item);
            return deleted;
        }

        private async Task<Animal> CreateAnimalPoco(NewAnimalDto newItem)
        {
            //var creationDate = _timeService.GetCurrentTime();
            var animal = _mapper.Map<Animal>(newItem);
            animal.Status = await _statusRepository.InShelterStatus;
            animal.StatusDate = DateTime.Now;
            //animal.LastModified = creationDate;
            //animal.Created = creationDate;
            return animal;
        }

        private string FormatAnimalAge(double DayCount)
        {
            double years = Math.Truncate(DayCount / 365);
            double months = Math.Truncate((DayCount % 365) / 30);
            double days = Math.Truncate((DayCount % 365) % 30);
            return string.Format("{0} metai {1} mėnesių {2} dienų", years, months, days);
        }
    }
}
