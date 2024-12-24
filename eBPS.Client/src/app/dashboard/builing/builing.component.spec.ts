import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BuilingComponent } from './builing.component';

describe('BuilingComponent', () => {
  let component: BuilingComponent;
  let fixture: ComponentFixture<BuilingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BuilingComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BuilingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
