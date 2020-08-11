using AnimalShelterAPI.Infrastructure.Repositories;
using AnimalShelterAPI.Models;
using AnimalShelterAPI.Services.Interfaces;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AnimalShelterAPI.Services
{
    public class ReportService : IReportService
    {
        private readonly IRepository<Animal> _repository;
        //private readonly IReportRepository<Animal> _reportRepository;

        private Dictionary<int, string> TypeToSpelling = new Dictionary<int, string>()
        {
            { 0, "šunų"},
            { 1, "kačių"}
        };

        public ReportService(IRepository<Animal> repository)
        {
            _repository = repository;
        }

        public async Task<MemoryStream> GenerateAdmissionAct(int id)
        {
            string templateFile = "E:\\Dokumentai\\Mokslai\\DevAcadamy2020\\Animal_shelter_app\\chalturcikai\\AnimalShelterAPI\\AnimalShelterAPI\\Report_templates\\gyvuno_priimimo_aktas.docx";
            var animal = await _repository.GetById(id);

            MemoryStream stream = new MemoryStream();
            byte[] fileBytesArray = File.ReadAllBytes(templateFile);
            stream.Write(fileBytesArray, 0, (int)fileBytesArray.Length);
            stream.Position = 0;

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(stream, true))
            {
                string docText = wordDoc.MainDocumentPart.Document.InnerXml;

                docText = new Regex("{priemimo_data}").Replace(docText, animal.AdmissionDate.ToShortDateString());
                docText = new Regex("{skiepo_data}").Replace(docText, animal.VaccinationDate == null ? "-" : animal.VaccinationDate.ToString().Substring(0, 10));
                docText = new Regex("{mikroschemos_data}").Replace(docText, animal.MicrochipIntegrationDate == null ? "-" : animal.MicrochipIntegrationDate.ToString().Substring(0, 10));
                docText = new Regex("{priimta_is}").Replace(docText, animal.AdmissionRegion + ", " + animal.AdmissionCity);
                docText = new Regex("{lytis}").Replace(docText, "vyriška");
                docText = new Regex("{amzius}").Replace(docText, "1 metas, 6 mėn.");
                docText = new Regex("{kailis}").Replace(docText, "Ilgas");
                docText = new Regex("{zyme}").Replace(docText, animal.SpecialTags);
                docText = new Regex("{sveikata}").Replace(docText, animal.HealthCondition);
                docText = new Regex("{kontaktai}").Replace(docText, animal.AdmissionOrganisationContacts);

                wordDoc.MainDocumentPart.Document.InnerXml = docText;
                wordDoc.MainDocumentPart.Document.Save();
            }

            stream.Position = 0;
            return stream;
        }

        public async Task<MemoryStream> GenerateYearReport(int AnimalType, int Year)
        {
            string templateFile = "E:\\Dokumentai\\Mokslai\\DevAcadamy2020\\Animal_shelter_app\\chalturcikai\\AnimalShelterAPI\\AnimalShelterAPI\\Report_templates\\metine_ataskaita.docx";
            //var report = await _repository.GetById(id);

            MemoryStream stream = new MemoryStream();
            byte[] fileBytesArray = File.ReadAllBytes(templateFile);
            stream.Write(fileBytesArray, 0, (int)fileBytesArray.Length);
            stream.Position = 0;

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(stream, true))
            {
                string docText = wordDoc.MainDocumentPart.Document.InnerXml;

                docText = new Regex("{metai}").Replace(docText, Year.ToString());
                docText = new Regex("{gyvuno_tipas}").Replace(docText, TypeToSpelling[AnimalType]);
                docText = new Regex("{data}").Replace(docText, DateTime.Now.ToShortDateString());
                //docText = new Regex("{priimta}").Replace(docText, );
                //docText = new Regex("{padovanota}").Replace(docText, );
                //docText = new Regex("{mirciu}").Replace(docText, );
                //docText = new Regex("{gyvena}").Replace(docText, );

                wordDoc.MainDocumentPart.Document.InnerXml = docText;
                wordDoc.MainDocumentPart.Document.Save();
            }

            //string generatedFile = "E:\\Dokumentai\\Mokslai\\DevAcadamy2020\\Animal_shelter_app\\chalturcikai\\AnimalShelterAPI\\AnimalShelterAPI\\Report_templates\\sugeneruotas_gyvuno_priimimo_aktas.docx";
            //using (FileStream file = new FileStream(generatedFile, FileMode.CreateNew))
            //    stream.WriteTo(file);

            stream.Position = 0;
            return stream;
        }
    }
}
