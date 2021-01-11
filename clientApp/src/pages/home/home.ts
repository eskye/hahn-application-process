import { autoinject } from "aurelia-framework";
import { Router } from "aurelia-router"; 
import {
  Validator,
  ValidationController,
  ValidationControllerFactory,
  ValidationRules,
  validateTrigger,
} from "aurelia-validation";
import { DialogService } from "aurelia-dialog";

import { BootstrapFormRenderer } from "../../bootstrap-form-renderer";
import { ApiService } from "../../services/apiService";

import { Applicant } from "../../models/applicant"; 
import { Dialog } from "../../components/dialog/dialog";

@autoinject
export class Home {
  applicant: Applicant = new Applicant();
  private controller: ValidationController;
  canSave: boolean; 
  isLoading: boolean = false;
  canReset: boolean;

  constructor(
    private validationControllerFactory: ValidationControllerFactory,
    private validator: Validator, 
    private dialogService: DialogService,
    private router: Router,
    private apiService: ApiService
  ) {
    this.controller = this.validationControllerFactory.createForCurrentScope(
      validator
    );
    this.controller.addRenderer(new BootstrapFormRenderer());
    this.controller.validateTrigger = validateTrigger.changeOrBlur;
    this.controller.subscribe((event) => this.validateWhole());
    this.setupValidation(); 
  }

  async submit() {
    this.isLoading = true;
    const response = await this.apiService.save(this.applicant);
    this.isLoading = false;
    if (response.status === 201) {
      this.applicant = new Applicant();
      this.router.navigateToRoute("success");
      return;
    }

    const error = await response.json();
    console.log(error.message);
    if(error)
      this.openErrorDialog(error.message);

    return;
  }

  openResetDialog() {
    this.dialogService
      .open({
        viewModel: Dialog,
        model: { message: "Are you sure", title: "Confirmation" },
      })
      .whenClosed((response) => {
        if (response.wasCancelled) return false;
        this.applicant = new Applicant();
      });
  }

  openErrorDialog(errorMessage: string) {
    this.dialogService
      .open({
        viewModel: Dialog,
        model: { message: errorMessage, title: "Error" },
      })
      .whenClosed((response) => {
        if (response.wasCancelled) return false;
      });
  }

  private validateWhole() {
    this.validator
      .validateObject(this.applicant)
      .then(
        (results) => (this.canSave = results.every((result) => result.valid))
      );
    this.canReset = this.validateReset(); 
  }

  private validateReset(): boolean {
    return (this.canReset = Object.values(this.applicant).some(
      (v) => v != null && v != undefined && v != ""));
  }


  setupValidation() {
    ValidationRules.ensure((a: Applicant) => a.name)
      .required()
      .minLength(5)
      .ensure((a: Applicant) => a.familyName)
      .required()
      .minLength(5)
      .ensure((a: Applicant) => a.emailAddress)
      .required()
      .email()
      .ensure((a: Applicant) => a.age)
      .required()
      .range(20, 60)
      .ensure((a: Applicant) => a.address)
      .required()
      .minLength(5)
      .ensure((a: Applicant) => a.countryOfOrigin)
      .required()
      .minLength(5)
      .on(this.applicant);
  }
}
