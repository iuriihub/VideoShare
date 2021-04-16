import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule, MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';
import { HeaderComponent } from './header.component';

@NgModule({
  imports: [MatIconModule, CommonModule, MatButtonModule],
  declarations: [HeaderComponent],
  exports: [HeaderComponent]
})
export class HeaderModule {
  constructor(iconRegistry: MatIconRegistry, sanitizer: DomSanitizer) {
    iconRegistry.addSvgIcon('logo', sanitizer.bypassSecurityTrustResourceUrl('assets/icons/logo.svg'));
    iconRegistry.addSvgIcon('back', sanitizer.bypassSecurityTrustResourceUrl('assets/icons/back.svg'));
  }
}
