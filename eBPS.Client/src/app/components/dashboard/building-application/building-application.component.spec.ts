import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BuildingApplicationComponent } from './building-application.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { provideHttpClient } from '@angular/common/http';

describe('BuildingApplicationComponent', () => {
  let component: BuildingApplicationComponent;
  let fixture: ComponentFixture<BuildingApplicationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BuildingApplicationComponent, BrowserAnimationsModule],
      providers:[provideHttpClient()]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BuildingApplicationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
