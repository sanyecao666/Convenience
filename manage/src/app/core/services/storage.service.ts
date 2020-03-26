import { Injectable } from '@angular/core';
import { JwtHelperService } from "@auth0/angular-jwt";

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  jwtService = new JwtHelperService();

  constructor() { }

  set userToken(value) {
    localStorage.setItem('userToken', value);
    let expirationDate = this.jwtService.getTokenExpirationDate(value);
    let decodeToken = this.jwtService.decodeToken(value);
    this.UserRoles = decodeToken['userroleids'];
    localStorage.setItem('userTokenExpiration', expirationDate.toString());
  }

  get userToken() {
    return localStorage.getItem('userToken');
  }

  get tokenExpiration() {
    return localStorage.getItem('userTokenExpiration');
  }

  get userName() {
    return localStorage.getItem("username");
  }

  removeUserToken() {
    localStorage.removeItem('userToken');
  }

  hasUserToken(): boolean {
    return this.userToken != null;
  }

  get Name() {
    return localStorage.getItem("name");
  }
  set Name(value) {
    localStorage.setItem("name", value);
  }

  get UserRoles() {
    return localStorage.getItem("userroles");
  }
  set UserRoles(value) {
    localStorage.setItem("userroles", value);
  }
  
  get Avatar() {
    return localStorage.getItem("avatar");
  }
  set Avatar(value) {
    localStorage.setItem("avatar", value);
  }

  get Identifycation(){
    return localStorage.getItem("identifycation");
  }
  set Identifycation(value) {
    localStorage.setItem("identifycation", value);
  }

  get Route(){
    return localStorage.getItem("route");
  }
  set Route(value) {
    localStorage.setItem("route", value);
  }

}
