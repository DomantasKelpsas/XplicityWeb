using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using AnimalShelterAPI.Models;

namespace AnimalShelterAPI.Database
{
    public class DatabaseSeeder
    {
        public static void Initialize(ApiContext context)
        {
            if (!context.AnimalTypes.Any())
                context.AnimalTypes.AddRange(
                    new AnimalType
                    {
                        Name = "Šuo"
                    },
                    new AnimalType
                    {
                        Name = "Katė"
                    }
                );

            if(!context.Genders.Any())
                context.Genders.AddRange(
                    new Gender
                    {
                        Type = "Vyriška"
                    },
                    new Gender
                    {
                        Type = "Moteriška"
                    },
                    new Gender
                    {
                        Type = "Nenustatoma"
                    }
                );

            if (!context.Furs.Any())
                context.Furs.AddRange(
                    new Fur 
                    {
                        Name = "Trumpakailis",
                        Color = "Juodas"
                    },
                    new Fur 
                    {
                        Name = "Šiurkšičplaukis",
                        Color = "Balta"
                    },
                    new Fur
                    {
                        Name = "Vidutinio ilgio",
                        Color = "Ruda"
                    },
                    new Fur
                    {
                        Name = "Ilgaplaukis",
                        Color = "Pilka"
                    }
                );

            if (!context.Statuses.Any())
                context.Statuses.AddRange(
                    new Status
                    {
                        Name = "Atiduotas"
                    },
                    new Status
                    {
                        Name = "Miręs"
                    },
                    new Status
                    {
                        Name = "Gyvena prieglaudoje"
                    }
                );

            if (!context.Animals.Any())
                context.Animals.AddRange(
                    new Animal
                    {
                        AdmissionDate = DateTime.Parse("2020-08-03"),
                        MicrochipIntegrationDate = DateTime.Parse("2020-08-05"),
                        VaccinationDate = DateTime.Parse("2020-08-04"),
                        AdmissionCity = "Kaunas",
                        AdmissionRegion = "Šilainiai",
                        AnimalType = context.AnimalTypes.SingleOrDefault(a => a.Name == "Šuo"),
                        Gender = context.Genders.SingleOrDefault(a => a.Type == "Vyriška"),
                        Fur = context.Furs.SingleOrDefault(a => a.Name == "Vidutinio ilgio"),
                        Status = context.Statuses.SingleOrDefault(a => a.Name == "Atiduotas"),
                        SpecialTags = "Cute, small",
                        HealthCondition = "Sveikas",
                        AdmissionOrganisationContacts = "Tvenkinio g., Sausinės k., Kauno raj.",
                        StatusDate = DateTime.Parse("2020-08-05")
                    },
                    new Animal
                    {
                        AdmissionDate = DateTime.Parse("2020-08-03"),
                        MicrochipIntegrationDate = DateTime.Parse("2020-08-05"),
                        VaccinationDate = DateTime.Parse("2020-08-04"),
                        AdmissionCity = "Vilnius",
                        AdmissionRegion = "Naujamiestis",
                        AnimalType = context.AnimalTypes.SingleOrDefault(a => a.Name == "Katė"),
                        Gender = context.Genders.SingleOrDefault(a => a.Type == "Vyriška"),
                        Fur = context.Furs.SingleOrDefault(a => a.Name == "Ilgaplaukis"),
                        Status = context.Statuses.SingleOrDefault(a => a.Name == "Gyvena prieglaudoje"),
                        SpecialTags = "Fluffy, loud",
                        HealthCondition = "Sveika",
                        AdmissionOrganisationContacts = "Klinikų g. 1, Buivydiškės",
                        StatusDate = null
                    },
                    new Animal
                    {
                        AdmissionDate = DateTime.Parse("2020-08-03"),
                        MicrochipIntegrationDate = null,
                        VaccinationDate = DateTime.Parse("2020-08-04"),
                        AdmissionCity = "Vilnius",
                        AdmissionRegion = "Žirmūnai",
                        AnimalType = context.AnimalTypes.SingleOrDefault(a => a.Name == "Šuo"),
                        Gender = context.Genders.SingleOrDefault(a => a.Type == "Moteriška"),
                        Fur = context.Furs.SingleOrDefault(a => a.Name == "Trumpakailis"),
                        Status = context.Statuses.SingleOrDefault(a => a.Name == "Gyvena prieglaudoje"),
                        SpecialTags = "Goofy, big",
                        HealthCondition = "Sveikas",
                        AdmissionOrganisationContacts = "Antakalnio g. 38, Vilnius",
                        StatusDate = null
                    },
                    new Animal
                    {
                        AdmissionDate = DateTime.Parse("2020-08-03"),
                        MicrochipIntegrationDate = DateTime.Parse("2020-08-05"),
                        VaccinationDate = DateTime.Parse("2020-08-04"),
                        AdmissionCity = "Kaunas",
                        AdmissionRegion = "Vilijampolė",
                        AnimalType = context.AnimalTypes.SingleOrDefault(a => a.Name == "Katė"),
                        Gender = context.Genders.SingleOrDefault(a => a.Type == "Vyriška"),
                        Fur = context.Furs.SingleOrDefault(a => a.Name == "Ilgaplaukis"),
                        Status = context.Statuses.SingleOrDefault(a => a.Name == "Atiduotas"),
                        SpecialTags = "Chubby, sweet",
                        HealthCondition = "Sveika",
                        AdmissionOrganisationContacts = "Tvenkinio g., Sausinės k., Kauno raj.",
                        StatusDate = DateTime.Parse("2020-08-05")
                    },
                    new Animal
                    {
                        AdmissionDate = DateTime.Parse("2020-08-03"),
                        MicrochipIntegrationDate = DateTime.Parse("2020-08-05"),
                        VaccinationDate = null,
                        AdmissionCity = "Kaunas",
                        AdmissionRegion = "Šančiai",
                        AnimalType = context.AnimalTypes.SingleOrDefault(a => a.Name == "Šuo"),
                        Gender = context.Genders.SingleOrDefault(a => a.Type == "Moteriška"),
                        Fur = context.Furs.SingleOrDefault(a => a.Name == "Šiurkšičplaukis"),
                        Status = context.Statuses.SingleOrDefault(a => a.Name == "Gyvena prieglaudoje"),
                        SpecialTags = "Goofy, big",
                        HealthCondition = "Sveikas",
                        AdmissionOrganisationContacts = "Tvenkinio g., Sausinės k., Kauno raj.",
                        StatusDate = null
                    },
                    new Animal
                    {
                        AdmissionDate = DateTime.Parse("2020-08-03"),
                        MicrochipIntegrationDate = DateTime.Parse("2020-08-05"),
                        VaccinationDate = null,
                        AdmissionCity = "Vilnius",
                        AdmissionRegion = "Žirmūnai",
                        AnimalType = context.AnimalTypes.SingleOrDefault(a => a.Name == "Katė"),
                        Gender = context.Genders.SingleOrDefault(a => a.Type == "Vyriška"),
                        Fur = context.Furs.SingleOrDefault(a => a.Name == "Trumpakailis"),
                        Status = context.Statuses.SingleOrDefault(a => a.Name == "Atiduotas"),
                        SpecialTags = "Fluffy, loud",
                        HealthCondition = "Sveika",
                        AdmissionOrganisationContacts = "Antakalnio g. 38, Vilnius",
                        StatusDate = DateTime.Parse("2020-08-05")
                    },
                    new Animal
                    {
                        AdmissionDate = DateTime.Parse("2020-08-03"),
                        MicrochipIntegrationDate = DateTime.Parse("2020-08-05"),
                        VaccinationDate = null,
                        AdmissionCity = "Kaunas",
                        AdmissionRegion = "Šančiai",
                        AnimalType = context.AnimalTypes.SingleOrDefault(a => a.Name == "Šuo"),
                        Gender = context.Genders.SingleOrDefault(a => a.Type == "Moteriška"),
                        Fur = context.Furs.SingleOrDefault(a => a.Name == "Šiurkšičplaukis"),
                        Status = context.Statuses.SingleOrDefault(a => a.Name == "Gyvena prieglaudoje"),
                        SpecialTags = "Overall just great",
                        HealthCondition = "Sveikas",
                        AdmissionOrganisationContacts = "Tvenkinio g., Sausinės k., Kauno raj.",
                        StatusDate = null
                    }, 
                    new Animal
                    {
                        AdmissionDate = DateTime.Parse("2020-08-03"),
                        MicrochipIntegrationDate = DateTime.Parse("2020-08-05"),
                        VaccinationDate = null,
                        AdmissionCity = "Vilnius",
                        AdmissionRegion = "Žirmūnai",
                        AnimalType = context.AnimalTypes.SingleOrDefault(a => a.Name == "Šuo"),
                        Gender = context.Genders.SingleOrDefault(a => a.Type == "Vyriška"),
                        Fur = context.Furs.SingleOrDefault(a => a.Name == "Trumpakailis"),
                        Status = context.Statuses.SingleOrDefault(a => a.Name == "Gyvena prieglaudoje"),
                        SpecialTags = "Cute, small",
                        HealthCondition = "Sveikas",
                        AdmissionOrganisationContacts = "Antakalnio g. 38, Vilnius",
                        StatusDate = null
                    }, 
                    new Animal
                    {
                        AdmissionDate = DateTime.Parse("2020-08-03"),
                        MicrochipIntegrationDate = DateTime.Parse("2020-08-05"),
                        VaccinationDate = null,
                        AdmissionCity = "Kaunas",
                        AdmissionRegion = "Šančiai",
                        AnimalType = context.AnimalTypes.SingleOrDefault(a => a.Name == "Katė"),
                        Gender = context.Genders.SingleOrDefault(a => a.Type == "Moteriška"),
                        Fur = context.Furs.SingleOrDefault(a => a.Name == "Šiurkšičplaukis"),
                        Status = context.Statuses.SingleOrDefault(a => a.Name == "Atiduotas"),
                        SpecialTags = "Goofy, big",
                        HealthCondition = "Sveika",
                        AdmissionOrganisationContacts = "Tvenkinio g., Sausinės k., Kauno raj.",
                        StatusDate = DateTime.Parse("2020-08-05")
                    },
                    new Animal
                    {
                        AdmissionDate = DateTime.Parse("2020-08-03"),
                        MicrochipIntegrationDate = DateTime.Parse("2020-08-05"),
                        VaccinationDate = null,
                        AdmissionCity = "Vilnius",
                        AdmissionRegion = "Žirmūnai",
                        AnimalType = context.AnimalTypes.SingleOrDefault(a => a.Name == "Šuo"),
                        Gender = context.Genders.SingleOrDefault(a => a.Type == "Vyriška"),
                        Fur = context.Furs.SingleOrDefault(a => a.Name == "Vidutinio ilgio"),
                        Status = context.Statuses.SingleOrDefault(a => a.Name == "Gyvena prieglaudoje"),
                        SpecialTags = "Cute, small",
                        HealthCondition = "Sveikas",
                        AdmissionOrganisationContacts = "Antakalnio g. 38, Vilnius",
                        StatusDate = null
                    }
                );

            context.SaveChanges();
        }
    }
}
