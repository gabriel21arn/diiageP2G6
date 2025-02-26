import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-password-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './password-list.component.html',
  styleUrls: ['./password-list.component.css']
})
export class PasswordListComponent implements OnInit {
  passwords: string[] = [];
  private apiUrl = 'passwords';

  constructor(private apiService: ApiService) {}

  ngOnInit() {
    this.apiService.getData<{ password: string }[]>(this.apiUrl).subscribe(
      data => {
        this.passwords = data.map(item => item.password);
      },
      error => {
        console.error('Erreur lors de la récupération des mots de passe', error);
      }
    );
  }
}
