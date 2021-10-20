import { Component, OnInit } from '@angular/core';
import { ResultModel } from 'src/models/ResultModel';
import { DataService } from 'src/services/data.service';
import { ResultService } from 'src/services/result.service';

@Component({
  selector: 'app-result-page',
  templateUrl: './result-page.component.html',
  styleUrls: ['./result-page.component.css'],
})
export class ResultPageComponent implements OnInit {
  constructor(
    private dataService: DataService,
    private resultService: ResultService
  ) {}

  result: ResultModel | undefined;

  ngOnInit() {
    if (this.dataService.result != undefined) {
      this.resultService.sendResult(this.dataService.result).subscribe(
        (data) => {
          this.result = data;
          this.resultService.saveResultID(data.id!);
        },
        (error) => {
          alert('Error: Result posting failure');
        }
      );
    } else {
      if (this.result == undefined) {
        this.refreshResultData();
      } else {
        alert('Error: Data loss');
      }
    }
  }

  refreshResultData() {
    this.resultService.getResult(this.resultService.getResultID()!).subscribe(
      (data) => {
        this.result = data;
      },
      (error) => {
        alert('Error: Result loading failure');
      }
    );
  }
}
