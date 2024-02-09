import { Component, OnInit } from '@angular/core';
import { IConsole } from '../shared/models/console';
import { ConsoleService } from '../console/console.service';
import { ConsoleParams } from '../shared/models/consoleParams';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  consoles!: IConsole[];
  consoleParams = new ConsoleParams();

  constructor(private consoleService: ConsoleService) { }

  ngOnInit(): void {
    this.getConsoles();
  }

  getConsoles() {
    this.consoleService.getConsoles(this.consoleParams).subscribe({
      next: response => {
        this.consoles = response.data;
        console.log('Consoles response:', response);
      },
      error: error => console.error('Error fetching consoles:', error)
    });
  }

}
