import { Component } from '@angular/core';
import { BookmarkService } from '../../services/bookmark.service';
import { Repository } from '../../models/repository.model';
import { APP_CONSTANS } from '../../constans';

@Component({
  selector: 'app-bookmark',
  templateUrl: './bookmark.component.html',
  styleUrl: './bookmark.component.scss'
})
export class BookmarkComponent {
  
  bookmarkedRepos: Repository[] = [];
  constans = APP_CONSTANS;
  constructor(private bookmarkService: BookmarkService) { }

  ngOnInit(): void {
    this.bookmarkService.getAllMarkedRepos().subscribe(res=>{
      this.bookmarkedRepos = [...res];
    })
  }
}