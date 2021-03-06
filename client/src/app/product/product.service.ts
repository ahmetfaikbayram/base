import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IPagination } from '../shared/models/pagination';
import { map } from 'rxjs/operators';
import { ProductParams } from '../shared/models/productParams';
import { IProduct } from '../shared/models/product';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getProducts(productParams: ProductParams) {
    let params = new HttpParams();

    if (productParams.brandId !== 0) {
      params = params.append('brandId', productParams.brandId.toString());
    }

    if (productParams.search) {
      params = params.append('search', productParams.search);
    }

    params = params.append('sort', productParams.sort);
    params = params.append('pageIndex', productParams.pageNumber.toString());
    params = params.append('pageSize', productParams.pageSize.toString());

    return this.http.get<IPagination>(this.baseUrl + 'products', { observe: 'response', params })
      .pipe(
        map(response => {
          return response.body;
        })
      )
  }

  getProduct(id: number) {
    return this.http.get<IProduct>(this.baseUrl + 'products/' + id);
  }

  getAllBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'brands/getallbrands');
  }
}
