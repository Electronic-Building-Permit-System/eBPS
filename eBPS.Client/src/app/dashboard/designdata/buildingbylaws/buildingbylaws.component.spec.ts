import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BuildingbylawsComponent } from './buildingbylaws.component';

describe('BuildingbylawsComponent', () => {
  let component: BuildingbylawsComponent;
  let fixture: ComponentFixture<BuildingbylawsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BuildingbylawsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BuildingbylawsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
