import { Component, OnInit } from '@angular/core';
import { IConsole } from 'src/app/shared/models/console';
import { ConsoleService } from '../console.service';
import { ActivatedRoute } from '@angular/router';
import { IBrand } from 'src/app/shared/models/brand';
import { ITechnicalSpecification } from 'src/app/shared/models/technicalSpecification';
import { ICompany } from 'src/app/shared/models/company';

@Component({
  selector: 'app-console-details',
  templateUrl: './console-details.component.html',
  styleUrls: ['./console-details.component.scss']
})
export class ConsoleDetailsComponent implements OnInit {

  console!: IConsole;
  brand!: IBrand;
  technicalSpecification!: ITechnicalSpecification;
  company!: ICompany;

  constructor(
    private consoleService: ConsoleService,
    private activateRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.loadConsole();
  }

  loadConsole() {
    const id = this.activateRoute.snapshot.paramMap.get('id');
    if (id) {
      this.consoleService.getConsole(+id!).subscribe({
        next: console => {
          this.console = console;
          this.getBrand(console.brandId!);
          this.getTechnicalSpecification(console.technicalSpecificationId!);
          this.getCompany(console.companyId!);
        },
        error: error => console.log(error)
      })
    }
  }

  getBrand(brandId: number) {
    this.consoleService.getBrand(brandId).subscribe({
      next: brand => this.brand = brand,
      error: error => console.log(error)
    });
  }

  getTechnicalSpecification(technicalSpecificationId: number) {
    this.consoleService.getTechnicalSpecification(technicalSpecificationId).subscribe({
      next: technicalSpecification => this.technicalSpecification = technicalSpecification,
      error: error => console.log(error)
    });
  }

  getCompany(companyId: number) {
    this.consoleService.getCompany(companyId).subscribe({
      next: company => this.company = company,
      error: error => console.log(error)
    });
  }

}
