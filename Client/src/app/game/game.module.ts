import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameComponent } from './game.component';
import { GameItemComponent } from './game-item/game-item.component';
import { GameDetailsComponent } from './game-details/game-details.component';
import { GameRoutingModule } from './game-routing.module';
import { SharedModule } from '../shared/shared.module';
import { MaterialModule } from '../material/material.module';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    GameComponent,
    GameItemComponent,
    GameDetailsComponent
  ],
  imports: [
    CommonModule,
    GameRoutingModule,
    SharedModule,
    MaterialModule,
    FormsModule,
    SharedModule
  ]
})
export class GameModule { }
