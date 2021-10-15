import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { QuestionModel } from 'src/models/QuestionModel';
import { ResultCreateModel } from 'src/models/ResultCreateModel';
import { ResultModel } from 'src/models/ResultModel';
import { UserAnswersModel } from 'src/models/UserAnswersModel';
import { UserDataModel } from 'src/models/UserDataModel';
import { DataService } from 'src/services/data.service';
import { QuestionService } from 'src/services/question.service';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-test-page',
  templateUrl: './test-page.component.html',
  styleUrls: ['./test-page.component.css'],
})
export class TestPageComponent implements OnInit {
  constructor(
    private questionService: QuestionService,
    private formBuilder: FormBuilder,
    private userService: UserService,
    private router: Router,
    private dataService: DataService
  ) {}

  testQuestions: Array<QuestionModel> | undefined;
  testForm: FormGroup | undefined;
  answersOfUser: UserAnswersModel | undefined;
  result: ResultModel | undefined;
  userData: UserDataModel | undefined;

  ngOnInit(): void {
    this.getQuestions();
    this.createTestForm();
  }

  getQuestions(): void {
    this.questionService.getQuestionsForTest().subscribe(
      (data) => {
        this.testQuestions = data;
      },
      (error) => {
        alert("Error: Can't load test.");
      }
    );
  }

  createTestForm(): void {
    this.testForm = this.formBuilder.group({
      answer0: ['', Validators.required],
      answer1: ['', Validators.required],
      answer2: ['', Validators.required],
      answer3: ['', Validators.required],
      answer4: ['', Validators.required],
      answer5: ['', Validators.required],
      answer6: ['', Validators.required],
      answer7: ['', Validators.required],
      answer8: ['', Validators.required],
      answer9: ['', Validators.required],
    });
  }

  submit(): void {
    if (this.testForm?.valid) {
      let wrongAnswersCt: number = 0;
      this.answersOfUser = new UserAnswersModel(this.testForm.value);
      if (this.testForm != null && this.testQuestions != undefined) {
        for (let i = 0; i < 10; i++) {
          if (
            this.testForm.get(`answer${i}`)!.value !=
            this.testQuestions[i].rightAnswer
          ) {
            wrongAnswersCt++;
          }
        }
      }

      let rightAnswerCt: number = 10 - wrongAnswersCt;
      const result: ResultCreateModel = new ResultCreateModel();
      const userData = this.userService.getUserData();

      result.wrongAnswerCt = wrongAnswersCt;
      result.rightAnswerCt = rightAnswerCt;
      result.name = userData.name;
      result.surname = userData.name;
      result.emailAddress = userData.emailAddress;
      result.phoneNumber = userData.phoneNumber;
      this.dataService.result = result;
      this.router.navigate(['result']);
    }
  }
}
