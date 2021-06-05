import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { User } from '../models/User';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  public Users: Array<User>;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Array<User>>(baseUrl + 'user/get-users').subscribe(
      result => { this.Users = result; },
      error => { console.log("Users controller says: " + error) });
  }

  ngOnInit() {
   
  }

}
