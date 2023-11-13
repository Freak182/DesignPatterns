import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';


import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// Component
import { DocumentationComponent } from './documentation/documentation.component';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ExampleComponent } from './example/example.component';

// Material
import { MatExpansionModule } from '@angular/material/expansion';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { PlaneTicketPurchaseService } from './services/plane-ticket-purchase.service';
import { HttpClientBase } from './services/base/httpClientBase';
import { UrlBuilderService } from './services/base/url-builder-service';
import { ReservationService } from './services/reservation.service';

@NgModule({
  declarations: [			
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    DocumentationComponent,
    ExampleComponent
   ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'documentation', component: DocumentationComponent },
      { path: 'example', component: ExampleComponent },
    ]),
    BrowserAnimationsModule,
    MatExpansionModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ],
  providers: [
    PlaneTicketPurchaseService,
    ReservationService,
    HttpClientBase,
    UrlBuilderService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
