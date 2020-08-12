using AnimalShelterAPI.Models;
using AnimalShelterAPI.Models.DTO;
using AutoMapper;

namespace AnimalShelterAPI.Configuration
{
    public class AutoMapperConfiguration : Profile 
    {
        public AutoMapperConfiguration() : this("AnimalShelterApi")
        {

        }

        protected AutoMapperConfiguration(string name): base(name)
        {
            CreateMap<Animal, AnimalDto>();
            CreateMap<AnimalDto, Animal>();
            CreateMap<Animal, AnimalListItemDto>();
            CreateMap<Animal, NewAnimalDto>();
            CreateMap<NewAnimalDto, Animal>();
        }
    }
}
