import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account.service';
import { User } from '../models/User';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  currentUser$?: Observable<User>;

  constructor(
    private accountService: AccountService, 
    private router: Router,
    private toastr: ToastrService,
    ) {
    this.currentUser$ = this.accountService.currentUser$;
  }

  ngOnInit(): void {
    // this.getCurrentUser();
  }

  login() {
    this.accountService.login(this.model) // returning observable (it's lazy)
      .subscribe({
        next: response => {
          this.router.navigateByUrl('/members');
          console.log(response);
        },
        error: ({error}) => {
          if(!(error.errors && typeof error.errors == 'object')) {
         return this.toastr.error(error) as any;
          }
          for (const key in error.errors){
            if(error.errors.hasOwnProperty(key)){
              this.toastr.error(error.errors[key]);
            }
          }
          console.log(error);
        }

      });
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

}