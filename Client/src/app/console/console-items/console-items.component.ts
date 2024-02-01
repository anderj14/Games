import { Component, Input } from '@angular/core';
import { IConsole } from 'src/app/shared/models/console';

@Component({
  selector: 'app-console-items',
  templateUrl: './console-items.component.html',
  styleUrls: ['./console-items.component.scss']
})
export class ConsoleItemsComponent {
  @Input() consoles!: IConsole[];
}
