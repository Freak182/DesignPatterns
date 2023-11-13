import { Component, OnInit } from '@angular/core';
import { PlaneTicketPurchaseService } from '../services/plane-ticket-purchase.service';
import { PlaneTicketPurchaseResponse } from '../entities/PlaneTicketPurchaseResponse';
import { ReservationService } from '../services/reservation.service';
import { ReservationResponse } from '../entities/ReservationResponse';

@Component({
  selector: 'app-example',
  templateUrl: './example.component.html',
  styleUrls: ['./example.component.css']
})
export class ExampleComponent implements OnInit {

  constructor(
    private ticketService : PlaneTicketPurchaseService,
    private reervationService : ReservationService
   ) { }

  ngOnInit() {
    this.ticketService.getPlaneTicketPurchase(1).subscribe((price : PlaneTicketPurchaseResponse) => {
      console.log(price);
      debugger;
    });

    this.reervationService.getReservation(1).subscribe((reservation: ReservationResponse) => {
      console.log(reservation);
      debugger;
    })
  }
}
