import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { ShowService } from '../shared/show.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { ShowSingleComponent } from '../show-single/show-single.component';

@Component({
  selector: 'app-show-add',
  templateUrl: './show-add.component.html',
  styleUrls: ['./show-add.component.css']
})

export class ShowAddComponent implements OnInit {
  private sub: Subscription;
  private tourId: string;
  public showCollectionForm: FormGroup;

  constructor(private showService: ShowService,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private router: Router) { }

  ngOnInit() {
    this.showCollectionForm = this.formBuilder.group({
      shows: this.formBuilder.array([])
    });

    this.addShow();

    // get route data (tourId)
    this.sub = this.route.params.subscribe(
      params => {
        this.tourId = params['tourId'];
      }
    );
  }

  addShow(): void {
    let showsFormArray = this.showCollectionForm.get('shows') as FormArray;
    showsFormArray.push(ShowSingleComponent.createShow());
  }

  addShows(): void {
    if (this.showCollectionForm.dirty
      && this.showCollectionForm.value.shows.length) {

      let showCollection = automapper.map(
        'ShowCollectionFormModelShowsArray',
        'ShowCollectionForCreation',
        this.showCollectionForm.value.shows);

      this.showService.addShowCollection(this.tourId, showCollection)
        .subscribe(
          () => {
            this.router.navigateByUrl('/tours');
          });
    }
  }


  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

}
