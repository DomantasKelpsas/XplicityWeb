import {Component, OnInit, ViewChild} from '@angular/core';
import {MatTableDataSource, MatTable} from '@angular/material/table';
import {MatSort} from '@angular/material/sort';
import {Animal} from '@app/models/animal';
import {UserService} from "@app/services/user.service";
import {AnimalService} from '@app/services/animal.service';
import {FormControl, FormGroup, NgForm} from '@angular/forms';
import {Status} from '@app/models/status';
import { Subscription } from 'rxjs';
import {AnimalHubService} from '@app/services/animal-hub.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';


@Component({
  selector: 'app-animal-list',
  templateUrl: './animal-list.component.html',
  styleUrls: ['./animal-list.component.scss']
})
export class AnimalListComponent implements OnInit {

  public StatusEnum = Status;

  constructor(private animalService: AnimalService,
              private animalHub: AnimalHubService,
              private snackBar: MatSnackBar,
              private userService: UserService,
              private router: Router) {
  }

  animal = new Animal();
  animals: Animal[];
  err: string;

  displayedColumns: string[] = ['admissionDate', 'admissionCity', 'animalType', 'gender', 'status'];

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild('animalTable') animalTable: MatTable<Animal>;
  dataSource: MatTableDataSource<Animal>;
  private subscription = new Subscription();

  filterForm = new FormGroup({
    fromDate: new FormControl(),
    toDate: new FormControl(),
  });

  get fromDate() { return this.filterForm.get('fromDate').value; }
  get toDate() { return this.filterForm.get('toDate').value; }

  ngOnInit(): void {
    if (!this.userService.isLoggedIn())
    {
      this.router.navigate(['/login']);
    }
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
    // this.dataSource.filterPredicate = (data: Animal, filter: string) => this.filterPeriod(data, filter);
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
    this.animalHub.disconnect();
  }

  onSubmit(form: NgForm) {
    // form.resetForm();
    console.log(form.value);
  }

  filterAnimals(): void {
    if (this.fromDate && this.toDate) {
      this.animalService.getFilteredAnimals(this.fromDate, this.toDate).subscribe(animals => {
        this.animals = animals;
        this.dataSource.data = this.animals;
        console.log(animals);
      }, error => this.err = error);
    }
  }

  resetAnimalList(): void {
    this.filterForm.reset();
    this.animalService.getAnimals().subscribe(animals => {
      this.animals = animals;
      this.dataSource.data = this.animals;
      console.log(animals);
    }, error => this.err = error);
  }
}
