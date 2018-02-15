import {NgForm} from '@angular/forms';

export class FormHelper {
    /**
     * mark all form controlls as dirty
     * and validate form
     * @param form
     */
    public static markControllsAsDirty(form: NgForm): void {
        Object.keys(form.controls).forEach(key => {
            form.controls[key].markAsDirty();
            form.controls[key].markAsTouched();
            form.controls[key].updateValueAndValidity();
        });
    }

    public static isFromValid(form: NgForm): boolean {
        this.markControllsAsDirty(form);
      //  form.updateValueAndValidity();
        return form.valid;
    }
}
