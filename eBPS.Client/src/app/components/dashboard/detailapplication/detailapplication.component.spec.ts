import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailapplicationComponent } from './detailapplication.component';
import { provideHttpClient } from '@angular/common/http';

describe('DetailapplicationComponent', () => {
  let component: DetailapplicationComponent;
  let fixture: ComponentFixture<DetailapplicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DetailapplicationComponent],
      providers:[provideHttpClient()]
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
