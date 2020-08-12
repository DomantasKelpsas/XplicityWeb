import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, NgForm, Validators} from '@angular/forms';
import {Animal} from '../../models/animal';
import {User} from '@app/models/user';
import {UserService} from '@app/services/user.service';
import {ActivatedRoute, Router} from '@angular/router';
import {AnimalService} from '@app/services/animal.service';
import {NewAnimal} from '@app/models/new-animal';
import {Fur} from '@app/models/fur';

@Component({
  selector: 'app-animal-register',
  templateUrl: './animal-register.component.html',
  styleUrls: ['./animal-register.component.scss']
})
export class AnimalRegisterComponent implements OnInit {


  @Output()
  addButtonClick = new EventEmitter<NewAnimal>();
  // animal: Animal = new Animal('', '', '', '',
  //   '', '', '', '', 0, 0, '', '',
  //   '', '', '', 0, '');
  animal: NewAnimal = new NewAnimal();
  fur: Fur = new Fur();
  selectedValue: string;

  constructor(private animalService: AnimalService) {
  }

  ngOnInit(): void {
    this.animal.fur = this.fur;
  }

  onAddButtonClick(): void {
     this.addButtonClick.emit(this.animal);
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
