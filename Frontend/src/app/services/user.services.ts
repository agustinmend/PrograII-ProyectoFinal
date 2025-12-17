import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl = 'http://localhost:5008/api/Users'
  constructor(private https : HttpClient) { }
  registerUser(userData: any, profilePhoto: File | null) : Observable<any> {
    const formData = new FormData()
    formData.append('fullName', userData.fullName)
    formData.append('username', userData.username)
    formData.append('email', userData.email)
    formData.append('password', userData.password)
    if(userData.description) {
        formData.append('description', userData.description)
    }
    if(profilePhoto) {
        formData.append('profilePhoto', profilePhoto)
    }
    return this.https.post(`${this.apiUrl}/register`, formData)
  }
  login(credentials: any): Observable<any> {
    return this.https.post(`${this.apiUrl}/login`, credentials);
  }
}
