export class Animal {

  constructor(animalID: string, dateAccepted: string, dateChiped: string, dateVaccine: string, city: string,
              region: string, type: string, gender: string, ageYear: number, ageMonth: number, furColor: string,
              furLength: string, specialMarks: string, health: string, contactInfo: string, status: number, statusDate: string) {
    this.animalID = animalID;
    this.dateAccepted = dateAccepted;
    this.dateChiped = dateChiped;
    this.dateVaccine = dateVaccine;
    this.city = city;
    this.region = region;
    this.type = type;
    this.gender = gender;
    this.ageYear = ageYear;
    this.ageMonth = ageMonth;
    this.furColor = furColor;
    this.furLength = furLength;
    this.specialMarks = specialMarks;
    this.health = health;
    this.contactInfo = contactInfo;
    this.status = status;
    this.statusDate = statusDate;

  }

  animalID: string;
  dateAccepted: string;
  dateChiped: string;
  dateVaccine: string;
  city: string;
  region: string;
  type: string;
  gender: string;
  ageYear: number;
  ageMonth: number;
  furColor: string;
  furLength: string;
  specialMarks: string;
  health: string;
  contactInfo: string;
  status: number;
  statusDate: string;
}
