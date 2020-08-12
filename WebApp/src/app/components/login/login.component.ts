import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import {User} from '../../models/user';
import {FormBuilder, FormGroup, NgForm, Validators} from '@angular/forms';
import {UserService} from '../../services/user.service';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  @Output()
  loginButtonClick = new EventEmitter<User>();
  form: FormGroup;
  submitted = false;
  errorMessage: string;
  user = new User('', '');

  constructor(private userService: UserService,
              private formBuilder: FormBuilder) {
  }

  onLoginButtonClick(): void {
    this.loginButtonClick.emit(this.user);
    this.userService.isLoggedIn();
  }

  get f() {
    return this.form.controls;
  }

  onSubmit(): void {
    // connect with back-end, validate and re-route?
    this.submitted = true;
    this.userService.loginUser(this.user).subscribe(
      res => {
        console.log('Logged in!');
      },
      error => {
        console.log(error);
        this.errorMessage = error.title ?? error.details ?? error.message ?? '';
      });
  }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      email: ['', Validators.compose([Validators.required, Validators.email])],
      password: ['', [Validators.required]]
    });
  }
}
