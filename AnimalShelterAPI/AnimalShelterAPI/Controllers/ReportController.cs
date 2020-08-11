using AnimalShelterAPI.Infrastructure.Repositories;
using AnimalShelterAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AnimalShelterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeAttr]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;

        public ReportController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        [HttpGet]
        public async Task<ReportDto> Get([FromBody] ReportRequestDto request)
        {
            return await _reportRepository.GetAnimalReport(request.AnimalType, request.Year);
        }
    }
}
