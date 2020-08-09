import { Component} from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { PetService } from '../shared/pet.service'

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public owners: any;
  errormessage$: Observable<any>;
  private subscription: Subscription;
  public Loading = false;
  type='cat'
  customErrorMessage = ' Oops !!! Something went wrong !!!'

  constructor(private petService: PetService) {
    this.Loading = true;
    setTimeout(() => {
      this.subscription = this.petService.getOwnerWithPets(this.type).subscribe(data => {
        this.owners = data;
        this.Loading = false;
        });
        this.errormessage$ = this.petService.errorMessage;
    }, 1000);
  }

   ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
