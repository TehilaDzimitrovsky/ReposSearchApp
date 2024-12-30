import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Repository } from '../models/repository.model';

@Injectable({
  providedIn: 'root'
})
export class BookmarkService {

  serviceBase: string = "https://localhost:7269/Mark/";

  constructor(private http: HttpClient) { }

  getAllMarkedRepos(): Observable<Repository[]>
  {
    return this.http.get<Repository[]>(`${this.serviceBase}GetAllMarkedRepos`);
  }

  markRepo(repo: Repository): Observable<Repository>
  {
    return this.http.post<Repository>(this.serviceBase + 'MarkRepo', repo);
  }

  unMarkRepo(repoId: number): Observable<Repository>
  {
    const url = `${this.serviceBase}UnMarkRepo/${repoId}`;
    return this.http.delete<Repository>(url);  }
}
