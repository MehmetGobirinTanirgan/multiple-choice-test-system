import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { OptionCreateModel } from 'src/models/OptionCreateModel';
import { QuestionCreateModel } from 'src/models/QuestionCreateModel';
import { QuestionModel } from 'src/models/QuestionModel';
import { QuestionService } from 'src/services/question.service';

@Component({
  selector: 'app-add-new-question',
  templateUrl: './add-new-question.component.html',
  styleUrls: ['./add-new-question.component.css'],
})
export class AddNewQuestionComponent implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private questionService: QuestionService
  ) {}

  newQuestionForm: FormGroup | undefined;
  addedQuestion: QuestionModel | undefined;

  ngOnInit() {
    this.createNewQuestionForm();
  }

  createNewQuestionForm(): void {
    this.newQuestionForm = this.formBuilder.group({
      questionText: ['', Validators.required],
      rightAnswer: ['', [Validators.required, Validators.maxLength(100)]],
      option1: ['', [Validators.required, Validators.maxLength(100)]],
      option2: ['', [Validators.required, Validators.maxLength(100)]],
      option3: ['', [Validators.required, Validators.maxLength(100)]],
      option4: ['', [Validators.required, Validators.maxLength(100)]],
    });
  }

  addNewQuestion() {
    if (this.newQuestionForm?.valid) {
      let newQuestion: QuestionCreateModel = new QuestionCreateModel();
      newQuestion.questionText =
        this.newQuestionForm.get('questionText')?.value;
      newQuestion.rightAnswer = this.newQuestionForm.get('rightAnswer')?.value;

      for (let i = 0; i < 4; i++) {
        const newOption: OptionCreateModel = new OptionCreateModel();
        newOption.optionText = this.newQuestionForm.get(
          `option${i + 1}`
        )?.value;
        newQuestion.options?.push(newOption);
      }

      this.questionService.addNewQuestion(newQuestion).subscribe(
        (data) => {
          this.addedQuestion = data;
          this.newQuestionForm?.reset();
        },
        (error) => {
          alert('Error: Creation of question failed.');
        }
      );
    }
  }
}
