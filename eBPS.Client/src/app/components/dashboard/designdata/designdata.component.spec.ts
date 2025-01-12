import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DesigndataComponent } from './designdata.component';

describe('DesigndataComponent', () => {
  let component: DesigndataComponent;
  let fixture: ComponentFixture<DesigndataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DesigndataComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DesigndataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
