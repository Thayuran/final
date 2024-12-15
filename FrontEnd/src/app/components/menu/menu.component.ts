import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ChangePasswordComponent } from 'src/app/pages/authentication/change-password/change-password.component';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';

@Component({
  selector: 'app-menu',
  standalone: false,

  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})
export class MenuComponent implements OnInit {
  email?: any
  userName?: any
  userRole?: any
  isLoggedIn = false;

  isAuth: boolean = false;

   constructor(public dialog: MatDialog,private authService: AuthenticationService,private router: Router){}

  ngOnInit(): void {
    this.authService.updateuser.subscribe((res) => {
      this.getUserEmail();
      this.getUserName();
      this.getUserRole();
    });
    this.getUserEmail();
    this.getUserName();
    this.getUserRole();
  }

  dashboard(){
    this.router.navigate(['dashboard']);
  }


 public getUserName() {
    this.userName = this.authService.loadCurrentUserName();
  }
  public getUserRole() {
    this.userRole = this.authService.loadCurrentUserRole();
  }

  public getUserEmail() {
    this.email = this.authService.loadCurrentUserEmail();
    console.log(this.email);
  }

  public logout = () => {
    this.authService.logout();
    this.isLoggedIn = false;
    this.router.navigate(["/authentication/login"]);
  }

  ChangePassword() {
    const popup = this.dialog.open(ChangePasswordComponent, {
      width: '500px', height: '510px',
      enterAnimationDuration: '100ms',
      exitAnimationDuration: '100ms',
      data: {
        email: this.email
      }
    });
  }

}
