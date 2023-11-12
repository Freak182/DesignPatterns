import { Injectable } from "@angular/core";
import { HttpBaseService } from "./httpbase.service";
import { HttpClientBase } from "./httpClientBase";
import { PlaneTicketPurchaseResponse } from "../entities/PlaneTicketPurchase";
import { Observable } from "rxjs";

@Injectable()
export class PlaneTicketPurchaseService extends HttpBaseService {
    constructor(
        httpClient : HttpClientBase
    ){
        super(httpClient);
    }

    public getPlaneTicketPurchase(planeTicketPurchaseId: number) : Observable<PlaneTicketPurchaseResponse> {
        return super.get<PlaneTicketPurchaseResponse>("planeticket");
    }
}