import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConsoleComponent } from './console.component';
import { ConsoleDetailsComponent } from './console-details/console-details.component';

const routes: Routes = [
  {
    path: '', title: 'Consoles', component: ConsoleComponent,
  },
  {
    path: ':id', title: 'Console', component: ConsoleDetailsComponent
  }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class ConsoleRoutingModule { }
