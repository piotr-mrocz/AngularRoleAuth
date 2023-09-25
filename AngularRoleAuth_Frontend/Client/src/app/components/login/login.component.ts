import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserDto } from 'src/app/models/userDto';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})


export class LoginComponent 
{
  public user = new UserDto();

  constructor(private apiService: ApiService, private router: Router) { }

  public login(user: UserDto) 
  {
    this.apiService.login(user).subscribe((token: string) => 
    {
      var role = this.getUserRole(token);
      localStorage.setItem('token', token);
      this.router.navigateByUrl("Dashboard");
    });
  }

  private getUserRole(token: string) : string | null
  {
    if (token != null && token.length != 0) 
    {
      var extractedToken = token.split('.')[1];
      var atobToken = atob(extractedToken);
      var finalData = JSON.parse(atobToken);

      return finalData[Object.keys(finalData)[2]];
    }

    return null;
  }

  public logout()
  {
    localStorage.removeItem('token');
  }
}
