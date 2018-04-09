import { Component, OnInit, Input } from '@angular/core';
import { Show } from './shared/show.model';
import { Subscription } from 'rxjs/Subscription';
import { ActivatedRoute } from '@angular/router';
import { ShowService } from './shared/show.service';
import { OnDestroy } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
  selector: 'app-shows',
  templateUrl: './shows.component.html',
  styleUrls: ['./shows.component.css']
})

export class ShowsComponent implements OnInit, OnDestroy{
 
  private sub: Subscription;
  private tourId: string;
  shows: Show[];

  constructor(private showService: ShowService,
     private route: ActivatedRoute) { }

 ngOnInit() {     
      // get route data (tourId)
      this.sub = this.route.params.subscribe(
        params => {
          this.tourId = params['tourId'];
  
          // load tour
          this.showService.getShows(this.tourId)
            .subscribe(shows => {
              this.shows = shows;  
            });
        }
      );
    }

    ngOnDestroy(): void {
      this.sub.unsubscribe();
    }
}
