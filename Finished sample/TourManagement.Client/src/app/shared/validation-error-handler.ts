import { FormGroup } from "@angular/forms";

export class ValidationErrorHandler {

    static handleValidationErrors(form: FormGroup, validationResult: any): void {
        for (var property in validationResult) {
          if (validationResult.hasOwnProperty(property)) {
    
            if (form.controls[property]) {
              // single field
              var validationErrorsForFormField = {};
              for (var validationError of validationResult[property]) {
                validationErrorsForFormField[validationError.validatorKey] = true;
              }
              form.controls[property].setErrors(validationErrorsForFormField);
            }
            else {
              // cross field
              var validationErrorsForForm = {};
              for (var validationError of validationResult[property]) {
                validationErrorsForForm[validationError.validatorKey] = true;
              }
              form.setErrors(validationErrorsForForm);
            }
          }
        }
      }
}
