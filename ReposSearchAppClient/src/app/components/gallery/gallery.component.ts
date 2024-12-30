import { Component, Input } from '@angular/core';
import { Repository } from '../../models/repository.model';
import { BookmarkService } from '../../services/bookmark.service';
import { APP_CONSTANS } from '../../constans';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrl: './gallery.component.scss'
})
export class GalleryComponent {

  @Input() repositories: Repository[] = [];
  @Input() source: string = 'search';
  constans = APP_CONSTANS;

  constructor(private bookmarkService: BookmarkService, private snackBar: MatSnackBar) { }

  markRepo(repo: Repository) {
    this.bookmarkService.markRepo(repo).subscribe((res) => {
     this.openSnacbar(true,false,repo.name!)
    },
    (error) => {
      this.openSnacbar(false,false,repo.name!)
    })
  }

  unMarkRepo(repo: Repository) {
    this.bookmarkService.unMarkRepo(repo.id!).subscribe(
      (res) => {
        this.bookmarkService.getAllMarkedRepos().subscribe(repos => {
          this.repositories = [...repos];
        })
       this.openSnacbar(true,true,repo.name!)
      },
      (error) => {
        this.openSnacbar(false,true,repo.name!)
      }
    )
  }

  //Opening a snackbar for a user on success/failure
  openSnacbar(isSuccess: boolean, isDeleted: boolean, repoName: string) {
    if (!isSuccess) {
      this.snackBar.open('Failed to' + isDeleted? this.constans.DELETE: this.constans.MARK +'the repository.', 'Close', {
        duration: 3000,
        horizontalPosition: 'center',
        verticalPosition: 'top',
        panelClass: ['error-snackbar'],
      });
    }
    else{
      this.snackBar.open(`${repoName}${isDeleted?this.constans.DELETED:this.constans.BOOKMARKED}`, 'Close', {
        duration: 3000, 
        horizontalPosition: 'center',
        verticalPosition: 'top',
        panelClass: ['success-snackbar'],
      });
    }
  }
 // An option for user to watch the repo
  navigateToRepo(repo: Repository) {
    window.open(repo.htmlUrl, '_blank');
  }
}
