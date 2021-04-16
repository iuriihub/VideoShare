import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ErrorComponent } from './error';
import { AppRoutes } from './shared';

const routes: Routes = [
  { path: '', redirectTo: AppRoutes.videoList, pathMatch: 'full' },
  { component: ErrorComponent, path: AppRoutes.error }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: []
})

export class AppRoutingModule { }
