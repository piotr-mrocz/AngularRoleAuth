import { Component } from '@angular/core';
import { BookingConst } from 'src/app/consts/booking-consts';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  styleUrls: ['./admin-layout.component.css']
})

export class AdminLayoutComponent 
{
  menus: any = [];
  role: string = '';
  fiteredMenus: any [] = [];

  constructor() 
  {
    this.menus = BookingConst.menus;
    this.role = this.getUserRole(localStorage.getItem('token'));

    this.menus.forEach((element: any) => 
    {
      const isRolePresent = element.roles.find((role: any) => role == this.role);

      if (isRolePresent != undefined)
      {
        this.fiteredMenus.push(element);
      }
    });
  
  }

  private getUserRole(token: string | null) : string
  {
    token = token != null ? token : '';
    var extractedToken = token.split('.')[1];
    var atobToken = atob(extractedToken);
    var finalData = JSON.parse(atobToken);

    return finalData[Object.keys(finalData)[2]];
  }
}