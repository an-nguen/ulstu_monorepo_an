import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PurchasesComponent } from './purchases/purchases.component';
import { MaterialsComponent } from './materials/materials.component';

@NgModule({
  declarations: [
    AppComponent,
    PurchasesComponent,
    MaterialsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
