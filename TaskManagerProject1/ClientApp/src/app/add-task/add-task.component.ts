import { Component, Inject, OnInit } from '@angular/core';
import { from } from 'rxjs';
import { FormBuilder, FormGroup, Validators, ValidationErrors } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css']
})
export class AddTaskComponent implements OnInit {
  taskToAddForm: FormGroup;
  taskToAdd: TaskToAdd;
  private baseUrl: string;

  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private formBuilder: FormBuilder) {
    this.buildForm();
    this.baseUrl = baseUrl;
  }

  ngOnInit() {    
  }

  public onSubmit() {
    this.taskToAdd = this.taskToAddForm.value;
    localStorage.setItem('taskToAdd', JSON.stringify(this.taskToAdd));

    const payload = this.taskToAdd;
    this.http.post(this.baseUrl + 'task/add-task', payload).subscribe(
      result => { console.log("Task controller says: OK") },
      error => { console.log("Task controller says: " + error) });
    this.router.navigate(['/tasks']);
  }
  public clearData() {
    localStorage.clear();
    /*this.taskToAddForm.reset();*/
  }
  public isControlInvalid(controlName: string): boolean {
    let control = this.taskToAddForm.get(controlName);
    return !control.valid;
  }

  private buildForm() {
    this.taskToAddForm = this.formBuilder.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      statusId: ['ReadyForDevelopment', Validators.required],
      userId: ['', Validators.required],
      emailUser: ['', Validators.required]
    });
  }

}
export class TaskToAdd {
  title: string;
  description: string;
  statusId: string;
  userId: string;
  emailUser: string;
}
