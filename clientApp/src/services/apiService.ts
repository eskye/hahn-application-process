import { inject } from "aurelia-framework";
import { HttpClient, json } from 'aurelia-fetch-client';
import { Applicant } from '../models/applicant'; 
import * as environment from '../../config/environment.json';

@inject(HttpClient)
export class ApiService { 
  constructor(private http : HttpClient){
      http.configure(config => {
        config.withBaseUrl(environment.apiUrl)
      });
   }

   save(applicant: Applicant): Promise<any>{
    return this.http.fetch('/Applicant', {
        method: 'post',
        body: json(applicant)
    });
}


getApiErrorMessage(response: Response){
  let result = ''
  debugger;
   switch (response.status) {
     case 400:
       result = response.statusText;
       break;
      case 500:
        result = 'Internal server error';
     default:
       break;
   }
   return result;
}
}