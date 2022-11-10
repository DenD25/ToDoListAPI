import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
   
@Injectable()
export class RegistrationService{
   
    constructor(private http: HttpClient){ }
 
    postData(user: any){
          
        return this.http.post('http://localhost:7078/api/Register', user); 
    }
}