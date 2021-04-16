import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class LocalStorageService {
  private readonly correlationIdSubject$: BehaviorSubject<string> = new BehaviorSubject<string>(undefined);
  private readonly fileNameSubject$: BehaviorSubject<string> = new BehaviorSubject<string>(undefined);

  get correlationId$(): Observable<string> {
    return this.correlationIdSubject$.asObservable();
  }

  private set correlationId(value: string) {
    this.correlationIdSubject$.next(value);
  }

  get fileName$(): Observable<string> {
    return this.fileNameSubject$.asObservable();
  }

  private set fileName(value: string) {
    this.fileNameSubject$.next(value);
  }

  addCorrelationId(id: string): void {
    this.correlationId = id;
  }

  setFileName(fileName: string): void {
    this.fileName = fileName;
  }
}
