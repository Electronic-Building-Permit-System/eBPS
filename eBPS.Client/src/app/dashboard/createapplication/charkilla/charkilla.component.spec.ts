import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CharkillaComponent } from './charkilla.component';

describe('CharkillaComponent', () => {
  let component: CharkillaComponent;
  let fixture: ComponentFixture<CharkillaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CharkillaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CharkillaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
