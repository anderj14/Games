import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IGame } from '../shared/models/game';
import { IConsole } from '../shared/models/console';
import { GameParams } from '../shared/models/gameParams';
import { GameService } from './game.service';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.scss']
})
export class GameComponent implements OnInit {

  @ViewChild('search') searchTerm?: ElementRef;
  games!: IGame[];
  consoles!: IConsole[];
  gameParams = new GameParams();

  sortOption = [
    { name: 'Alphabetical (A - Z)', value: 'GameName' },
    { name: 'Release Date: Desc To Asc', value: 'releaseDateAsc' },
    { name: 'Release Date: Asc To Desc', value: 'releaseDateDesc' },
  ];

  totalCount = 0;

  constructor(private gameService: GameService) { }

  ngOnInit(): void {
    this.getGames();
    // this.getConsoles();
  }

  getGames() {
    this.gameService.getGames(this.gameParams).subscribe({
      next: response => {
        this.games = response.data;
        this.gameParams.pageNumber = response.pageIndex;
        this.gameParams.pageSize = response.pageSize;
        this.totalCount = response.count;

        console.log(response);

      },
      error: error => console.log(error)
    });
  }

  // Coming soon, sort with console
  // getConsoles() {
  //   this.gameService.getConsoles().subscribe({
  //     next: response => {
  //       // console.log(response);
  //       this.consoles = [{ id: 0, consoleName: 'All' }, ...Object.values(response)];
  //     },
  //     error: error => console.log(error)
  //   });
  // }

  // onBrandSelected() {
  //   this.gameParams.pageNumber = 1;
  //   this.getGames();
  // }

  onSortSelected(event: any) {
    this.gameParams.sort = event.target.value;
    this.getGames();
  }

  onPageChanged(event: any) {
    if (this.gameParams.pageNumber !== event) {
      this.gameParams.pageNumber = event;
      this.getGames();
    }
  }

  onSearch() {
    this.gameParams.search = this.searchTerm?.nativeElement.value;
    this.gameParams.pageNumber = 1;
    this.getGames();
  }

}
