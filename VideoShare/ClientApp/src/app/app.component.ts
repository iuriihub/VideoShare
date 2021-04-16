import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { filter } from 'rxjs/operators';
import { LayoutManagementService } from './shared';

@Component({
  selector: 'vc-root',
  styleUrls: ['./app.component.scss'],
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  isFullScreen: boolean;
  isLoading$: Observable<boolean>;
  @ViewChild('wrapper') wrapper: ElementRef;

  constructor(private readonly router: Router,
    private readonly layoutManagementService: LayoutManagementService) {
  }

  async ngOnInit() {
    this.layoutManagementService.isFullScreen$.subscribe(fs => this.isFullScreen = fs);
    this.router.events.pipe(filter(e => e instanceof NavigationEnd)).subscribe(() => {
      if (!this.wrapper) return;
      this.wrapper.nativeElement.scrollTo(0, 0);
    });
  }
}
