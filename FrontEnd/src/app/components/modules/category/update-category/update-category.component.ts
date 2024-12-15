import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from '../../../../models/category';

@Component({
  selector: 'app-update-category',
  standalone: false,

  templateUrl: './update-category.component.html',
  styleUrl: './update-category.component.css'
})
export class UpdateCategoryComponent {


  public categoryForm: FormGroup | any;
  private categoryId: string | null = '';

  constructor(
    private router: Router,
    private route: ActivatedRoute
  ) { }


  hasError = (controlName: string, errorName: string) => {
    if (this.categoryForm.get(controlName).hasError(errorName))
      return true;

    return false;
  }

  updateCategory = (categoryFormValue: any) => {
    if (this.categoryForm.valid)
      this.executeCategoryUpdate(categoryFormValue);
  }

  private executeCategoryUpdate = (categoryFormValue: any) => {
    const updatedCategory: Category = {
      id: this.categoryId ? this.categoryId : '',
      name: categoryFormValue.name
    };

    const apiUrl = `api/categories/${this.categoryId}`;
    // this.repository.update(apiUrl, updatedCategory)
    //   .subscribe({
    //     next: () => {
    //       const config: ModalOptions = {
    //         initialState: {
    //           modalHeaderText: 'Success Message',
    //           modalBodyText: `Category: ${updatedCategory.name} updated successfully`,
    //           okButtonText: 'OK'
    //         }
    //       };

    //       this.bsModalRef = this.modal.show(SuccessModalComponent, config);
    //       this.bsModalRef.content.redirectOnOk.subscribe(() => this.redirectToCategoryList());
    //     },
    //     error: (err: HttpErrorResponse) => {
    //       this.errorHandler.handleError(err);
    //       this.errorMessage = this.errorHandler.errorMessage;
    //     }
    //   });
  }

  redirectToCategoryList = () => {
    this.router.navigate(['/ui-components/category']);
  }

}
