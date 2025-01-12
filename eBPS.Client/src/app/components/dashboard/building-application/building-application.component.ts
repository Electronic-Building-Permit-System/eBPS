import { AfterViewInit, Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';
import { MatTableDataSource } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatToolbarModule } from '@angular/material/toolbar';
import { Router } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { ApplicationService } from '../../../services/shared/application/application.service';
@Component({
  selector: 'app-building-application',
  imports: [MatTableModule,
    MatButtonModule, MatSidenavModule,
    MatIconModule, CommonModule, MatListModule, MatToolbarModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatPaginatorModule],
  templateUrl: './building-application.component.html',
  styleUrl: './building-application.component.css'
})
export class BuildingApplicationComponent implements OnInit, AfterViewInit {

  // Data source for MatTable
  dataSource = new MatTableDataSource<any>([]);

  // Data array for building applications
  buildingApplication: any[] = [];

  // Columns to display in the table
  displayedColumns: string[] = ['applicantName']; 

  // ViewChild to reference paginator
  @ViewChild(MatPaginator) paginator: MatPaginator | null = null;

  constructor(private router: Router, private applicationService: ApplicationService) {}

  ngOnInit(): void {
    // Fetch data when the component initializes
    this.fetchBuildingApplication();
  }

  ngAfterViewInit(): void {
    // Assign the paginator after the view has initialized
    if (this.paginator) {
      this.dataSource.paginator = this.paginator;
    }
  }

  /**
   * Fetches the building applications from the service and initializes the data source.
   */
  fetchBuildingApplication(): void {
    this.applicationService.getBuildingApplication().subscribe(
      (data: { applicantName: string }[]) => {
        this.buildingApplication = data;
        this.dataSource.data = this.buildingApplication; // Bind data to MatTableDataSource
      },
      (error) => {
        console.error('Error fetching building applications:', error); // Log errors
      }
    );
  }

  /**
   * Navigates to the create application page.
   */
  opencreateapplication(): void {
    this.router.navigate(['createapplication']);
  }
  opendesigndata() {
    this.router.navigate(['designdata']);
    }

  /**
   * Filters the table data based on the input value.
   * @param event The keyboard event containing the filter value.
   */
  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value.trim().toLowerCase();
    
    // Filter the data
    this.dataSource.filterPredicate = (data, filter) => 
      data.applicantName.toLowerCase().includes(filter);
    this.dataSource.filter = filterValue;

    // Reset paginator to the first page when filtering
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}
