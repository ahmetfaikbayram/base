import { AfterViewInit } from '@angular/core';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { fromEvent, merge } from 'rxjs';
import { debounceTime, distinctUntilChanged, tap } from 'rxjs/operators';
import { IBrand } from '../shared/models/brand';
import { BrandDataSource } from './brand.datasource';
import { BrandService } from './brand.service';

@Component({
  selector: 'app-brand',
  templateUrl: './brand.component.html',
  styleUrls: ['./brand.component.scss']
})
export class BrandComponent implements OnInit, AfterViewInit {
  brands: IBrand[];

  dataSource: BrandDataSource;
  displayedColumns = ["id", "name"];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild('input') input: ElementRef;

  constructor(private brandService: BrandService) { }

  ngOnInit(): void {
    // this.getAllBrands();

    this.dataSource = new BrandDataSource(this.brandService);
    this.dataSource.loadBrands('', 'asc', 0, 3);
  }

  ngAfterViewInit() {
    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

    fromEvent(this.input.nativeElement, 'keyup')
      .pipe(
        debounceTime(150),
        distinctUntilChanged(),
        tap(() => {
          this.paginator.pageIndex = 0;

          this.loadBrandsPage();
        })
      )
      .subscribe();

    merge(this.sort.sortChange, this.paginator.page)
      .pipe(
        tap(() => this.loadBrandsPage())
      )
      .subscribe();
  }

  getAllBrands() {
    this.brandService.getAllBrands().subscribe(response => {
      this.brands = response;
    }, error => {
      console.log(error);
    });
  }

  loadBrandsPage() {
    this.dataSource.loadBrands(
      this.input.nativeElement.value,
      this.sort.direction,
      this.paginator.pageIndex,
      this.paginator.pageSize);
  }

  getTotalCount() {
    return this.brandService.totalCount;
  }

}
