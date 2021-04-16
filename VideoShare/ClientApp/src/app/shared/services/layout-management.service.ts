import { Injectable } from '@angular/core';
import { delay } from 'rxjs/operators';
import { BehaviorSubject, Observable, Subject } from 'rxjs';

@Injectable({providedIn: 'root'})
export class LayoutManagementService {

  private readonly isFullScreenSubject$: Subject<boolean> = new Subject<boolean>();
  private readonly isNavigateBackActiveSubject$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(true);

  get isFullScreen$(): Observable<boolean> {
    return this.isFullScreenSubject$.asObservable().pipe(delay(0));
  }

  get isNavigateBackActive$(): Observable<boolean> {
    return this.isNavigateBackActiveSubject$.asObservable().pipe(delay(0));
  }

  setFullScreenLayoutStatus(isFullScreen: boolean): void {
    this.isFullScreenSubject$.next(isFullScreen);
  }

  setBackNavigationStatus(canNavigateBack: boolean): void {
    this.isNavigateBackActiveSubject$.next(canNavigateBack);
  }
}
