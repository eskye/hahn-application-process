export class Applicant{
  name: string;
  familyName: string;
  emailAddress: string;
  age: number;
  address: string;
  countryOfOrigin: string;
  hired: boolean;
  constructor(applicantObject){
      Object.assign(this, applicantObject);
  }
}