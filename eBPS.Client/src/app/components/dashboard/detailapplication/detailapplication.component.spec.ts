import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailapplicationComponent } from './detailapplication.component';

describe('DetailapplicationComponent', () => {
  let component: DetailapplicationComponent;
  let fixture: ComponentFixture<DetailapplicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DetailapplicationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailapplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
