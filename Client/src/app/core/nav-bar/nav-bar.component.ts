import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent {
  showMenu = false;

  // Función para alternar la visibilidad del menú en dispositivos móviles
  toggleMenu() {
    this.showMenu = !this.showMenu;
  }
}
