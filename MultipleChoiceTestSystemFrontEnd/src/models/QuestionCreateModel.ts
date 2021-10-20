import { OptionCreateModel } from "./OptionCreateModel";

export class QuestionCreateModel {
  questionText: string | undefined;
  rightAnswer: string | undefined;
  options: Array<OptionCreateModel> = new Array<OptionCreateModel>();
}
