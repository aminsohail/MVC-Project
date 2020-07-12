import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../HospitalManagementMasterPage/PatientLogin/PatientLogin.Model';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
    constructor(private _user:User){}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = this._user.token;

    if (token) {
        request = request.clone({
        setHeaders: {
          Authorization: 'Bearer ' +  token
        }
      });
    }

    return next.handle(request);
  }
}
