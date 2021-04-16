import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { baseUrl } from "../base-url.const";
import { Observable } from "rxjs";

@Injectable()
export class VideoShareService {

  constructor(
    private readonly http: HttpClient,
    @Inject(baseUrl) private readonly baseUrl: string) {
  }

  getVideoResources(): Observable<any> {
    const url: string = `${this.baseUrl}/video-resources`;
    return this.http.get(url)
  }
}
