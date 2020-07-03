
import { Injectable } from '@angular/core';

@Injectable()
export class AuthService {

    public saveToken(token: string): string {
        localStorage.setItem('bwm_auth', token);
         return token;
      }
    

    public getAuthToken(): string {
        return localStorage.getItem('emr_auth');
    }

}













