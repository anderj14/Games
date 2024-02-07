import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { GameParams } from '../shared/models/gameParams';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagination } from '../shared/models/pagination';
import { IGame } from '../shared/models/game';
import { IConsole } from '../shared/models/console';
import { Observable } from 'rxjs';
import { ConsoleParams } from '../shared/models/consoleParams';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  baseUrl = environment.apiUrl;
  // gameParams = new GameParams();
  // consoleParams = new ConsoleParams();

  constructor(private http: HttpClient) { }

  getGames(gameParams: GameParams) {
    let params = new HttpParams();

    if (gameParams.gameConsoleId > 0) params = params.append('gameConsoleId', gameParams.gameConsoleId);

    params = params.append('sort', gameParams.sort);
    params = params.append('pageIndex', gameParams.pageNumber);
    params = params.append('pageSize', gameParams.pageSize!);
    if (gameParams.search) params = params.append('search', gameParams.search);

    return this.http.get<IPagination<IGame[]>>(`${this.baseUrl}games`, { params });
  }

  getGame(id: number): Observable<IGame> {
    return this.http.get<IGame>(`${this.baseUrl}games/${id}`);
  }

  // Coming soon, sort with console
  // getConsoles() {
  //   return this.http.get<IConsole[]>(`${this.baseUrl}gameconsoles`);
  // }

}
