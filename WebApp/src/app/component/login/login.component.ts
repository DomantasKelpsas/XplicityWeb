import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import {User} from '../../model/user';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  @Output()
  loginButtonClick = new EventEmitter<User>();

  user = new User();

  constructor() { }

  onLoginButtonClick(): void {
    this.loginButtonClick.emit(this.user);
  }

  onSubmit(form: NgForm): void {
    // connect with back-end, validate and re-route?
  }

  ngOnInit(): void {
  }

}
