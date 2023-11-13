import { Injectable } from "@angular/core";
import { HttpBaseService } from "./base/httpbase.service";
import { HttpClientBase } from "./base/httpClientBase";
import { PlaneTicketPurchaseResponse } from "../entities/PlaneTicketPurchaseResponse";
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
        return super.get<PlaneTicketPurchaseResponse>(ConnectionConstants.API_ENDPOINTS.FLIGHTS_TICKETS + `resources/flights/${planeTicketPurchaseId}/price`);
    }
}