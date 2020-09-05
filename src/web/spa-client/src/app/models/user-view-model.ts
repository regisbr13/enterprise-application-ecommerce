export class UserViewModel {
  Id: number;
  Name: string;
  Email: string;
  Telefone: string;

  constructor(data: any = {}) {
    this.Id = data.Id;
    this.Name = data.Name;
    this.Telefone = data.Telefone;
    this.Email = data.Email;
  }
}
