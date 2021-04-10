import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductComponent } from './product.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    ProductComponent,
    ProductItemComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [ProductComponent]
})
export class ProductModule { }
