import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AnimalRegisterComponent} from './components/animal-register/animal-register.component';
import {LoginComponent} from './components/login/login.component';


const routes: Routes = [
  {path: 'animal-register', component: AnimalRegisterComponent},
  {path: 'login', component: LoginComponent}

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
