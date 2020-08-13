import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {AnimalRegisterComponent} from './components/animal-register/animal-register.component';
import {RegistrationComponent} from './components/registration/registration.component';
import {LoginComponent} from './components/login/login.component';
import {AnimalListComponent} from './components/animal-list/animal-list.component';
import {AnimalViewComponent} from '@app/components/animal-view/animal-view.component';

const routes: Routes = [
  {path: 'animal/register', component: AnimalRegisterComponent},
  {path: 'login', component: LoginComponent},
  {path: 'animal/list', component: AnimalListComponent},
  {path: 'register', component: RegistrationComponent},
  {path: 'animal/:id', component: AnimalViewComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
