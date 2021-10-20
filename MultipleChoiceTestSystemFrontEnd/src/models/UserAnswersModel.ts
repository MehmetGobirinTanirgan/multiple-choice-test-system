export class UserAnswersModel {
  public constructor(init?: Partial<UserAnswersModel>) {
    Object.assign(this, init);
  }

  Q1: string | undefined;
  Q2: string | undefined;
  Q3: string | undefined;
  Q4: string | undefined;
  Q5: string | undefined;
  Q6: string | undefined;
  Q7: string | undefined;
  Q8: string | undefined;
  Q9: string | undefined;
  Q10: string | undefined;
}
