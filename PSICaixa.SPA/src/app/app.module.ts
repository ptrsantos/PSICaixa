import { NgxSpinnerModule } from 'ngx-spinner';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { DominioModule } from './dominio/dominio.module';
import { setTheme, AccordionModule, CarouselModule } from 'ngx-bootstrap';
import { MenuSuperiorComponent } from './menu-superior/menu-superior.component';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MenuSuperiorComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,//--> Comentar os módulos que já constam importados
    HttpClientModule,
    DominioModule,
    NgxSpinnerModule,
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true,
      maxOpened: 2,
      autoDismiss: true,
      closeButton: true,
      enableHtml: true,
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
