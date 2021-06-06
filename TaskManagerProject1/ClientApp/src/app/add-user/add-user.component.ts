import { Component, Inject, OnInit } from '@angular/core';
import { from } from 'rxjs';
import { FormBuilder, FormGroup, Validators, ValidationErrors } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {
  userToAddForm: FormGroup;
  userToAdd: UserToAdd;
  private baseUrl: string;
 
 
  constructor(private router: Router, private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private formBuilder: FormBuilder) {
    this.buildForm();
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
  }
  private buildForm() {
    this.userToAddForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
      roleId: ['', Validators.required]
    });
  }
  public onSubmit() {
    this.userToAdd = this.userToAddForm.value;
    localStorage.setItem('userToAdd', JSON.stringify(this.userToAdd));

    const payload = this.userToAdd;
   this.http.post(this.baseUrl + 'user/add-user', payload).subscribe(
      result => { console.log("Users controller says: OK") },
     error => { console.log("Users controller says: " + error) });    
    this.router.navigate(['/users']);
  }

  public clearData() {
    localStorage.clear();
    this.userToAddForm.reset();
  }

  public isControlInvalid(controlName: string): boolean {
    let control = this.userToAddForm.get(controlName);
    return !control.valid;
  }

}
export class UserToAdd {
  email: string;
  password: string;
  roleId: string;
}
