import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ValidationErrors } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Task } from '../models/Task';
import { User } from '../models/User';


@Component({
  selector: 'app-edit-task',
  templateUrl: './edit-task.component.html',
  styleUrls: ['./edit-task.component.css']
})
export class EditTaskComponent implements OnInit {
  taskToEditForm: FormGroup;
  taskToEdit: Task;
  private baseUrl: string;
  public Users: Array<User>;

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private formBuilder: FormBuilder) {
    this.buildForm();
    this.populateForm();
    this.baseUrl = baseUrl;

    this.http.get<Array<User>>(this.baseUrl + 'user/get-users').subscribe(
      result => { this.Users = result; },
      error => { console.log("Users controller says: " + error) });
}
  ngOnInit() {
  }
  public onEdit() {
    this.taskToEdit = this.taskToEditForm.value;   

    const payload = this.taskToEdit;
    this.http.put(this.baseUrl + 'task/edit-task', payload).subscribe(
      result => { console.log("Task controller says: OK") },
      error => { console.log("Task controller says: " + error) });
    this.router.navigate(['/tasks']);
  }
  public clearData() {
    localStorage.clear();
    this.taskToEditForm.reset();
  }
  public populateForm() {
    this.taskToEdit = JSON.parse(localStorage.getItem('editTask'));
    if (this.taskToEdit) {
      this.taskToEditForm.patchValue(this.taskToEdit);
    }
  }

  public deleteTask() {
    this.taskToEdit = this.taskToEditForm.value;

    const payload = this.taskToEdit;
    this.http.post(this.baseUrl + 'task/delete-task', payload).subscribe(
      result => { console.log("Task controller says: OK") },
      error => { console.log("Task controller says: " + error) });
    this.router.navigate(['/tasks']);

  }




  private buildForm() {
    this.taskToEditForm = this.formBuilder.group({
      id: ['', Validators.required],
      title: ['', Validators.required],
      description: ['', Validators.required],
      statusId: ['', Validators.required],
      userId: ['', Validators.required],
      emailUser: ['', Validators.required]

    });
  }
}
