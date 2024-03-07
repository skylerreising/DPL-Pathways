import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterOutlet } from '@angular/router';
import { HeroesComponent } from "./heroes/heroes.component";
import { MessagesComponent } from "./messages/messages.component";
import { HeroService } from './hero.service';
import { Hero } from './hero'

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, HeroesComponent, MessagesComponent, RouterLink],
  templateUrl: `./app.component.html`,
  styleUrl: './app.component.css'
})

export class AppComponent {
  title = 'httpTest';
  heroes: Hero[] = [] ;

  constructor(private heroService: HeroService){}

  onBtnclick(): void{
    this.heroService.getHeroes().subscribe(heroList=>(this.heroes = heroList));
  }
}