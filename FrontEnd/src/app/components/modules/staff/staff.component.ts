import { Component } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { UserDto } from '../../interface/user/UserRegistrationDto.model';
import { AuthService } from '../../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-staff',
  standalone: false,

  templateUrl: './staff.component.html',
  styleUrl: './staff.component.css'
})
export class StaffComponent {


  public dataSource = new MatTableDataSource<UserDto>();

  constructor(
    private router: Router,
    private authService: AuthService
  ) {}

  public redirectToUpdate = (id: string) => {
    this.router.navigate([`/ui-components/update-user/${id}`]);
  };

  public deleteUser = (id: string) => {}

}
