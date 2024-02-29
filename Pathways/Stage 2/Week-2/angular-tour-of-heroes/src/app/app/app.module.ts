import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule, provideHttpClient } from '@angular/common/http';
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService } from '../in-memory-data.service';
import { withFetch } from '@angular/common/http';

@NgModule({
  declarations: [],
  providers: [
    provideHttpClient(withFetch()),
  ],
  imports: [
    CommonModule,
    HttpClientModule,

    // The HttpClientInMemoryWebApiModule module intercepts HTTP requests
    // and returns simulated server responses.
    // Remove it when a real server is ready to receive requests.
    HttpClientInMemoryWebApiModule.forRoot(
      InMemoryDataService, { dataEncapsulation: false }
    )
  ]
})
export class AppModule { }