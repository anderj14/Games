import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConsoleComponent } from './console.component';
import { ConsoleItemsComponent } from './console-items/console-items.component';
import { ConsoleDetailsComponent } from './console-details/console-details.component';
import { ConsoleRoutingModule } from './console-routing.module';
import { MaterialModule } from '../material/material.module';
import { SharedModule } from '../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { CoreModule } from '../core/core.module';



@NgModule({
  declarations: [
    ConsoleComponent,
    ConsoleItemsComponent,
    ConsoleDetailsComponent
  ],
  imports: [
    CommonModule,
    ConsoleRoutingModule,
    MaterialModule,
    SharedModule,
    FormsModule,
    CoreModule
  ]
})
export class ConsoleModule { }
