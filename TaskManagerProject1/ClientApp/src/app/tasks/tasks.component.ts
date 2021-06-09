import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ValidationErrors } from '@angular/forms';
import { Router, RouterEvent } from '@angular/router';
import { Task } from '../models/Task';
import { User } from '../models/User';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {
  taskToEditForm1: FormGroup;
  taskToEdit1: Task;
  public Tasks: Array<Task>;
  public Users: Array<User>;
  public task: Task;
  public stat: string;
  private baseUrl: string;

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private formBuilder: FormBuilder) {
    this.baseUrl = baseUrl;
    http.get<Array<Task>>(baseUrl + 'task/get-tasks').subscribe(
      result => { this.Tasks = result; },
      error => { console.log("Task controller says: " + error) });

    this.http.get<Array<User>>(this.baseUrl + 'user/get-users').subscribe(
      result => { this.Users = result; },
      error => { console.log("Users controller says: " + error) });
  }


  ngOnInit() {
    this.buildForm();
  }
  sendToEditTask(task: Task) {
    this.task = task;
    localStorage.setItem('editTask', JSON.stringify(this.task));
    this.router.navigate(['/edit-task']);

  }

  public onEdit(taskToEditForm1, task) {
    this.taskToEdit1 = this.taskToEditForm1.value;
    this.task = task;
    if (this.taskToEdit1.statusId !== "") {
      this.task.statusId = this.taskToEdit1.statusId;
    }
    if (this.taskToEdit1.emailUser !== "") {
      this.task.emailUser = this.taskToEdit1.emailUser;
    }

    const payload = this.task;
    this.http.put(this.baseUrl + 'task/edit-task', payload).subscribe(
      result => { console.log("Task controller says: OK") },
      error => { console.log("Task controller says: " + error) });
    this.router.navigate(['/tasks']);
    this.taskToEditForm1.reset();
    window.location.reload();
  }

  public deleteTask(task) {  
    this.task = task;
    const payload = this.task;
    this.http.post(this.baseUrl + 'task/delete-task', payload).subscribe(
      result => { console.log("Task controller says: OK") },
      error => { console.log("Task controller says: " + error) });
    this.router.navigate(['/tasks']);
    window.location.reload();
  }

  private buildForm() {
    this.taskToEditForm1 = this.formBuilder.group({
      id: ['', Validators.required],
      title: ['', Validators.required],
      description: ['', Validators.required],
      statusId: ['', Validators.required],
      userId: ['', Validators.required],
      emailUser: ['', Validators.required]

    });
  }

}
