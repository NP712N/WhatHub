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

@NgModule({
  declarations: [
    HomePageComponent,
    HeaderComponent,
    ContentComponent,
    ModuleHeaderComponent,
    PostListComponent,
    PostComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatIconModule,
    MatProgressSpinnerModule,
    FlexLayoutModule
  ],
})
export class HomeModule { }
