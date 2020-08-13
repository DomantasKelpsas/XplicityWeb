import {Component, OnInit, ViewChild} from '@angular/core';
import {FormControl, FormGroup, NgForm} from '@angular/forms';
import {AnimalService} from '@app/services/animal.service';
import {ReportRequestDto} from '@app/models/ReportRequestDto';
import {Router} from '@angular/router';

@Component({
  selector: 'app-report-form',
  templateUrl: './report-form.component.html',
  styleUrls: ['./report-form.component.scss']
})
export class ReportFormComponent implements OnInit {
  years: number[];
  blob = new Blob();
  generationForm = new FormGroup({
    year: new FormControl(),
    type: new FormControl()
  });

  constructor(private animalService: AnimalService, private router: Router) { }

  ngOnInit(): void {
    this.years = this.range(2007, new Date().getFullYear());
  }

  range(start, end): number[] {
    const list = [];
    for (let i = end; i >= start; i--) {
      list.push(i);
    }
    return list;
  }

  onSubmit() {
    const settings = new ReportRequestDto();
    settings.Year = +this.generationForm.get('year').value;
    settings.AnimalType = +this.generationForm.get('type').value;
    console.log(settings);
    this.animalService.getAnimalYearReport(settings).subscribe((data) => {
      this.blob = new Blob([data], {type: 'application/octet-stream'});
      const downloadURL = window.URL.createObjectURL(data);
      console.log(downloadURL);
      this.router.navigate([downloadURL]);
      const a = document.createElement('a')
      a.href = downloadURL;
      a.download = 'generated_report.docx';
      a.click();
      URL.revokeObjectURL(downloadURL);
    },
      error => console.log(error)
    );
  }
}
