import { Component } from '@angular/core';
import { PasswordListComponent } from './password-list/password-list.component';
import { CreateUserComponent } from './create-user/create-user.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [PasswordListComponent, CreateUserComponent],
  templateUrl: './app.component.html',
})
export class AppComponent {}
