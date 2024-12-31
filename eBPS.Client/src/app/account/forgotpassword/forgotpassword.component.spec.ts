import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; // Import for animations
import { ForgotpasswordComponent } from './forgotpassword.component';

describe('ForgotpasswordComponent', () => {
  let component: ForgotpasswordComponent;
  let fixture: ComponentFixture<ForgotpasswordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        ForgotpasswordComponent,
        ReactiveFormsModule,
        FormsModule,
        BrowserAnimationsModule // Add this for animations support
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(ForgotpasswordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize the form with email control', () => {
    expect(component.forgotPasswordForm.contains('email')).toBeTruthy();
    expect(component.forgotPasswordForm.get('email')).not.toBeNull();
  });

  it('should make email control required', () => {
    const emailControl = component.forgotPasswordForm.get('email');
    emailControl?.setValue('');
    expect(emailControl?.valid).toBeFalsy();
    expect(emailControl?.errors?.['required']).toBeTruthy();
  });

  it('should validate email control format', () => {
    const emailControl = component.forgotPasswordForm.get('email');
    emailControl?.setValue('invalid-email');
    expect(emailControl?.valid).toBeFalsy();
    expect(emailControl?.errors?.['email']).toBeTruthy();

    emailControl?.setValue('validemail@example.com');
    expect(emailControl?.valid).toBeTruthy();
  });

  it('should emit forgot password event on valid submission', () => {
    spyOn(component, 'onSubmit'); // Spy on the onSubmit method
    const emailControl = component.forgotPasswordForm.get('email');
    emailControl?.setValue('validemail@example.com');

    const form = fixture.debugElement.nativeElement.querySelector('form');
    form.dispatchEvent(new Event('submit'));

    expect(component.onSubmit).toHaveBeenCalled();
  });
});
