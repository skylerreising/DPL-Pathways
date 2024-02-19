import { Component } from '@angular/core';
import { 
  NgFor, 
  UpperCasePipe, 
  NgIf 
} from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Hero } from '../hero';
import {HEROES} from '../mock-heroes';
import { HeroDetailComponent } from '../hero-detail/hero-detail.component';

@Component({
  selector: 'app-heroes',
  standalone: true,
  imports: [
    UpperCasePipe, 
    FormsModule, 
    NgFor, 
    NgIf,
    HeroDetailComponent
  ],
  templateUrl: './heroes.component.html',
  styleUrl: './heroes.component.css'
})

export class  HeroesComponent {
  selectedHero?: Hero;

  onSelect(hero: Hero): void {
  this.selectedHero = hero;
  }
  heroes = HEROES;
}
