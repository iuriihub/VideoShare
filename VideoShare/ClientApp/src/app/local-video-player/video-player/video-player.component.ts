import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LocalStorageService, AppRoutes } from '../../shared';
import { ViewChild, ElementRef } from '@angular/core';

@Component({
  styleUrls: ['./video-player.component.scss'],
  templateUrl: './video-player.component.html'
})
export class VideoPlayerComponent implements OnInit{
  @ViewChild("videoPlayer", { static: false }) videoplayer: ElementRef;
  //private readonly unsubscribe: Subject<void> = new Subject<void>();
  private videoResource: string;

  constructor(
    private readonly router: Router,
    private readonly localStorageService: LocalStorageService
    ) { }

  ngOnInit(): void {
    this.localStorageService.fileName$.subscribe(videoResource => {
      this.videoResource = videoResource;
    });
  }

  toggleVideo(): void {
    this.videoplayer.nativeElement.play();
  }

  playPause(): void {
    this.videoplayer.nativeElement.src = "assets/videos/" + this.videoResource;
    if (this.videoplayer.nativeElement.paused) this.videoplayer.nativeElement.play();
    else this.videoplayer.nativeElement.pause();
  }

  makeBig(): void {
    this.videoplayer.nativeElement.width = 560;
  }

  makeSmall(): void {
    this.videoplayer.nativeElement.width = 320;
  }

  makeNormal(): void {
    this.videoplayer.nativeElement.width = 420;
  }

  fullScreen(): void {
    if (this.videoplayer.nativeElement.requestFullscreen) {
      this.videoplayer.nativeElement.requestFullscreen();
    } else if (this.videoplayer.nativeElement.webkitRequestFullscreen) { 
      this.videoplayer.nativeElement.webkitRequestFullscreen();
    } else if (this.videoplayer.nativeElement.msRequestFullscreen) { 
      this.videoplayer.nativeElement.msRequestFullscreen();
    }
  }

  skip(value): void {
    this.videoplayer.nativeElement.currentTime += value;
  }

  restart(): void {
    this.videoplayer.nativeElement.currentTime = 0;
  }

  stepBack() {
    this.router.navigate([AppRoutes.videoList]);
  }
}
