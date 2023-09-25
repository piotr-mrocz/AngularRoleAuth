import { Component } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-get-me',
  templateUrl: './get-me.component.html',
  styleUrls: ['./get-me.component.css']
})

export class GetMeComponent 
{
  constructor(private apiService: ApiService) { }

  public getMe()
  {
    this.apiService.getMe().subscribe((name: string) => {
      console.log(name);
    });
  }
}
