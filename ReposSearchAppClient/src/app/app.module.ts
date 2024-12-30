
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';

import { ReactiveFormsModule} from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { SearchComponent } from './components/search/search.component';
import { BookmarkComponent } from './components/bookmark/bookmark.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbar } from '@angular/material/toolbar';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { AuthInterceptor } from './authInterceptor';
import { GalleryComponent } from './components/gallery/gallery.component';

@NgModule({
  declarations: [
    AppComponent,
    SearchComponent,
    BookmarkComponent,
    GalleryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule, 
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatCardModule,
    MatIconModule,
    MatTabsModule,
    MatToolbar,
    MatSnackBarModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
