import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateapplicationComponent } from './createapplication.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

describe('CreateapplicationComponent', () => {
  let component: CreateapplicationComponent;
  let fixture: ComponentFixture<CreateapplicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateapplicationComponent, BrowserAnimationsModule]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateapplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
