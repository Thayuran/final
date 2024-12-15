import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { UserForUpdateDto, UserRoleDto } from '../../../interface/user/UserRegistrationDto.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-update-staff',
  standalone: false,

  templateUrl: './update-staff.component.html',
  styleUrl: './update-staff.component.css'
})
export class UpdateStaffComponent {


  dataForm: FormGroup |any;
  roles:UserRoleDto []|any;
  selectedRoles: string[] = [];
  user:UserForUpdateDto |any;
  private userId: string | null = '';



  constructor(public router:Router){}
  public hasError = (controlName: string, errorName: string) => {
    return this.dataForm?.get(controlName)?.hasError(errorName)
  }


  public validateControl = (controlName: string) => {
    return this.dataForm?.get(controlName)?.invalid && this.dataForm?.get(controlName)?.touched
  }
  public createData = (dataFormValue: any) => {

    if (this.dataForm.valid) {
      this.executeDataCreation(dataFormValue);

    }
  };
  private executeDataCreation = (dataFormValue: any) => {
    // let data: UserForUpdateDto = {

    //   firstName: dataFormValue.firstName,
    //   lastName: dataFormValue.lastName,
    //   userName: dataFormValue.userName,
    //   email: dataFormValue.email,
    //   roles: this.selectedRoles,

    // };

  }

  toggleRoleSelection(event: any, roleName: string): void {
    if (event.checked) {
      this.selectedRoles.push(roleName);
    } else {
      this.selectedRoles = this.selectedRoles.filter(role => role !== roleName);
    }
  }

  isSelected(roleName: string): boolean {
    return this.selectedRoles.includes(roleName);
  }
  redirectToUserList = () => {
    this.router.navigate(['/ui-components/user']);
  }
}
