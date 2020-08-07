import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Token } from '@app/model/token';
import { Observable } from 'rxjs';
import { User } from '@app/model/user';

const headers = new HttpHeaders({
  'Content-Type': 'application/json',
  'Accept': 'application/json'
});

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private registerUrl = 'https://localhost:5001/api/users/register';
  private loginUrl = 'https://localhost:5001/api/users/login';

  constructor(private http : HttpClient) { }

  registerUser(user: User): Observable<Token>
  {
    let token = this.http.post<Token>(this.registerUrl, user, {headers});
    token.subscribe(res => {
      localStorage.setItem('token', res.token)
    })
    return token
  }

  loginUser(user: User) : Observable<Token>
  {
    let token = this.http.post<Token>(this.loginUrl, user, {headers})
    token.subscribe(res => {
      localStorage.setItem('token', res.token)
    })
    return token
  }

  isLoggedIn()
  {
    return !!localStorage.getItem('token')
  }

  getToken()
  {
    return localStorage.getItem('token')
  }

  logout()
  {
    localStorage.removeItem('token');
  }
}
