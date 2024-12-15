import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-role-form',
  standalone: false,

  templateUrl: './role-form.component.html',
  styleUrl: './role-form.component.css'
})
export class RoleFormComponent implements OnInit {

  public roleForm: FormGroup | any;

  constructor(
    private router: Router) { }

    ngOnInit(): void {
      this.roleForm = new FormGroup({
        name: new FormControl('', [Validators.required, Validators.maxLength(50)])
      });
    }

  hasError = (controlName: string, errorName: string) => {
    if (this.roleForm.get(controlName).hasError(errorName))
      return true;

    return false;
  }

  createRole = (roleFormValue: any) => {
    if (this.roleForm.valid)
      this.executeRoleCreation(roleFormValue);
  }

  private executeRoleCreation = (roleFormValue: any) => {
    const role: any = {
      name: roleFormValue.name
    };
  }

  redirectToRoleList = () => {
    this.router.navigate(['/ui-components/roles']);
  }
}
