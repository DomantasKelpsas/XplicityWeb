import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AnimalRegisterComponent} from './components/animal-register/animal-register.component';
import {LoginComponent} from './components/login/login.component';
import {AnimalListComponent} from './components/animal-list/animal-list.component';


const routes: Routes = [
  {path: 'animal-register', component: AnimalRegisterComponent},
  {path: 'login', component: LoginComponent},
  {path: 'animal-list', component: AnimalListComponent}

];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
