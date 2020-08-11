import {Component, OnInit, ViewChild} from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';
import {MatSort} from '@angular/material/sort';
import {UserService} from '@app/services/user.service';
import {User} from '@app/models/user';
import {Animal} from '@app/models/animal';
import {AnimalService} from '@app/services/animal.service';

export interface PeriodicElement {
  admissionDate: string;
  admissionCity: string;
  animalType: string;
  gender: string;
  status: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {
    admissionDate: new Date(2017, 4, 4).toLocaleDateString(),
    admissionCity: 'Kaunas',
    animalType: 'Katė',
    gender: 'Vyriška',
    status: 'Gyvas'
  },
  {
    admissionDate: new Date(2017, 4, 4).toLocaleDateString(),
    admissionCity: 'Vilnius',
    animalType: 'Katė',
    gender: 'Vyriška',
    status: 'Gyvas'
  },
  {
    admissionDate: new Date(2018, 4, 4).toLocaleDateString(),
    admissionCity: 'Kaunas',
    animalType: 'Katė',
    gender: 'Vyriška',
    status: 'Gyvas'
  },
  {
    admissionDate: new Date(2017, 4, 4).toLocaleDateString(),
    admissionCity: 'Kaunas',
    animalType: 'Katė',
    gender: 'Vyriška',
    status: 'Gyvas'
  }

];


@Component({
  selector: 'app-animal-list',
  templateUrl: './animal-list.component.html',
  styleUrls: ['./animal-list.component.scss']
})
export class AnimalListComponent implements OnInit {


  constructor(private animalService: AnimalService) {
  }

  animal = new Animal();
  animals: Animal[];
  err: string;

  displayedColumns: string[] = ['admissionDate', 'admissionCity', 'animalType', 'gender', 'status'];

  @ViewChild(MatSort) sort: MatSort;

  dataSource = new MatTableDataSource(this.animals);


  ngOnInit(): void {
    this.animalService.getAnimals().subscribe(animals => {
      this.animals = animals;
      console.log(animals);
    }, error => this.err = error);


  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
}
