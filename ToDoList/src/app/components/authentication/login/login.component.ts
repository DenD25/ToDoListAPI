import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from "@angular/forms";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  constructor() {
    this.loginForm = new FormGroup({
      "username": new FormControl("",[
        Validators.minLength(4),
        Validators.maxLength(20),
        Validators.required
      ]),
      "password": new FormControl("", [
        Validators.minLength(4),
        Validators.maxLength(20),
        Validators.required,
      ]),
    });
  }

  ngOnInit(): void {
  }

  onSubmit() {
    if(this.loginForm.valid) {
      console.log("Done");
    }
  }
}
