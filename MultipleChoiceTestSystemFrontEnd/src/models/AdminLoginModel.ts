export class AdminLoginModel {
  public constructor(init?: Partial<AdminLoginModel>) {
    Object.assign(this, init);
  }
  username: string | undefined;
  password: string | undefined;
}
