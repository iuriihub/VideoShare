import { Component, OnInit } from "@angular/core";
import { LocalStorageService, VideoResource, AppRoutes, ServiceRequest, VideoShareService } from "src/app/shared";
import { Router } from "@angular/router";
import { Subject } from "rxjs";
import { filter, takeUntil } from "rxjs/operators";

@Component({
  styleUrls: ['./video-list.component.scss'],
  templateUrl: './video-list.component.html'
})
export class VideoListComponent implements OnInit {
  private readonly unsubscribe: Subject<void> = new Subject<void>();
  videoResources: VideoResource[];
  serviceRequest: ServiceRequest;
  displayedColumns: string[] = ['name', 'openAction'];

  constructor(
    private readonly localStorageService: LocalStorageService,
    private readonly videoShareService: VideoShareService,
    private readonly router: Router,
  ) { }

  ngOnInit(): void {
    this.getVideoResources();
  }

  open(videoResource: string): void {
    this.localStorageService.setFileName(videoResource);
    this.router.navigate([AppRoutes.videoPlayer]);
  }

  refresh(): void {
    this.getVideoResources();
  }

  getVideoResources(): void {
    this.videoShareService.getVideoResources().pipe(filter(x => x), takeUntil(this.unsubscribe)).subscribe(
      videoResources => {
        this.videoResources = videoResources;
      }
    );
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.videoResources = this.videoResources.filter(o => o.name.toLowerCase().includes(filterValue.trim().toLowerCase()));
  }
}
