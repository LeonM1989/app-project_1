import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import {map} from 'rxjs/operators';
import { User } from '../models/User';


@Injectable({
  providedIn: 'root' //an injectable singleton (does not destroys until we close our app)
})
export class AccountService {
  baseUrl = 'https://localhost:5001/api/';

  private currentUserSourse$ = new ReplaySubject<User>(1);
  public currentUser$ = this.currentUserSourse$.asObservable();

  constructor(private http: HttpClient) { }
 
  login(model: any): Observable<any> {
    return this.http.post<User>(this.baseUrl + 'account/login', model).pipe(
      map((response: User)=> {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSourse$.next(user);
        }
      })
    );
  }

   setCurrentUser(user: User){
    this.currentUserSourse$.next(user);
   }

   
  logout(){
   localStorage.removeItem('user');
   this.currentUserSourse$.next();
  }
}
