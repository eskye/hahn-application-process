export class Applicant{
  name: string;
  familyName: string;
  emailAddress: string;
  age: number;
  address: string;
  countryOfOrigin: string;
  hired: boolean;
  constructor(applicantObject?){
    if(applicantObject == null) return;
      Object.assign(this, applicantObject);
  }
}