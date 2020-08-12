using System;

namespace AnimalShelterAPI.Models.DTO
{
    public class AnimalDto
    {
        public int Id { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime? MicrochipIntegrationDate { get; set; }
        public DateTime? VaccinationDate { get; set; }
        public string AdmissionCity { get; set; }
        public string AdmissionRegion { get; set; }
        public AnimalType AnimalType { get; set; }
        public Gender Gender { get; set; }
        public Fur Fur { get; set; }
        public string SpecialTags { get; set; }
        public string HealthCondition { get; set; }
        public string AdmissionOrganisationContacts { get; set; }
        public Status Status { get; set; }
        public DateTime? StatusDate { get; set; }
        public string AnimalAgeCounter { get; set; }
        public string AnimalTimeInShelterCounter { get; set; }
    }
}
