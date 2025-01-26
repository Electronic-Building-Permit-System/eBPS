import { Directive, HostListener } from '@angular/core';

@Directive({
  selector: '[appDecimalOnly]', // Use this attribute in templates
})
export class DecimalOnlyDirective {
  private regex: RegExp = /^\d*\.?\d*$/; // Allow numbers and a single decimal point
  private allowedKeys: string[] = ['Backspace', 'Tab', 'ArrowLeft', 'ArrowRight', 'Delete', 'Home', 'End'];

  @HostListener('keydown', ['$event'])
  onKeyDown(event: KeyboardEvent): void {
    // Allow special keys
    if (this.allowedKeys.includes(event.key)) {
      return;
    }

    // Block invalid keys
    const current: string = (event.target as HTMLInputElement).value;
    const next: string = current.concat(event.key);
    if (!this.regex.test(next)) {
      event.preventDefault();
    }
  }
}
