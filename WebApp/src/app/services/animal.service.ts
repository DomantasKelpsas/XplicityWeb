import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {User} from '@app/models/user';
import {Observable} from 'rxjs';
import {Token} from '@app/models/token';
import {Animal} from '@app/models/animal';
import {NewAnimal} from '@app/models/new-animal';

const headers = new HttpHeaders({
  'Content-Type': 'application/json',
  'Accept': 'application/json'
});

@Injectable({
  providedIn: 'root'
})
export class AnimalService {

  private AnimalListUrl = 'https://localhost:5001/api/Animals';

  constructor(private http: HttpClient) {
  }

  getAnimals(): Observable<Animal[]> {
    return this.http.get<Animal[]>(this.AnimalListUrl);
  }

  getAnimal(AnimalId: string): Observable<Animal> {
    return this.http.get<Animal>(`${this.AnimalListUrl}/${AnimalId}`);
  }

  addAnimal(animal: NewAnimal): Observable<Animal> {
    return this.http.post<Animal>(this.AnimalListUrl, animal, {headers});
  }
}
