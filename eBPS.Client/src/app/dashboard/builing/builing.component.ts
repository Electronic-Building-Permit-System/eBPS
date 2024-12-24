import { Component, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';
import { MatTableDataSource } from '@angular/material/table';
import { MatFormFieldModule, MatLabel } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatToolbarModule } from '@angular/material/toolbar';
@Component({
  selector: 'app-builing',
  imports: [MatTableModule,
    MatButtonModule,MatSidenavModule,
    MatIconModule, CommonModule, MatLabel,MatListModule,MatToolbarModule, MatFormFieldModule, MatInputModule,MatPaginatorModule],
  templateUrl: './builing.component.html',
  styleUrl: './builing.component.css'
})
export class BuilingComponent implements OnInit {
  opened = true; 
  toggleSidebar() {
    this.opened = !this.opened;
}
  displayedColumns: string[] = ['applicationNumber', 'applicantName', 'transactionType','applicationDate','forward','edit','detail','delete','quickComments']; // Add other columns
  dataSource = new MatTableDataSource([
    { applicationNumber: '001', applicantName: 'John Doe' },
    { applicationNumber: '002', applicantName: 'Jane Smith' },
    { applicationNumber: '003', applicantName: 'Alice Brown' },
    { applicationNumber: '004', applicantName: 'Hazel' },
    { applicationNumber: '005', applicantName: 'Ariel ' },
    { applicationNumber: '006', applicantName: 'Selena' },

    // Add more sample data
  ]);
  forward(element: any) {
    console.log('Forward clicked', element);
  }
  
  edit(element: any) {
    console.log('Edit clicked', element);
  }
  
  viewDetails(element: any) {
    console.log('View details', element);
  }
  
  delete(element: any) {
    console.log('Delete clicked', element);
  }
  filteredDataSource = this.dataSource;
  @ViewChild(MatPaginator) paginator: MatPaginator |  null = null;;
  ngOnInit(): void {}

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value.trim().toLowerCase();
    this.filteredDataSource = new MatTableDataSource(
      this.dataSource.filteredData.filter(
        (item: any) =>
          item.applicationNumber.toLowerCase().startsWith(filterValue.toLowerCase()) ||
        item.applicantName.toLowerCase().startsWith(filterValue.toLowerCase())
       )
    );
      // Reassign paginator after filtering
      this.filteredDataSource.paginator = this.paginator;
  }
}
