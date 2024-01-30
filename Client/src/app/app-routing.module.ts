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
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
