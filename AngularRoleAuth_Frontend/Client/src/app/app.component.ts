import { Component } from '@angular/core';
import { ApiService } from './services/api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent 
{
  title = 'Client';

  constructor(private apiService: ApiService) { }

  public getMe()
  {
    this.apiService.getMe().subscribe((name: string) => {
      console.log(name);
    });
  }
}
