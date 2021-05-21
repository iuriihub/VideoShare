import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';
import { SharedModule } from '../shared';
import { LocalVideoPlayerRoutingModule } from './local-video-player-routing.module';
import { VideoPlayerComponent } from './video-player/video-player.component';
import { VideoListComponent } from './video-list/video-list.component';
import { MatTableModule } from '@angular/material/table';

@NgModule({
  imports: [
    MatAutocompleteModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatInputModule,
    MatTableModule,
    CommonModule,
    SharedModule,
    LocalVideoPlayerRoutingModule
  ],
  declarations: [
    VideoPlayerComponent,
    VideoListComponent
  ]
})
export class LocalVideoPlayerModule {
  constructor(iconRegistry: MatIconRegistry, sanitizer: DomSanitizer) {
    iconRegistry.addSvgIcon('image-front-capture', sanitizer.bypassSecurityTrustResourceUrl('assets/icons/image-front-capture.svg'));
  }
}
