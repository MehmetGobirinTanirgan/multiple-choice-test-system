import { Component, OnInit } from '@angular/core';
import { QuestionModel } from 'src/models/QuestionModel';
import { QuestionService } from 'src/services/question.service';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.css']
})
export class AdminHomeComponent implements OnInit {

  constructor(private questionService:QuestionService) { }

  questions:Array<QuestionModel> | undefined | null= undefined;
  ngOnInit() {
    this.getAllQuestions();
  }

  getAllQuestions(){
    this.questionService.getAllQuestions().subscribe(data =>{
      if(data != null){
        this.questions = data;
      }else{
        this.questions = null;
      }
    },error =>{
      alert("Error: Can't load questions.")
    });
  }

}
