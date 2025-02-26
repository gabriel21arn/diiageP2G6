import { Routes } from '@angular/router';
import { PasswordListComponent } from './password-list/password-list.component';
import { CreateUserComponent } from './create-user/create-user.component';

export const routes: Routes = [
  { path: '', redirectTo: '/password-list', pathMatch: 'full' },
  { path: 'password-list', component: PasswordListComponent },
  { path: 'create-user', component: CreateUserComponent },
];
