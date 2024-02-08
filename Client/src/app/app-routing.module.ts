import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { EventComponent } from './event/event.component';

const routes: Routes = [
  {
    path: '', title: 'Home Page', component: HomeComponent, data: {breadcrumb: 'Home'}
  },
  {
    path: 'consoles',
    loadChildren: () => import('./console/console.module').then(m => m.ConsoleModule),
  },
  {
    path: 'games',
    loadChildren: () => import('./game/game.module').then(m => m.GameModule),
  },
  {
    path: 'events', component: EventComponent, title: 'Events'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
