using System;

namespace AnimalShelterAPI.Models.DTO
{
    public class AnimalListItemDto
    {
        public int Id { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string AdmissionCity { get; set; }
        public string AdmissionRegion { get; set; }
        public AnimalType AnimalType { get; set; }
        public Gender Gender { get; set; }
        public Status Status { get; set; }
        public DateTime? StatusDate { get; set; }
    }
}
