import { NgModule } from '@angular/core';
import { Route, RouterModule } from '@angular/router';

import { AppRoutes } from '../shared';
import { VideoListComponent } from './video-list/video-list.component';
import { VideoPlayerComponent } from './video-player/video-player.component';

const routes: Route[] = [
  { component: VideoListComponent, path: AppRoutes.videoList },
  { component: VideoPlayerComponent, path: AppRoutes.videoPlayer }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LocalVideoPlayerRoutingModule { }
