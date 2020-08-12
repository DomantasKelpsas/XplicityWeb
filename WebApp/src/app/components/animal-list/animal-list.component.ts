import {Component, OnInit, ViewChild} from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';
import {MatSort} from '@angular/material/sort';
import {UserService} from '@app/services/user.service';
import {User} from '@app/models/user';
import {Animal} from '@app/models/animal';
import {AnimalService} from '@app/services/animal.service';
import {NgForm} from '@angular/forms';



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
  dataSource: MatTableDataSource<Animal>;


  ngOnInit(): void {
    this.animalService.getAnimals().subscribe(animals => {
      this.animals = animals;
      this.dataSource = new MatTableDataSource(this.animals);
      console.log(animals);
    }, error => this.err = error);


  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  onSubmit(form: NgForm) {
    // form.resetForm();
    console.log(form.value);
  }
}
