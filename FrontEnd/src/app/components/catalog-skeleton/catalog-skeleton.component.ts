import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-catalog-skeleton',
  standalone: false,
  // imports: [],
  templateUrl: './catalog-skeleton.component.html',
  styleUrl: './catalog-skeleton.component.scss'
})
export class CatalogSkeletonComponent {

  @Input() showImage : Boolean;
  products = new Array(16);

  constructor() { }
}
