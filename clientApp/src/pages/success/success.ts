import { inject } from 'aurelia-framework';
import { Router } from 'aurelia-router';

@inject(Router)
export class Success{ 
    constructor(private router: Router) {}

    goBack(){
        this.router.navigateToRoute('home');
    }
}