import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AnimalRegisterComponent} from './components/animal-register/animal-register.component';


const routes: Routes = [
  {path: 'animal-register', component: AnimalRegisterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
