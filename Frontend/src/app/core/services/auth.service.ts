import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginInfo } from '../models/loginInfo';
import { environment } from 'src/env/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = `${environment.apiUrl}/Auth`;

  constructor(private http: HttpClient) { }

  login(request: LoginInfo): Observable<any> {
    console.log("u servcisu sam");
    console.log(request.email);
    console.log(request.password);
    return this.http.post<any>(`${this.apiUrl}/login`, request);
  }

}
