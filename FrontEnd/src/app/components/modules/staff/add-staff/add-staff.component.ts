import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../../services/auth.service';

@Component({
  selector: 'app-add-staff',
  standalone: false,

  templateUrl: './add-staff.component.html',
  styleUrl: './add-staff.component.css'
})
export class AddStaffComponent {
  registerForm: FormGroup | any;
  errorMessage: string = '';
  showError: boolean=false;

  constructor(private authService: AuthService,private router: Router) { }


  public validateControl = (controlName: string) => {
    return this.registerForm.get(controlName).invalid && this.registerForm.get(controlName).touched
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.registerForm.get(controlName).hasError(errorName)
  }

  public registerUser = (registerFormValue:any) => {
    this.showError = false;
    const formValues = { ...registerFormValue };
  }


  redirectToUser = () => {
    this.router.navigate(['/ui-components/user']);
  }
}
