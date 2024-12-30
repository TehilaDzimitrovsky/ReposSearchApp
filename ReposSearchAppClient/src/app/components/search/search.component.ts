import { Component } from '@angular/core';
import { SearchService } from '../../services/search.service';
import { Repository } from '../../models/repository.model';
import { APP_CONSTANS } from '../../constans';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrl: './search.component.scss'
})

export class SearchComponent {
  searchTerm: string = '';
  repositories: Repository[] = [];
  constans = APP_CONSTANS;//Initialize all constans for component

  constructor(private searchService: SearchService) { }

  ngOnInit(): void {
    //Checking whether the user has already performed a search in the current session
    if(this.searchService.repositoriesState.length > 0 || this.searchService.term != '')
    {
      this.repositories = this.searchService.repositoriesState;
      this.searchTerm = this.searchService.term
    }
  }

  searchRepositories() {
    const term = this.searchTerm.toLowerCase();
    this.searchService.searchRepos(term).subscribe(res => {
      this.repositories = [...res];
      this.searchService.repositoriesState = this.repositories;
    })
  }
}