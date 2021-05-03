import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IProduct } from '../shared/models/product';
import { ProductService } from './product.service';
import { ProductParams } from '../shared/models/productParams';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  @ViewChild('search', { static: false }) searchTerm: ElementRef;
  products: IProduct[];
  brands: IBrand[];
  productParams = new ProductParams();
  totalCount: number;
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' }
  ];

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getAllBrands();
  }

  getProducts() {
    this.productService.getProducts(this.productParams)
      .subscribe(response => {
        this.products = response.data;
        this.productParams.pageNumber = response.pageIndex;
        this.productParams.pageSize = response.pageSize;
        this.totalCount = response.count;
      }, error => {
        console.log(error);
      });
  }

  getAllBrands() {
    this.productService.getAllBrands().subscribe(response => {
      this.brands = [{ id: 0, name: 'All' }, ...response];
    }, error => {
      console.log(error);
    });
  }

  onBrandSelected(brandId: number) {
    this.productParams.brandId = brandId;
    this.productParams.pageNumber = 1;
    this.getProducts();
  }

  onSortSelected(sort: string) {
    this.productParams.sort = sort;
    this.getProducts();
  }

  onPageChanged(event: any) {
    if (this.productParams.pageNumber !== event) {
      this.productParams.pageNumber = event;
      this.getProducts();
    }
  }

  onSearch() {
    this.productParams.search = this.searchTerm.nativeElement.value;
    this.productParams.pageNumber = 1;
    this.getProducts();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.productParams = new ProductParams();
    this.getProducts();
  }

}
