import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { ConsoleParams } from '../shared/models/consoleParams';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagination } from '../shared/models/pagination';
import { IConsole } from '../shared/models/console';
import { IBrand } from '../shared/models/brand';
import { ITechnicalSpecification } from '../shared/models/technicalSpecification';
import { ICompany } from '../shared/models/company';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ConsoleService {

  baseUrl = environment.apiUrl;
  consoleParams = new ConsoleParams();

  constructor(private http: HttpClient) { }

  getConsoles(consoleParams: ConsoleParams) {
    let params = new HttpParams();

    if (consoleParams.brandId > 0) params = params.append('brandId', consoleParams.brandId);

    params = params.append('sort', consoleParams.sort);
    params = params.append('pageIndex', consoleParams.pageNumber);
    params = params.append('pageSize', consoleParams.pageSize!);
    if (consoleParams.search) params = params.append('search', consoleParams.search);

    return this.http.get<IPagination<IConsole[]>>(this.baseUrl + 'gameconsoles', { params });
  }

  getConsole(id: number) {
    return this.http.get<IConsole>(`${this.baseUrl}gameconsoles/${id}`);
  }

  getBrands() {
    return this.http.get<IBrand[]>(`${this.baseUrl}brands`);
  }

  getBrand(brandId: number): Observable<IBrand> {
    return this.http.get<IBrand>(`${this.baseUrl}brands/${brandId}`);
  }
  getTechnicalSpecification(technicalSpecificationId: number): Observable<ITechnicalSpecification> {
    return this.http.get<ITechnicalSpecification>(`${this.baseUrl}technicalSpecifications/${technicalSpecificationId}`);
  }
  getCompany(companyId: number): Observable<ICompany> {
    return this.http.get<ICompany>(`${this.baseUrl}companies/${companyId}`);
  }


}
