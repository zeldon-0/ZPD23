import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { map, catchError, tap} from 'rxjs/operators';

import { PasswordAuth, Ticket} from '../models';
import { tick } from '@angular/core/testing';

@Injectable({ providedIn: 'root' })
export class PasswordService {

    private apiUrl = "https://localhost:44336/api/passwordauth/";

    constructor(private http: HttpClient) {

    }

    login(authModel : PasswordAuth) : Observable<Ticket>{
        return this.http.post<Ticket>(`${this.apiUrl}authenticate`, authModel)
        .pipe(
            
            map(ticket => {
            if (ticket) {
                localStorage.setItem('userTicket', JSON.stringify(ticket));
            }
            return ticket;
            }),
            catchError(this.handleError)    
        );  
    }
    private handleError(error: HttpErrorResponse) {
        if (error.error instanceof ErrorEvent) {
          // A client-side or network error occurred. Handle it accordingly.
          console.error('An error occurred:', error.error.message);
        } else {
          // The backend returned an unsuccessful response code.
          // The response body may contain clues as to what went wrong.
          console.error(
            `Backend returned code ${error.status}, ` +
            `body was: ${error.error}`);
        }
        // Return an observable with a user-facing error message.
        return throwError(
          'Something bad happened; please try again later.');
      }

    logout() {

        localStorage.removeItem('userTicket');
 
    }

}