import { Component, Input, OnInit } from '@angular/core';
import { IGame } from 'src/app/shared/models/game';
import { GameService } from '../game.service';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-game-details',
  templateUrl: './game-details.component.html',
  styleUrls: ['./game-details.component.scss']
})
export class GameDetailsComponent implements OnInit {

  game!: IGame;

  constructor(
    private gameService: GameService,
    private activateRoute: ActivatedRoute,
    private bcService: BreadcrumbService
  ) { }

  ngOnInit(): void {
    this.loadGame();
  }

  loadGame() {
    const id = this.activateRoute.snapshot.paramMap.get('id');
    if (id) {
      this.gameService.getGame(+id).subscribe({
        next: game => { 
          this.game = game;
          this.bcService.set('@gameDetails', game.gameName);
        },
        error: error => console.log(error)
      });
    }
  }
}
