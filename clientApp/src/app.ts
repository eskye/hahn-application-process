import { PLATFORM } from 'aurelia-pal';
import { autoinject } from 'aurelia-framework';
import { Router, RouterConfiguration} from 'aurelia-router';
import {I18N} from 'aurelia-i18n'; 
import { Locale } from 'models/locale';  


@autoinject
export class App {  
  locales: Locale[] =  [
    {
        code: 'en-EN',
        title: 'English'
    },
    {
        code: 'de-DE',
        title: 'German'
    }
];
  currentLocale: string; 
  router: Router;
  

 constructor(private i18n: I18N)  {
   this.currentLocale = this.i18n.getLocale(); 
 }

 configureRouter(config: RouterConfiguration, router: Router){
  config.title = 'Home';
  config.options.pushState = true;
  config.options.root = '/';
  config.map([
    {route: '', moduleId: PLATFORM.moduleName('./pages/home/home'), name:'home', title: 'Home'},
    {route: 'success', moduleId: PLATFORM.moduleName('./pages/success/success'), name:'success', title: 'Success Page'},
  ]);

  this.router = router;
 }

 setLocale(code: string){ 
    this.i18n.setLocale(code);
    this.currentLocale = code;
}

}


