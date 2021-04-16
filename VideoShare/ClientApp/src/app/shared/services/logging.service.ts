import { Inject, Injectable, InjectionToken } from '@angular/core';
import { JL } from 'jsnlog';
import { environment } from '../../../environments/environment';

export const jsNLogToken: InjectionToken<string> = new InjectionToken('JSNlog');

@Injectable()
export class LoggingService {
  private get logger(): JL.JSNLogLogger {
    return this.jsNLog();
  }

  constructor(@Inject(jsNLogToken) private readonly jsNLog: JL.JSNLog) {
    const logAppender: JL.JSNLogAjaxAppender = JL.createAjaxAppender('API logging appender');
    this.logger.setOptions({
      appenders: [
        // TODO: Implement logger parameters
        logAppender.setOptions({ url: 'http://localhost:4000', maxBatchSize: 20 })
      ]
    });
  }

  fatalException(logObject: unknown, error: unknown): void {
    if (!environment.production) {
      console.error(logObject);
      console.error(error);
    }
    this.logger.fatalException(logObject, error);
  }

  error(error: unknown): void {
    if (!environment.production) {
      console.error(error);
    }
    this.logger.error(error);
  }
}
