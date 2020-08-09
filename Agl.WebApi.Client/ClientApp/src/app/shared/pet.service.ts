import { Injectable } from '@angular/core';
import { throwError,Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PetService {
  relativeUrl='/api/pets';
  private alertMessage$ = new Subject<string>();

  constructor(private http: HttpClient) { }

  get errorMessage() {
    return this.alertMessage$;
  }

  getOwnerWithPets(cat)  {
    return this.http.get(environment.baseUrl+ this.relativeUrl+'/'+cat).
    pipe(catchError(error => {
      this.alertMessage$.next(error.message);
      return throwError(error.message);
    } ));
  }
}
