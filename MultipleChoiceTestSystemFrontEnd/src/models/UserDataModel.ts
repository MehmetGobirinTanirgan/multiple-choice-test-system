export class UserDataModel {
  public constructor(init?: Partial<UserDataModel>) {
    Object.assign(this, init);
  }

  name: string | undefined;
  surname: string | undefined;
  emailAddress: string | undefined;
  phoneNumber?: string | undefined;
}
