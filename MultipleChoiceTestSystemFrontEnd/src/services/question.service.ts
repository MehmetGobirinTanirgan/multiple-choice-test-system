import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { QuestionCreateModel } from 'src/models/QuestionCreateModel';
import { QuestionModel } from 'src/models/QuestionModel';

@Injectable()
export class QuestionService {
  constructor(private httpClient: HttpClient) {}

  getAllQuestions() {
    return this.httpClient.get<Array<QuestionModel>>(
      'Question/GetAllQuestions'
    );
  }

  addNewQuestion(questionCreateModel: QuestionCreateModel) {
    return this.httpClient.post<QuestionModel>(
      'Question/AddNewQuestion',
      questionCreateModel
    );
  }

  getQuestionsForTest() {
    return this.httpClient.get<Array<QuestionModel>>('Question/GetTest');
  }
}
