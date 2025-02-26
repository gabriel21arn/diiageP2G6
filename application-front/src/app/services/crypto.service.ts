import { Injectable } from '@angular/core';
import * as CryptoJS from 'crypto-js';
import { JSEncrypt } from 'jsencrypt';

@Injectable({
  providedIn: 'root'
})
export class CryptoService {
  private secretKeyAES = 'MaCleSecreteAES';

  private publicKeyRSA = `-----BEGIN PUBLIC KEY-----
MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAslB3d....TON_PUBLIC_KEY
-----END PUBLIC KEY-----`;

  encryptAES(value: string): string {
    return CryptoJS.AES.encrypt(value, this.secretKeyAES).toString();
  }

  encryptRSA(value: string): string {
    const encryptor = new JSEncrypt();
    encryptor.setPublicKey(this.publicKeyRSA);
    return encryptor.encrypt(value) || '';
  }
}
