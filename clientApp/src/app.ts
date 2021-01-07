import { inject } from 'aurelia-framework';
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


@inject(ValidationControllerFactory)
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

 constructor(validationControllerFactory){
   this.controller = validationControllerFactory.createForCurrentScope();
   this.controller.addRenderer(new BootstrapFormRenderer())
   this.controller.validateTrigger = validateTrigger.change;
 }

 submit(){
   console.log(this.applicant);
   this.controller.validate().then(result => {
     if(result.valid){
       console.log('valid', result);
     }
     else {
       console.log('error', result);
       
     }
   })
 }

}

ValidationRules
.ensure((a: Applicant) => a.name).required().minLength(5)
.ensure((a: Applicant) => a.familyName).required().minLength(5)
.ensure((a: Applicant) => a.emailAddress).required().email()
.ensure((a: Applicant) => a.age).required().between(20, 60)
.ensure((a: Applicant) => a.address).required().min(5)
.ensure((a: Applicant) => a.countryOfOrigin).required().min(5)
.on(Applicant)
