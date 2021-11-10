import { Component, Input, OnInit } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { Post } from 'src/app/model/post.model';
import { PostService } from 'src/app/service/post-service/post.service';

@Component({
  selector: 'what-hub-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {

  @Input() post: Post;

  constructor(private _postService: PostService) {
  }

  ngOnInit(): void {
    this._postService.getPostContent(this.post.id)
      .pipe(finalize(() => {
        // this.loading = false;
      }))
      .subscribe(dataResponse => {
        this.post.content = dataResponse.value;
      })
  }

  goDetail() {
  }
}
