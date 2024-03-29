import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { CoreModule } from './core/core.module';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { BreadcrumbModule } from 'xng-breadcrumb';
import { EventComponent } from './event/event.component';
import { ConsoleModule } from './console/console.module';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    EventComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CoreModule,
    RouterModule,
    HttpClientModule,
    ConsoleModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
