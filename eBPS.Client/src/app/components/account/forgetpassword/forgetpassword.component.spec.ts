import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; // Import for animations
import { ForgetpasswordComponent } from './forgetpassword.component';


describe('ForgetpasswordComponent', () => {
  let component: ForgetpasswordComponent;
  let fixture: ComponentFixture<ForgetpasswordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        ForgetpasswordComponent,
        ReactiveFormsModule,
        FormsModule,
        BrowserAnimationsModule // Add this for animations support
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(ForgetpasswordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize the form with email control', () => {
    expect(component.forgetPasswordForm.contains('email')).toBeTruthy();
    expect(component.forgetPasswordForm.get('email')).not.toBeNull();
  });

  it('should make email control required', () => {
    const emailControl = component.forgetPasswordForm.get('email');
    emailControl?.setValue('');
    expect(emailControl?.valid).toBeFalsy();
    expect(emailControl?.errors?.['required']).toBeTruthy();
  });

  it('should validate email control format', () => {
    const emailControl = component.forgetPasswordForm.get('email');
    emailControl?.setValue('invalid-email');
    expect(emailControl?.valid).toBeFalsy();
    expect(emailControl?.errors?.['email']).toBeTruthy();

    emailControl?.setValue('validemail@example.com');
    expect(emailControl?.valid).toBeTruthy();
  });

  it('should emit forget password event on valid submission', () => {
    spyOn(component, 'onSubmit'); // Spy on the onSubmit method
    const emailControl = component.forgetPasswordForm.get('email');
    emailControl?.setValue('validemail@example.com');

    const form = fixture.debugElement.nativeElement.querySelector('form');
    form.dispatchEvent(new Event('submit'));

    expect(component.onSubmit).toHaveBeenCalled();
  });
});
