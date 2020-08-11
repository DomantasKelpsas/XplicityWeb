using AnimalShelterAPI.Models;
using AnimalShelterAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelterAPI.Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ApiContext _context;

        public ReportRepository(ApiContext context)
        {
            _context = context;
        }
        public async Task<ReportDto> GetAnimalReport(int AnimalType, int Year)
        {
            var animals = _context.Animals.Where(x => x.AnimalType == (AnimalType)AnimalType);

            return new ReportDto
            {
                AdmittedCount = animals.Where(x => x.AdmissionDate.Year == Year).Count(),
                GiftedCount = animals.Where(x => x.Status.Name == "Atiduotas" && x.StatusDate != null /*check date*/ ).Count(),
                DeadCount = animals.Where(x => x.Status.Name == "Miręs").Count(),
                LivingNowCount = animals.Where(x => x.Status.Name == "Gyvena prieglaudoje").Count()
            };
        }
    }
}
