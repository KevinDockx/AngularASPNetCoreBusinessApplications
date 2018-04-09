import { AbstractControl } from "@angular/forms";

export class CustomValidators {
    static StartDateBeforeEndDateValidator(control: AbstractControl) {
        let startDate = control.get('startDate');
        let endDate = control.get('endDate');
        if (startDate.value < endDate.value) {
            return null;
        }
        return { 'startDateBeforeEndDate': true }
    }
}