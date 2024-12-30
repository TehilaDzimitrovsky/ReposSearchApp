import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'InsurancePoliciesClient';
  constructor(private authService: AuthService){}

  ngOnInit() {
    //Generate the JWT token
    this.authService.getTokenFromServer().subscribe(() => { });
  }
}
