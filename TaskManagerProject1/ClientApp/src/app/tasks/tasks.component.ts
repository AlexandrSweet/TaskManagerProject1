import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Task } from '../models/Task';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {

  public Tasks: Array<Task>;
  public task: Task;
  public stat: string;

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Array<Task>>(baseUrl + 'task/get-tasks').subscribe(
      result => { this.Tasks = result; },
      error => { console.log("Task controller says: " + error) });
  }

  ngOnInit() {
  }
  sendToEditTask(task: Task) {
    this.task = task;
    localStorage.setItem('editTask', JSON.stringify(this.task));
    this.router.navigate(['/edit-task']);
    
  }

}
