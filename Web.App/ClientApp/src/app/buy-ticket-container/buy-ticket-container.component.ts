import { Component, OnInit } from '@angular/core';
import { PlaneTicketPurchaseResponse } from '../entities/PlaneTicketPurchase';
import { PlaneTicketPurchaseService } from '../services/plane-ticket-purchase.service';

@Component({
  selector: 'app-buy-ticket-container',
  templateUrl: './buy-ticket-container.component.html',
  styleUrls: ['./buy-ticket-container.component.css']
})
export class BuyTicketContainerComponent implements OnInit {

  private requestStepState: string = "";

  constructor(
    private planeTicketPurchaseService: PlaneTicketPurchaseService
  ) { }

  ngOnInit() {
    this.getCurrentPurchase().sub
    this.createComponent();
  }

  private getCurrentPurchase(): Obversable<PlaneTicketPurchaseResponse> {

  }
  private createComponent(){

  }

}
