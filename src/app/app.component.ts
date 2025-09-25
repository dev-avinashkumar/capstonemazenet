import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserComponent } from './components/user/user.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, UserComponent],
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'fresher-onboarding';
}
