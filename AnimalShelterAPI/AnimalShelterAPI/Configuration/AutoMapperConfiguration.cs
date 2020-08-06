using System;
using AnimalShelterAPI.Models;
using AnimalShelterAPI.Models.DTO;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        }
    }
}
