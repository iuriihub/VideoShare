import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { LayoutManagementService } from '../shared';

@Component({
  selector: 'vc-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  canGoBack$: Observable<boolean>;

  constructor(private readonly location: Location, private readonly layoutManagementService: LayoutManagementService) {
  }

  ngOnInit(): void {
    this.canGoBack$ = this.layoutManagementService.isNavigateBackActive$;
  }

  back(): void {
    this.location.back();
  }
}
