import { Component } from '@angular/core';

@Component({
  selector: 'app-update-staff-role',
  standalone: false,

  templateUrl: './update-staff-role.component.html',
  styleUrl: './update-staff-role.component.css'
})
export class UpdateStaffRoleComponent {

  public roles: any[] = [];
  public selectedRoles: Set<string> = new Set(); 

  public isSelected = (roleName: string): boolean => {
    return this.selectedRoles.has(roleName);
  }

  public toggleRoleSelection = (event: any, roleName: string) => {
    if (event.checked) {
      this.selectedRoles.add(roleName);
    } else {
      this.selectedRoles.delete(roleName);
    }
  }

  public updateUserRole = () => {}
}
