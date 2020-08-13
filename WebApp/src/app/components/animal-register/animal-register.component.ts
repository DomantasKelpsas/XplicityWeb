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
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-animal-register',
  templateUrl: './animal-register.component.html',
  styleUrls: ['./animal-register.component.scss']
})
export class AnimalRegisterComponent implements OnInit {


  @Output()
  addButtonClick = new EventEmitter<NewAnimal>();
  animal: NewAnimal = new NewAnimal();
  fur: Fur = new Fur();
  selectedValue: string;

  constructor(private animalService: AnimalService,
              private animalHub: AnimalHubService,
              private snackBar: MatSnackBar,
              private userService: UserService,
              private router: Router) {
  }

  ngOnInit(): void {
    if (!this.userService.isLoggedIn())
    {
      this.router.navigate(['/login'])
    }
    this.animal.fur = this.fur;
  }

  onAddButtonClick(): void {
     this.addButtonClick.emit(this.animal);

    this.animalService.addAnimal(this.animal)
      .subscribe(savedAnimal =>
      {
        console.log(savedAnimal);
        this.animalHub.sendAnimal(savedAnimal);
      },
      error =>
      {
        this.snackBar.open(`${error.message}`, 'Error', {duration: 5000});
        console.log(error);
      });
  }

  onSubmit(form: NgForm) {
    // form.resetForm();
    console.log(this.animal);
    this.animalService.addAnimal(this.animal).subscribe(
      res => {
        console.log('animal register works!');
      },
      error => {
        console.log(error);
      });
  }


}
