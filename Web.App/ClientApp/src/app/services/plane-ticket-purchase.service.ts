import { Injectable } from "@angular/core";
import { HttpBaseService } from "./httpbase.service";
import { HttpClientBase } from "./httpClientBase";
import { PlaneTicketPurchaseResponse } from "../entities/PlaneTicketPurchase";
import { Observable } from "rxjs";
import { ConnectionConstants } from "../constants/ConnectionConstants";

@Injectable()
export class PlaneTicketPurchaseService extends HttpBaseService {
    constructor(
        httpClient : HttpClientBase
    ){
        super(httpClient);
    }

    public getPlaneTicketPurchase(planeTicketPurchaseId: number) : Observable<PlaneTicketPurchaseResponse> {
        console.log("test");
        return super.get<PlaneTicketPurchaseResponse>(ConnectionConstants.API_ENDPOINTS.FLIGHTS_TICKETS + `resources/flights/${planeTicketPurchaseId}/price`);
    }
}