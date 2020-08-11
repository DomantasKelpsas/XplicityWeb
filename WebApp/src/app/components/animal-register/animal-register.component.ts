import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {FormBuilder, FormGroup, NgForm, Validators} from '@angular/forms';
import {Animal} from '../../models/animal';
import {User} from '@app/models/user';
import {UserService} from '@app/services/user.service';
import {ActivatedRoute, Router} from '@angular/router';
import {AnimalService} from '@app/services/animal.service';

@Component({
  selector: 'app-animal-register',
  templateUrl: './animal-register.component.html',
  styleUrls: ['./animal-register.component.scss']
})
export class AnimalRegisterComponent implements OnInit {

  @Output()
  addButtonClick = new EventEmitter<Animal>();


  selectedValue: string;

  form: FormGroup;
  loading = false;
  submitted = false;
  animal: Animal = new Animal('', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '');

  constructor(
    private animalService: AnimalService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router) {
  }

  ngOnInit(): void {

    this.form = this.formBuilder.group({
      firstName: '',
      lastName: '',
      email: '',
      password: '',
      confirmPassword: ''
    });
  }

  get f() {
    return this.form.controls;
  }

  onAddButtonClick(): void {
    this.addButtonClick.emit(this.animal);
  }

  onSubmit(form: NgForm) {

    this.submitted = true;
    // stop here if form is invalid
    if (this.form.invalid) {
      return;
    }
    this.loading = true;
    this.animal = new Animal(form.value.animalID,);
    // communicate with the api to register the user
    this.animalService.addAnimal(this.animal).subscribe(
      res => {
        console.log('Register works!');
      },
      error => {
        console.log(error);
      });
    console.log(form.value);
  }

}
