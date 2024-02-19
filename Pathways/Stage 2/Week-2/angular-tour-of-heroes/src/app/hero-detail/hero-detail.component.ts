import { Component, Input } from '@angular/core';
import {Hero} from '../hero';
import { 
  NgFor, 
  UpperCasePipe, 
  NgIf 
} from '@angular/common';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-hero-detail',
  standalone: true,
  imports: [NgFor, UpperCasePipe, NgIf, FormsModule],
  templateUrl: './hero-detail.component.html',
  styleUrl: './hero-detail.component.css'
})
export class HeroDetailComponent {
  @Input() hero?: Hero;
}
