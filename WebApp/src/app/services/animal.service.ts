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

  private animalListUrl = 'https://localhost:5001/api/Animals';

  constructor(private http: HttpClient) {
  }

  getAnimals(): Observable<Animal[]> {
    return this.http.get<Animal[]>(this.animalListUrl);
  }

  getFilteredAnimals(fromDate: Date, toDate: Date): Observable<Animal[]> {
    return this.http.get<Animal[]>(`${this.animalListUrl}/filter`, {
      params: {
        fromDate: fromDate.toDateString(),
        toDate: toDate.toDateString()
      }
    });
  }

  getAnimal(AnimalId: string): Observable<EditAnimal> {
    return this.http.get<EditAnimal>(`${this.animalListUrl}/${AnimalId}`);
  }

  addAnimal(animal: NewAnimal): Observable<Animal> {
    return this.http.post<Animal>(this.animalListUrl, animal, {headers});
  }

  getAnimalYearReport(ReportSettings: ReportRequestDto): Observable<any> {
    return this.http.get<any>(`${this.animalListUrl}/Report`,{
      responseType: 'arraybuffer' as 'json',
      headers: headers,
      params: {
        Year: ReportSettings.Year.toString(),
        Type: ReportSettings.AnimalType.toString()
      }
    });
  }

  getAnimalAct(Id: number): Observable<any> {
    return this.http.get<any>(`${this.animalListUrl}/Act/${Id}`,{
      responseType: 'arraybuffer' as 'json',
      headers: headers,
    });
  }

  putAnimal(AnimalId: string, animal: EditAnimal): Observable<EditAnimal>{
    return this.http.put<EditAnimal>(`${this.animalListUrl}/${AnimalId}`, animal, {headers});
  }

  deleteAnimal(animalId: number): Observable<Animal> {
    return this.http.delete<Animal>(`${this.animalListUrl}/${animalId}`);
  }
}
