import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({providedIn: 'root'})
export class ErrorInterceptor implements HttpInterceptor {

constructor(
    // lets inject some things we need to handle our errors
    private router:Router, // somtime we want to redirect the user to error page
    private toaster: ToastrService // somtime we want to display a toaster notification
){}

intercept(
    req: HttpRequest<any>, // we can either intercept the request that gos out
     next: HttpHandler // or the response that comes back in the 'next' after handleing it
     ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe( //this is the default behavior of the interceptor
     catchError(err => { // err will be response that comes back from the server (if there error)
      switch(err.status){
        case 400: //2 types of 400error 1.bad request 2.validation error
        if(err.error.errors){ // if there is a validation error
            const modelStateErrors = [] ; // modelStateError - is how these errors known in ASP.NET = {fildname: 'name'}
            for(const key in err.error.errors){
                if(err.error.errors[key]) {
                    modelStateErrors.push(err.error.errors[key]);
                }
            }
            throw modelStateErrors.flat(); //we throw the error to the component that called the Api
        }
        else{
            this.toaster.error(err.statusText == 'OK' ? 'Bad Request' : err.statusText, err.status);
        }
        break;
        case 401: // if there is a 401 error
        this.toaster.error(err.statusText == 'OK' ? 'Unauthorised' : err.statusText, err.status);
        break;
        case 404: // if there is a 404 error
        this.router.navigateByUrl('/not-found');
        break;
        case 500: // if there is a 500 error
        const navigationExtras: NavigationExtras = {state: {error: err.error}};
        this.router.navigateByUrl('/server-error');
        break;
        default: 
        this.toaster.error('Somthing Is GOES WRONG');
        break;    
      }  
      throw throwError(err)
     })
    )
}
  
    
}