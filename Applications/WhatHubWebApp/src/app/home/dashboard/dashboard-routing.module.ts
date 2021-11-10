import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomePageComponent } from '../home-page/home-page.component';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';


const routes: Routes = [
  {
    path: 'dashboard',
    component: HomePageComponent,
    children: [
      { path: '', component: DashboardComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
