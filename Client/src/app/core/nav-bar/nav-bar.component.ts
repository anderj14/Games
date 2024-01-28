import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  standalone: true,
  imports: [],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.scss'
})
export class NavBarComponent {
  showMenu = false;

  // Función para alternar la visibilidad del menú en dispositivos móviles
  toggleMenu() {
    this.showMenu = !this.showMenu;
  }
}
