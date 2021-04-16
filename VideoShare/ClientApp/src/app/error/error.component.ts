import { Component, OnInit } from '@angular/core';
import { AppRoutes, LayoutManagementService } from '../shared';
import { Router } from '@angular/router';

@Component({
  styleUrls: ['./error.component.scss'],
  templateUrl: './error.component.html'
})
export class ErrorComponent implements OnInit {
  videoStreamStatus: boolean = true;

  constructor(
    private readonly layoutManagementService: LayoutManagementService,
    private readonly router: Router) { }

  ngOnInit(): void {
    this.layoutManagementService.setBackNavigationStatus(false);
  }

  restart(): void {
    this.router.navigate([AppRoutes.videoList]);
  }
}
