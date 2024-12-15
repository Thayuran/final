import { Component } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Role } from '../../../models/role';

@Component({
  selector: 'app-roles',
  standalone: false,

  templateUrl: './roles.component.html',
  styleUrl: './roles.component.css'
})
export class RolesComponent {


  public dataSource = new MatTableDataSource<Role>();

  constructor(public router:Router){}

  public redirectToUpdate = (id: string) => {
    this.router.navigate([`/ui-components/update-role/${id}`]);
  };

  public deleteRole = (id: string) => {}
}
