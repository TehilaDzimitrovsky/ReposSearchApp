import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Repository } from '../models/repository.model';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  serviceBase: string = "https://localhost:7269/Search/";
  repositoriesState: Repository[]=[];
  term: string = '';

  constructor(private http: HttpClient) { }

  searchRepos(term: string): Observable<Repository[]>
  {
    this.term = term;
    return this.http.get<Repository[]>(`${this.serviceBase}SearchRepos/${term}`);
  }
}
