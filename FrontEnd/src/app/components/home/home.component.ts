import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


declare var bootstrap: any;
@Component({
  selector: 'app-home',
  standalone: false,

  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {


  // title = 'admin-dashboard';
  isSidebarClosed = false;
  handleSidebarToggle(isClosed: boolean) {
    this.isSidebarClosed = isClosed;
  }
  openSettingsModal() {
    const settingsModal = new bootstrap.Modal(document.getElementById('settingsModal'), {
      keyboard: false
    });
    settingsModal.show();
  }
}
