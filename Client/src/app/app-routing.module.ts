import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {
    path: '', title: 'Home Page', component: HomeComponent,
  },
  {
    path: 'consoles',
    loadChildren: () => import('./console/console.module').then(m => m.ConsoleModule),
  },
  {
    path: 'games',
    loadChildren: () => import('./game/game.module').then(m => m.GameModule),
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
