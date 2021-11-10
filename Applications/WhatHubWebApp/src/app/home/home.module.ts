import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomePageComponent } from './home-page/home-page.component';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HeaderComponent } from './home-page/header/header.component';
import { ContentComponent } from './home-page/content/content.component';
import { ModuleHeaderComponent } from './home-page/header/module-header/module-header.component';
import { PostListComponent } from './home-page/content/post-list/post-list.component';
import { PostComponent } from './home-page/content/post-list/post/post.component';
import { PostDetailComponent } from './home-page/content/post-list/post/post-detail/post-detail.component';
import { AppRoutingModule } from '../app-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';

@NgModule({
  declarations: [
    HomePageComponent,
    HeaderComponent,
    ContentComponent,
    ModuleHeaderComponent,
    PostListComponent,
    PostComponent,
    PostDetailComponent,
    DashboardComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatIconModule,
    MatProgressSpinnerModule,
    FlexLayoutModule,
    AppRoutingModule
  ],
})
export class HomeModule { }
