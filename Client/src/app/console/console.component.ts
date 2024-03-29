import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IConsole } from '../shared/models/console';
import { IBrand } from '../shared/models/brand';
import { ConsoleParams } from '../shared/models/consoleParams';
import { ConsoleService } from './console.service';

@Component({
  selector: 'app-console',
  templateUrl: './console.component.html',
  styleUrls: ['./console.component.scss']
})
export class ConsoleComponent implements OnInit {

  @ViewChild('search') searchTerm?: ElementRef;

  consoles!: IConsole[];
  brands!: IBrand[];
  consoleParams = new ConsoleParams();

  sortOption = [
    { name: 'Alphabetial (A - Z)', value: 'ConsoleName' },
    { name: 'Release Date: Desc To Asc', value: 'releaseDateAsc' },
    { name: 'Release Date: Asc To Desc', value: 'releaseDateDesc' }
  ];

  totalCount = 0;

  constructor(
    private consoleService: ConsoleService,
  ) { }

  ngOnInit(): void {
    this.getConsoles();
    this.getBrands();
  }

  getConsoles() {
    this.consoleService.getConsoles(this.consoleParams).subscribe({
      next: response => {
        this.consoles = response.data;
        this.consoleParams.pageNumber = response.pageIndex;
        this.consoleParams.pageSize = response.pageSize;
        this.totalCount = response.count;

        console.log('Consoles response:', response);
      },
      error: error => console.error('Error fetching consoles:', error)
    });
  }
  getBrands() {
    this.consoleService.getBrands().subscribe({
      next: response => {
        console.log(response);
        this.brands = [{ id: 0, brandName: 'All' }, ...response]
      },
      error: error => console.log(error)
    });
  }

  onBrandSelected() {
    this.consoleParams.pageNumber = 1;
    this.getConsoles();
  }
  onSortSelected(event: any) {
    this.consoleParams.sort = event.target.value;
    this.getConsoles();
  }

  onPageChanged(event: any) {
    if (this.consoleParams.pageNumber !== event) {
      this.consoleParams.pageNumber = event;
      this.getConsoles();
    }
  }

  onSearch() {
    this.consoleParams.search = this.searchTerm?.nativeElement.value;
    this.consoleParams.pageNumber = 1;
    this.getConsoles();
  }

}
