import {Component, OnInit} from '@angular/core';
import {UserService} from '@app/services/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(private userService: UserService) {
  }


  ngOnInit(): void {
  }
  onLogout(): void {
    this.userService.logout();
  }
  checkLogin(): boolean {
    return this.userService.isLoggedIn();
  }

}