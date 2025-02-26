import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { ApiService } from '../services/api.service';
import { CryptoService } from '../services/crypto.service';

@Component({
  selector: 'app-create-user',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent {
  userForm: FormGroup;
  message: string = '';

  constructor(private fb: FormBuilder, private apiService: ApiService, private cryptoService: CryptoService) {
    this.userForm = this.fb.group({
      nom: ['', Validators.required],
      prenom: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      motDePasse: ['', [Validators.required, Validators.minLength(6)]],
      applicationId: [0, Validators.required]
    });
  }

  onSubmit() {
    if (this.userForm.valid) {
      let userData = { ...this.userForm.value };
  
      if (userData.applicationId === 1) {
        userData.motDePasse = this.cryptoService.encryptAES(userData.motDePasse);
      } else if (userData.applicationId === 2) {
        userData.motDePasse = this.cryptoService.encryptRSA(userData.motDePasse);
      }
  
      this.apiService.createUser(userData).subscribe({
        next: () => {
          this.message = 'Utilisateur créé avec succès !';
          this.userForm.reset();
        },
        error: (error) => {
          this.message = 'Erreur lors de la création de l\'utilisateur.';
          console.error('Erreur API:', error);
        }
      });
    } else {
      this.message = 'Veuillez remplir tous les champs correctement.';
    }
  }
  
  
  
}
