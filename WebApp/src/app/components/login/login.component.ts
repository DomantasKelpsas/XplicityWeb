import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import {User} from '../../models/user';
import {NgForm} from '@angular/forms';
import {UserService} from '../../services/user.service';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  @Output()
  loginButtonClick = new EventEmitter<User>();

  errorMessage: string;
  user = new User();

  constructor(private userService: UserService) { }

  onLoginButtonClick(): void {
    this.loginButtonClick.emit(this.user);
  }

  onSubmit(form: NgForm): void {
    // connect with back-end, validate and re-route?
    this.userService.loginUser(this.user).subscribe(
      res => {
        console.log('Logged in!');
      },
      error =>
      {
        console.log(error);
        this.errorMessage = error.title ?? error.details ?? error.message ?? '';
      });
  }

  ngOnInit(): void {
  }

}
