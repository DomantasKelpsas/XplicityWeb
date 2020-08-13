import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, NgForm, Validators} from '@angular/forms';
import {Animal} from '../../models/animal';
import {User} from '@app/models/user';
import {UserService} from '@app/services/user.service';
import {ActivatedRoute, Router} from '@angular/router';
import {AnimalService} from '@app/services/animal.service';
import {NewAnimal} from '@app/models/new-animal';
import {Fur} from '@app/models/fur';
import {AnimalHubService} from '@app/services/animal-hub.service';
import {MatSnackBar} from '@angular/material/snack-bar';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import citiesJson from '@app/models/cities.json' ;
import {FurType} from '@app/models/fyrType';


@Component({
  selector: 'app-animal-register',
  templateUrl: './animal-register.component.html',
  styleUrls: ['./animal-register.component.scss']
})


export class AnimalRegisterComponent implements OnInit {

  public FurTypeEnum = FurType;

  @Output()
  addButtonClick = new EventEmitter<NewAnimal>();
  animal: NewAnimal = new NewAnimal();
  selectedValue: string;
  cities = JSON.parse(JSON.stringify(citiesJson));


  constructor(private animalService: AnimalService, private animalHub: AnimalHubService, private snackBar: MatSnackBar) {
  }

  ngOnInit(): void {
    console.log(this.cities);
  }

  onAddButtonClick(): void {
    this.addButtonClick.emit(this.animal);
    console.log(this.animal);

    this.animalService.addAnimal(this.animal)
      .subscribe(savedAnimal => {
          console.log(savedAnimal);
          this.animalHub.sendAnimal(savedAnimal);
        },
        error => {
          this.snackBar.open(`${error.message}`, 'Error', {duration: 5000});
          console.log(error);
        });
  }



  onSubmit(form: NgForm) {
    // // form.resetForm();
    // console.log(this.animal);
    // this.animalService.addAnimal(this.animal).subscribe(
    //   res => {
    //     console.log('animal register works!');
    //   },
    //   error => {
    //     console.log(error);
    //   });
  }


}
