import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConsoleComponent } from './console.component';
import { ConsoleItemsComponent } from './console-items/console-items.component';
import { ConsoleDetailsComponent } from './console-details/console-details.component';
import { ConsoleRoutingModule } from './console-routing.module';



@NgModule({
  declarations: [
    ConsoleComponent,
    ConsoleItemsComponent,
    ConsoleDetailsComponent
  ],
  imports: [
    CommonModule,
    ConsoleRoutingModule,
  ]
})
export class ConsoleModule { }
