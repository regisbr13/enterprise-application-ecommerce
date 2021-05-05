export class UserViewModel {
  Id: number;
  Name: string;
  Email: string;
  Phone: string;

  constructor(data: any = {}) {
    this.Id = data.Id;
    this.Name = data.Name;
    this.Phone = data.Phone;
    this.Email = data.Email;
  }
}
