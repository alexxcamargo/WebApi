import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { map } from "rxjs/operators";
import { Usuario } from '../model/usuario.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private httpClient: HttpClient
  ) { }

  private readonly baseUrl = environment["endPoint"];


  getUser(){
    return this.httpClient
    .get<any>(`${this.baseUrl}/users`)
    .pipe(
      map(response => {
        if (response) {
          return response;
        } else {
          throw new Error(response.Error);
        }
      })
    );
  }

  createUser(user: Usuario) {
    return this.httpClient.post<any>(`${this.baseUrl}/users`, user);
  };

  updateUser(user: Usuario) {
    return this.httpClient.put<any>(`${this.baseUrl}/users`, user);
  };

  deleteUser(idUser) {
    return this.httpClient.delete<any>(`${this.baseUrl}/users/${idUser}`);
  };

}
