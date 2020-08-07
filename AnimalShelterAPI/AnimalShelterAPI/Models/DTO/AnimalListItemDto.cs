using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelterAPI.Models.DTO
{
    public class AnimalListItemDto
    {
        public DateTime AdmissionDate { get; set; }
        public DateTime? MicrochipIntegrationDate { get; set; }
        public DateTime? VaccinationDate { get; set; }
        public string AdmissionCity { get; set; }
        public string AdmissionRegion { get; set; }
        public AnimalType AnimalType { get; set; }
        public Gender Gender { get; set; }
        public Status Status { get; set; }
        public DateTime? StatusDate { get; set; }
    }
}
