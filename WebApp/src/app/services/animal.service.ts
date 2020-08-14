import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {User} from '@app/models/user';
import {Observable} from 'rxjs';
import {Token} from '@app/models/token';
import {Animal} from '@app/models/animal';
import {NewAnimal} from '@app/models/new-animal';
import {ReportRequestDto} from '@app/models/ReportRequestDto';
import {EditAnimal} from '@app/models/edit-animal';

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

  getFilteredAnimals(fromDate: Date, toDate: Date): Observable<Animal[]> {
    return this.http.get<Animal[]>(`${this.AnimalListUrl}/filter`, {
      params: {
        fromDate: fromDate.toDateString(),
        toDate: toDate.toDateString()
      }
    });
  }

  getAnimal(AnimalId: string): Observable<EditAnimal> {
    return this.http.get<EditAnimal>(`${this.AnimalListUrl}/${AnimalId}`);
  }

  addAnimal(animal: NewAnimal): Observable<Animal> {
    return this.http.post<Animal>(this.AnimalListUrl, animal, {headers});
  }

  getAnimalAct(AnimalId: string): Observable<Animal> {
    return this.http.get<Animal>(`${this.AnimalListUrl}/Act/${AnimalId}`);
  }

  getAnimalYearReport(ReportSettings: ReportRequestDto): Observable<any> {
    return this.http.get<any>(`${this.AnimalListUrl}/Report`,{
      responseType: 'arraybuffer' as 'json',
      headers: headers,
      params: {
        Year: ReportSettings.Year.toString(),
        Type: ReportSettings.AnimalType.toString()
      }
    });
  }

  putAnimal(AnimalId: string, animal: EditAnimal): Observable<EditAnimal>{
    return this.http.put<EditAnimal>(`${this.AnimalListUrl}/${AnimalId}`, animal, {headers});
  }
}
