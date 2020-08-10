import {Component, OnInit} from '@angular/core';
import {HeaderServiceService} from '@app/services/header-service.service';
import {HeaderComponent} from '@app/components/header/header.component';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.scss']
})
export class LandingPageComponent implements OnInit {
  constructor() {
  }

  ngOnInit(): void {
  }

}
