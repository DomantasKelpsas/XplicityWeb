﻿using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnimalShelterAPI.Services.Interfaces
{
    public interface IReportService
    {
        Task<HttpResponseMessage> GenerateAdmissionAct(int id);
        //FileResult GenerateYearReport(string AnimalType);
    }
}
