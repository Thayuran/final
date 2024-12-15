import { Component, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Category } from '../../../models/category';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-category',
  standalone: false,

  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent {

  public dataSource = new MatTableDataSource<Category>();

  // @ViewChild(MatSort) sort: MatSort;
  // @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private router: Router,
    private authService: AuthService
  ) {}

  public redirectToUpdate = (id: string) => {
    this.router.navigate([`/ui-components/update-category/${id}`]);
  };

  public deleteCategory(id: string) {
    // if (this.authService.isUserAdmin()) {
    //   this.dialogserve
    //     .openConfirmDialog('Are you sure you want to delete this category?')
    //     .afterClosed()
    //     .subscribe((res) => {
    //       if (res) {
    //         const deleteUri: string = `api/categories/${id}`;
    //         this.repoService.delete(deleteUri).subscribe(() => {
    //           const config: ModalOptions = {
    //             initialState: {
    //               modalHeaderText: 'Success Message',
    //               modalBodyText: `Category deleted successfully`,
    //               okButtonText: 'OK',
    //             },
    //           };

    //           this.bsModalRef = this.modal.show(SuccessModalComponent, config);
    //           this.bsModalRef.content.redirectOnOk.subscribe(() =>
    //             this.getAllCategories()
    //           );
    //         });
    //       }
    //     });
    // } else {
    //   const config: ModalOptions = {
    //     initialState: {
    //       modalHeaderText: 'Error Message',
    //       modalBodyText: 'Only Admin allowed',
    //       okButtonText: 'OK',
    //     },
    //   };
    //   this.modal.show(ErrorModalComponent, config);
    // }
  }
}
