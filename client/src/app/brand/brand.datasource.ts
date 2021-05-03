import { CollectionViewer, DataSource } from "@angular/cdk/collections";
import { Observable } from "rxjs";
import { of } from "rxjs";
import { BehaviorSubject } from "rxjs";
import { catchError, finalize } from "rxjs/operators";
import { IBrand } from "../shared/models/brand";
import { BrandService } from "./brand.service";

export class BrandDataSource implements DataSource<IBrand> {

    private brandsSubject = new BehaviorSubject<IBrand[]>([]);

    constructor(private brandService: BrandService) { }

    connect(collectionViewer: CollectionViewer): Observable<IBrand[]> {
        return this.brandsSubject.asObservable();
    }

    disconnect(collectionViewer: CollectionViewer): void {
        this.brandsSubject.complete();
    }

    loadBrands(search = '',
        sortDirection = 'asc', pageIndex = 0, pageSize = 3) {

        this.brandService.getBrands(search, sortDirection,
            pageIndex, pageSize).pipe(
                catchError(() => of([]))
            )
            .subscribe(brands => this.brandsSubject.next(brands));
    }
}