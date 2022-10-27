import { Injectable } from '@angular/core';
import { NgxSpinnerService, Spinner } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class BusyService {
  busyRequestCount =0;
constructor(private spinnerService: NgxSpinnerService) { }


busy(){
  this.busyRequestCount++;
  const spinner: Spinner = {
  type: 'square-jelly-box',
  bdColor: 'rgba(0, 0, 0, 0.8)',
  color: '#1dde4f'
}
  this.spinnerService.show(undefined, spinner)
}

idle(){
  this.busyRequestCount--;
  if(this.busyRequestCount <= 0)
  {
    this.busyRequestCount = 0;
    this.spinnerService.hide();
  }

}
}
