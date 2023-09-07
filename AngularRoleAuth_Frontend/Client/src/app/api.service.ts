import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserDto } from './models/userDto';

@Injectable({
  providedIn: 'root'
})


export class ApiService 
{
  private baseUrl = "https://localhost:44387/";

  constructor(private http: HttpClient)  { }

  public login(user: UserDto) : Observable<string>
  {
    var url = this.baseUrl + "api/Auth/Login";
    return this.http.post(url, user, {responseType: 'text'});
  }

  public getMe() : Observable<string> 
  {
    var url = this.baseUrl + "api/Auth/GetMe";
    return this.http.get<string>(url);
  }
}
