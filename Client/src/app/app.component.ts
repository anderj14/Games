import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { NavBarComponent } from './core/nav-bar/nav-bar.component';
import { FooterComponent } from './core/footer/footer.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, RouterOutlet, NavBarComponent, FooterComponent],
  template: `
    <!-- <p>hola</p> -->
    <app-nav-bar />
    <router-outlet></router-outlet>
    <app-footer></app-footer>
  `,
  styles: ''
})
export class AppComponent {
  title = 'Client';
}
