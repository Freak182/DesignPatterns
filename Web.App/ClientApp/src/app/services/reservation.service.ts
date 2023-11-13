import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ReservationResponse } from "../entities/ReservationResponse";
import { HttpBaseService } from "./base/httpbase.service";
import { HttpClientBase } from "./base/httpClientBase";
import { ConnectionConstants } from "../constants/ConnectionConstants";

@Injectable()
export class ReservationService extends HttpBaseService {
    constructor(
        httpClient: HttpClientBase
    ) {
        super(httpClient);
    }

    public getReservation(reservationId: number) : Observable<ReservationResponse> {
        return super.get<ReservationResponse>(ConnectionConstants.API_ENDPOINTS.RESERVATION)
    }
}