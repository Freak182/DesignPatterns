import { Component, OnInit } from '@angular/core';
import { PlaneTicketPurchaseService } from '../services/plane-ticket-purchase.service';
import { PlaneTicketPurchaseResponse } from '../entities/PlaneTicketPurchase';

@Component({
  selector: 'app-example',
  templateUrl: './example.component.html',
  styleUrls: ['./example.component.css']
})
export class ExampleComponent implements OnInit {

  constructor(private ticketService : PlaneTicketPurchaseService) { }

  ngOnInit() {
    this.ticketService.getPlaneTicketPurchase(1).subscribe((price : PlaneTicketPurchaseResponse) => {
      console.log(price);
      debugger;
    });
  }
}
