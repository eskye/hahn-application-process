import { autoinject, inject } from 'aurelia-framework';
import { Applicant } from './models/applicant';
import { Router } from 'aurelia-router';
import {
  Validator,
  ValidationController,
  ValidationControllerFactory,
  ValidationRules,
  validateTrigger, 
} from 'aurelia-validation';
import { BootstrapFormRenderer } from './bootstrap-form-renderer';
import { ApiService } from './services/apiService';


@autoinject
export class App {
  public applicant: Applicant = {
    address: '',
    age: 0,
    countryOfOrigin: '',
    emailAddress: '',
    familyName: '',
    hired: true,
    name: ''
  };
  private controller: ValidationController;
  canSave: boolean;

 constructor(private validationControllerFactory : ValidationControllerFactory, private validator: Validator, private apiService: ApiService){
   this.controller = this.validationControllerFactory.createForCurrentScope(validator);
   this.controller.addRenderer(new BootstrapFormRenderer())
   this.controller.validateTrigger = validateTrigger.changeOrBlur;
   this.controller.subscribe(event => this.validateWhole());
   this.setupValidation();
 }

 submit(){
   console.log(this.applicant);
   this.controller.validate().then(result => {
     if(result.valid){
       this.apiService.save(this.applicant).then(result => {
            console.log(result);
       }).catch(error => console.log(error));
     }
     else {
       console.log('error', result);
       
     }
   })
 }

 private validateWhole() {
  this.validator.validateObject(this.applicant)
      .then(results => this.canSave = results.every(result => result.valid));
}

 public setupValidation(){
  ValidationRules
  .ensure((a: Applicant) => a.name).required().minLength(5)
  .ensure((a: Applicant) => a.familyName).required().minLength(5)
  .ensure((a: Applicant) => a.emailAddress).required().email()
  .ensure((a: Applicant) => a.age).required().between(20, 60)
  .ensure((a: Applicant) => a.address).required().minLength(5)
  .ensure((a: Applicant) => a.countryOfOrigin).required().minLength(5)
  .on(this.applicant)
 }

}


