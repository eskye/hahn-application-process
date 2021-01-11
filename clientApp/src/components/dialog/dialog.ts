import { DialogController } from 'aurelia-dialog';
import { autoinject } from 'aurelia-framework';  

@autoinject
export class Dialog{  
title?: string;
message?: string; 
 constructor(public controller: DialogController) {
     this.controller.settings.centerHorizontalOnly = true;
 }
 activate(model : any) { 
    this.message = model.message;
    this.title = model.title; 
 }

}