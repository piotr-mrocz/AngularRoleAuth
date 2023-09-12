import { Component } from '@angular/core';
import { ApiService } from './api.service';
import { UserDto } from './models/userDto';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent 
{
  title = 'Client';
  public user = new UserDto();

  constructor(private apiService: ApiService) { }

  public login(user: UserDto) 
  {
    this.apiService.login(user).subscribe((token: string) => {
      localStorage.setItem('token', token);
    });
  }

  public getMe()
  {
    this.apiService.getMe().subscribe((name: string) => {
      console.log(name);
    });
  }

  public logout()
  {
    localStorage.removeItem('token');
  }
}
