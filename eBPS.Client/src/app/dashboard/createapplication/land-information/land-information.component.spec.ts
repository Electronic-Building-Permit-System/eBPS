import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LandInformationComponent } from './land-information.component';

describe('LandInformationComponent', () => {
  let component: LandInformationComponent;
  let fixture: ComponentFixture<LandInformationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LandInformationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LandInformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
