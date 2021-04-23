import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BrandService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'brands');
  }
}
