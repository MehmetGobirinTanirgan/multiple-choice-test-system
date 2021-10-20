import { OptionModel } from "./OptionModel";

export class QuestionModel {
  id: string | undefined;
  questionText: string | undefined;
  rightAnswer: string | undefined;
  options: Array<OptionModel> | undefined;
}
