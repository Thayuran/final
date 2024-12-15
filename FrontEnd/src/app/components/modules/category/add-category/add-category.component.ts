import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-category',
  standalone: false,

  templateUrl: './add-category.component.html',
  styleUrl: './add-category.component.css'
})
export class AddCategoryComponent implements OnInit{

  public categoryForm: FormGroup | any;
  public errorMessage: string = '';

constructor(public router:Router){}


ngOnInit(): void {
  this.categoryForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.maxLength(60)])
  });
}
hasError = (controlName: string, errorName: string) => {
    if (this.categoryForm.get(controlName).hasError(errorName))
      return true;

    return false;
  }

  createCategory = (categoryFormValue: any) => {
    if (this.categoryForm.valid)
      this.executeCategoryCreation(categoryFormValue);
  }

  private executeCategoryCreation = (categoryFormValue: any) => {
    const category: any = {
      name: categoryFormValue.name
    };
}

redirectToCategoryList = () => {
  this.router.navigate(['/ui-components/category']);
}

}
