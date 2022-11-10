import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { RegistrationService } from '../services/registration.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
  providers:[RegistrationService]
})
export class RegistrationComponent implements OnInit {

  registerForm: FormGroup;

  constructor(private registrationService: RegistrationService) { 
    this.registerForm = new FormGroup({
      "username": new FormControl("",[
        Validators.minLength(4),
        Validators.maxLength(20),
        Validators.required
      ]),
      "roleId": new FormControl("", 
      Validators.required
      ),
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
    if(this.registerForm.valid) {
      console.log(this.registerForm.value);
    }

    this.registrationService.postData(this.registerForm.value)
    .subscribe({
        error: error => console.log(error)
    });
  }
}
