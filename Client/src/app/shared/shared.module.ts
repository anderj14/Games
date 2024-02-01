import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagerComponent } from './pager/pager.component';
import { PagingComponent } from './paging/paging.component';
import { MaterialModule } from '../material/material.module';



@NgModule({
  declarations: [
    PagerComponent,
    PagingComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    PagerComponent,
    PagingComponent
  ]
})
export class SharedModule { }
