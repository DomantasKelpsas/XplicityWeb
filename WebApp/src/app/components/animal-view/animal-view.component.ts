import { Component, OnInit } from '@angular/core';
import {EditAnimal} from '@app/models/edit-animal';
import {Fur} from '@app/models/fur';
import {ActivatedRoute, ParamMap, Router} from '@angular/router';
import {AnimalService} from '@app/services/animal.service';
import {switchMap} from 'rxjs/operators';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-animal-view',
  templateUrl: './animal-view.component.html',
  styleUrls: ['./animal-view.component.scss']
})
export class AnimalViewComponent implements OnInit {

  animal: EditAnimal = new EditAnimal();
  fur: Fur = new Fur();
  constructor(private route: ActivatedRoute, private router: Router,
              private animalService: AnimalService) {}

  ngOnInit(): void {
     this.animal.fur = this.fur;
     this.route.paramMap.pipe( // combines observable functions
      switchMap((params: ParamMap) => { // cancels previous requests
          // emits Product observable when parameter map changes
          const id = params.get('id'); // gets id parameter from route parameter array
          return this.animalService.getAnimal(id); // returns Observable<Product>
        }
      )).subscribe(animal => { // subscription to observable
      this.animal = animal;
      console.log(this.animal);
    });
  }

  onSubmit(newAnimalForm: NgForm) {
    console.log(this.animal);
  }
}
