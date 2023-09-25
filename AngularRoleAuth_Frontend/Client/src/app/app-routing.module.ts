import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { GetMeComponent } from './components/get-me/get-me.component';
import { TasksComponent } from './components/tasks/tasks.component';
import { AdminLayoutComponent } from './components/layouts/admin-layout/admin-layout.component';

const routes: Routes = 
[
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { 
    path: 'Dashboard', 
    component: AdminLayoutComponent,
    children:
    [
      { path: 'get-me', component: GetMeComponent },
      { path: 'tasks', component: TasksComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
