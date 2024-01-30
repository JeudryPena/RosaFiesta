import {Injectable} from '@angular/core';
import {HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {catchError} from 'rxjs/operators';
import {Router} from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ErrorHandlerService implements HttpInterceptor {

  constructor(private router: Router) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          let errorMessage = this.handleError(error);
          return throwError(() => new Error(errorMessage));
        })
      )
  }

  // @ts-ignore
  private handleError = (error: HttpErrorResponse): string => {
    if (error.status === 500) {
      return this.handleInternalServer(error);
    }
    if (error.status === 404) {
      return this.handleNotFound(error);
    } else if (error.status === 400) {
      return this.handleBadRequest(error);
    } else if (error.status === 401) {
      return this.handleUnauthorized(error);
    } else if (error.status === 403) {
      return this.handleForbidden(error);
    }
  }

  private handleInternalServer = (error: HttpErrorResponse): string => {
    return error.error.error;
  }

  private handleForbidden = (error: HttpErrorResponse) => {
    // this.router.navigate(["/forbidden"], { queryParams: { returnUrl: this.router.url }});

    return "Forbidden";
  }

  private handleNotFound = (error: HttpErrorResponse): string => {
    // this.router.navigate(['/404']);
    return error.message;
  }

  private handleUnauthorized = (error: HttpErrorResponse) => {
    return error.error.message ? error.error.message : error.message;
  }

  private handleBadRequest = (error: HttpErrorResponse): string => {
    if (!error.error.error) {
      let message = '';
      const values = Object.values(error.error.errors);
      values.map((m: any) => {
        message += m + ' <br> ';
      });
      return message.slice(0, -6);
    } else {
      return error.message;
    }
  }
}
