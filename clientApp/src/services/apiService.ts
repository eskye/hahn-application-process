import { inject } from "aurelia-framework";
import { HttpClient, json } from 'aurelia-fetch-client';
import { Applicant } from '../models/applicant';
import { method } from "lodash";

@inject(HttpClient)
export class ApiService { 
  constructor(private http : HttpClient){
      http.configure(config => {
        config.withBaseUrl('http://localhost:5000')
      });
   }

   save(applicant: Applicant): Promise<any>{
    return this.http.fetch('/Applicant', {
        method: 'post',
        body: json(applicant)
    }) .then(response => response.json())
    .catch(error => console.log(error));
}

}