import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { PointsComponent } from './components/points/points.component';
import { PointItemComponent } from './components/point-item/point-item.component';
import { AppRoutingModule } from './app-routing.module';
import { AddPointComponent } from './components/add-point/add-point.component';
import { ClearPointsComponent } from './components/clear-points/clear-points.component';
import { UploadFileComponent } from './components/upload-file/upload-file.component';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatCardModule} from '@angular/material/card';
import { HeaderComponent } from './components/header/header.component';

@NgModule({
  declarations: [
    AppComponent,
    PointsComponent,
    PointItemComponent,
    AddPointComponent,
    ClearPointsComponent,
    UploadFileComponent,
    HeaderComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    MatButtonModule,
    MatIconModule,
    BrowserAnimationsModule, 
    FlexLayoutModule,
    MatToolbarModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
