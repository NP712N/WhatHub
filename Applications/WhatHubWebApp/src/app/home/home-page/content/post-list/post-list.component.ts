import { Component, OnInit } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { Post } from 'src/app/model/post.model';
import { PostService } from 'src/app/service/post-service/post.service';

@Component({
  selector: 'what-hub-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.scss']
})
export class PostListComponent implements OnInit {

  loading: boolean = false;
  posts: Post[];

  constructor(private _postService: PostService) {
  }

  ngOnInit(): void {
    this.loading = true;
    this._postService.getBriefPosts()
      .pipe(finalize(() => {
        this.loading = false;
      }))
      .subscribe(data => {
        this.posts = data;
      })
  }

}
