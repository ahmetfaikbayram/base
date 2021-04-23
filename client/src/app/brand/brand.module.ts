import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrandComponent } from './brand.component';
import { SharedModule } from '../shared/shared.module';
import { BrandRoutingModule } from './brand-routing.module';



@NgModule({
  declarations: [
    BrandComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    BrandRoutingModule
  ]
})
export class BrandModule { }
