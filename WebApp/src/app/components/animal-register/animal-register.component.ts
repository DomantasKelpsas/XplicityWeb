import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {NgForm} from '@angular/forms';
import {Animal} from '../../models/animal';

@Component({
  selector: 'app-animal-register',
  templateUrl: './animal-register.component.html',
  styleUrls: ['./animal-register.component.scss']
})
export class AnimalRegisterComponent implements OnInit {

  @Output()
  addButtonClick = new EventEmitter<Animal>();
  animal = new Animal();

  selectedValue: string;
  constructor() { }

  ngOnInit(): void {
  }

  onAddButtonClick(): void {
    this.addButtonClick.emit(this.animal);
  }

  onSubmit(form: NgForm) {
    // form.resetForm();
    console.log(form.value);
  }

}
