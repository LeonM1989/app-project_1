import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'The Dating app';
  users : any;
  constructor(private http: HttpClient) {}

  ngOnInit(): void{
  this.getUsers();
  }

  getUsers(){
    this.http.get('https://localhost:5001/api/users').subscribe(
      // response => {
      //   this.users =response;
      // },
      // error => {
      //   console.log(error);
      // },
      // () => {
      //   console.log('Finished')
      // }
     
      {
        next: (response) =>{this.users =response}, // what to do with return data;
        error: (error) => {console.log(error);}, // what to do with error
        complete: () => {console.log('Finished');} //what to do when finished;  
      }
    )
    
  }
}
