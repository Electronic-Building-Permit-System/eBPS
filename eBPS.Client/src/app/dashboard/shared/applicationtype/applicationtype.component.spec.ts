import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationTypeComponent } from './applicationtype.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

describe('ApplicationtypeComponent', () => {
  let component: ApplicationTypeComponent;
  let fixture: ComponentFixture<ApplicationTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ApplicationTypeComponent, BrowserAnimationsModule]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApplicationTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
