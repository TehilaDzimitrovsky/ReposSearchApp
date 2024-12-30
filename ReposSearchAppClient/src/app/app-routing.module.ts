import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SearchComponent } from './components/search/search.component';
import { BookmarkComponent } from './components/bookmark/bookmark.component';

const routes: Routes = [
  { path: 'search', component: SearchComponent },
  { path: 'bookmarked', component: BookmarkComponent }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
