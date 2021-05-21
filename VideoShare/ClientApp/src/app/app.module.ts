import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTableModule } from '@angular/material/table';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { FooterModule } from './footer';
import { SharedModule } from './shared';
import { ErrorModule } from './error';
import { LocalVideoPlayerModule } from './local-video-player';
import { baseUrl } from './shared';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'video-share' }),
    HttpClientModule,
    FormsModule,
    FooterModule,
    MatProgressSpinnerModule,
    AppRoutingModule,
    SharedModule,
    ErrorModule,
    LocalVideoPlayerModule,
    MatTableModule
  ],
  providers: [
    { provide: baseUrl, useValue: 'api/v1/video-share' },
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
