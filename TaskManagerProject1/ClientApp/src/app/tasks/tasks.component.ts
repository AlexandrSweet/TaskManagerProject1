import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Task } from '../models/Task';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {

  public Tasks: Array<Task>;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Array<Task>>(baseUrl + 'task/get-tasks').subscribe(
      result => { this.Tasks = result; },
      error => { console.log("Task controller says: " + error) });
  }

  ngOnInit() {
  }

}
