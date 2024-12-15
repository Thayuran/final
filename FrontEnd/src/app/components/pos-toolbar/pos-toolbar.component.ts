import { Component, Input } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSidenav } from '@angular/material/sidenav';
import { Router } from '@angular/router';
import { ChangePasswordComponent } from 'src/app/pages/authentication/change-password/change-password.component';
import { CartService } from 'src/app/services/cart.service';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';

@Component({
  selector: 'app-pos-toolbar',
  standalone: false,

  templateUrl: './pos-toolbar.component.html',
  styleUrl: './pos-toolbar.component.css'
})
export class PosToolbarComponent{

  @Input() cart!: MatSidenav;
  cartItemCount: number = 0;

  email?: any
  userName?: any
  userRole?: any

  constructor(
    public dialog: MatDialog,
    private authService: AuthenticationService,
    private router: Router,
    private cartService: CartService,) {}

  ngOnInit(): void {
    this.cartService.get().subscribe(res => this.cartItemCount = res.length);
    this.authService.updateuser.subscribe((res) => {
      this.getUserEmail();
      this.getUserName();
      this.getUserRole();
    });
    this.getUserEmail();
    this.getUserName();
    this.getUserRole();
  }

  public getUserName() {
    this.userName = this.authService.loadCurrentUserName();
  }
  public getUserRole() {
    this.userRole = this.authService.loadCurrentUserRole();
  }

  public getUserEmail() {
    this.email = this.authService.loadCurrentUserEmail();
  }

  public logout = () => {
    this.authService.logout();
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
