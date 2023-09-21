import { Injectable } from "@angular/core";

@Injectable()
export class PlaneTicketPurchaseService extends HttpBaseService {
    constructor(
    ){
        super();
    }

    public getPlaneTicketPurchase(planeTicketPurchaseId: number){
        super.get<PlaneTicketPurchaseResponse>(url)
    }
}