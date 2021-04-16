import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { JL } from 'jsnlog';
import { LayoutManagementService } from "./services/layout-management.service";
import { LocalStorageService } from "./services/local-storage.service";
import { LoggingService, jsNLogToken } from './services/logging.service';
import { VideoShareService } from './services/video-share.service';

@NgModule({
  imports: [MatButtonModule, MatSnackBarModule, MatIconModule, MatCardModule, CommonModule],
  declarations: [],
  exports: [],
  providers: [
    VideoShareService,
    LayoutManagementService,
    LocalStorageService,
    LoggingService,
    { provide: jsNLogToken, useValue: JL }
  ],
  entryComponents: []
})
export class SharedModule {
}
