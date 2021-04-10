import { Component, OnInit } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { ProductService } from './product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  products: IProduct[];

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.productService.getProducts().subscribe(response => {
      this.products = response.data
    }, error => {
      console.log(error);
    });
  }

}
