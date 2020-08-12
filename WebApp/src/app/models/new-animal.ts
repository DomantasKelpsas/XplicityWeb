import {Fur} from '@app/models/fur';

export class NewAnimal {
  specialID: string;
  admissionDate: Date;
  microchipIntegrationDate: Date;
  vaccinationDate: Date;
  admissionCity: string;
  admissionRegion: string;
  animalType: number;
  gender: number;
  years: number;
  months: number;
  fur: Fur;
  specialTags: string;
  healthCondition: string;
  admissionOrganisationContacts: string;
}
