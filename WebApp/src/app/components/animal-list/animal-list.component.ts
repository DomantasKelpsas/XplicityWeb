import {Component, OnInit} from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';

export interface PeriodicElement {
  admissionDate: string;
  admissionCity: string;
  animalType: string;
  gender: string;
  status: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {admissionDate: new Date(2017, 4, 4).toLocaleDateString(), admissionCity: 'Kaunas', animalType: 'Kate', gender: 'Vyriska', status: 'Gyvas'},
  {admissionDate: new Date(2017, 4, 4).toLocaleDateString(), admissionCity: 'Vilnius', animalType: 'Kate', gender: 'Vyriska', status: 'Gyvas'},
  {admissionDate: new Date(2018, 4, 4).toLocaleDateString(), admissionCity: 'Kaunas', animalType: 'Kate', gender: 'Vyriska', status: 'Gyvas'},
  {admissionDate: new Date(2017, 4, 4).toLocaleDateString(), admissionCity: 'Kaunas', animalType: 'Kate', gender: 'Vyriska', status: 'Gyvas'}

];


@Component({
  selector: 'app-animal-list',
  templateUrl: './animal-list.component.html',
  styleUrls: ['./animal-list.component.scss']
})
export class AnimalListComponent implements OnInit {
  displayedColumns: string[] = ['admissionDate', 'admissionCity', 'animalType', 'gender', 'status'];
  dataSource = new MatTableDataSource(ELEMENT_DATA);

  constructor() {
  }

  ngOnInit(): void {
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
