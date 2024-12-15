import { Component } from '@angular/core';
// import { TranslateService } from '../../services/translate.service';

@Component({
  selector: 'app-navbar',
  standalone: false,

  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  translatedText: string = 'Welcome to Our Website'; // Default text
  originalText: string = 'Welcome to Our Website';

  // constructor(private translateService: TranslateService) {}

  onLanguageChange(event: Event) {
    // const target = event.target as HTMLSelectElement;
    // if (target && target.value) {
    //   const selectedLanguage = target.value;
    //   this.translateService.translateText(this.originalText, selectedLanguage).subscribe(
    //     (response: any) => {
    //       this.translatedText = response.translatedText;
    //     },
    //     (error) => {
    //       console.error('Translation error:', error);
    //     }
    //   );
    // }
  }
}
