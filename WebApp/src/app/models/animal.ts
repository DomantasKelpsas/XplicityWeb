import {Fur} from '@app/models/fur';

export class Animal {
  id: number;
  specialID: string;
  admissionDate: Date;
  microchipIntegrationDate: Date;
  vaccinationDate: Date;
  admissionCity: string;
  admissionRegion: string;
  animalType: number;
  birthday: Date;
  months: number;
  fur: Fur;
  specialTags: string;
  healthCondition: string;
  admissionOrganisationContacts: string;
}
