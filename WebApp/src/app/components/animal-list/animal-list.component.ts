import {Component, OnInit, ViewChild} from '@angular/core';
import {MatTableDataSource, MatTable} from '@angular/material/table';
import {MatSort} from '@angular/material/sort';
import {UserService} from '@app/services/user.service';
import {User} from '@app/models/user';
import {Animal} from '@app/models/animal';
import {AnimalService} from '@app/services/animal.service';
import {NgForm} from '@angular/forms';
import {Status} from '@app/models/status';
import { NewAnimal } from '@app/models/new-animal';
import { Subscription } from 'rxjs';
import {AnimalHubService} from '@app/services/animal-hub.service';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-animal-list',
  templateUrl: './animal-list.component.html',
  styleUrls: ['./animal-list.component.scss']
})
export class AnimalListComponent implements OnInit {

  public StatusEnum = Status;

  constructor(private animalService: AnimalService, private animalHub: AnimalHubService, private snackBar: MatSnackBar)
  { }

  animal = new Animal();
  animals: Animal[];
  err: string;

  displayedColumns: string[] = ['admissionDate', 'admissionCity', 'animalType', 'gender', 'status'];

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild('animalTable') animalTable: MatTable<Animal>;
  dataSource: MatTableDataSource<Animal>;
  private subscription = new Subscription();

  ngOnInit(): void {
    this.animalService.getAnimals().subscribe(animals => {
      this.animals = animals;
      this.dataSource = new MatTableDataSource(this.animals);
      console.log(animals);
    }, error => this.err = error);

    const animalHubSubscription = this.animalHub.receiveAnimals().subscribe(
      animal =>
      {
        this.animals.push(animal);
        this.animalTable.renderRows(); // refresh table
        this.snackBar.open(`Pridetas naujas gyvūnas "${animal.specialID}"!`, 'Info', {duration: 3000});
      },
      error =>
      {
        console.error(error);
        this.snackBar.open(`${error.message}`, 'Error', {duration: 5000});
      }
    );

    this.subscription.add(animalHubSubscription);
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
    this.animalHub.disconnect();
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
