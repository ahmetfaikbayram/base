import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BrandService {
  baseUrl = environment.apiUrl;

  totalCount: number;

  constructor(private http: HttpClient) { }

  getAllBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'brands/getallbrands');
  }

  getBrands(
    search = '', sortDirection = 'asc',
    pageIndex = 0, pageSize = 3): Observable<IBrand[]> {
    let params = new HttpParams();

    if (search) {
      params = params.append('search', search);
    }
    params = params.append('sort', sortDirection);
    params = params.append('pageIndex', pageIndex.toString());
    params = params.append('pageSize', pageSize.toString());

    return this.http.get(this.baseUrl + 'brands', {
      params
    }).pipe(
      map(res => {
        this.totalCount = res["count"];
        return res["data"];
      })
    );
  }

}
