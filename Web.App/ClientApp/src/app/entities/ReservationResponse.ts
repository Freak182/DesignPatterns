import { PlaneResponse } from "./PlaneResponse";

export interface ReservationResponse {
    ReservationId : number;
    State : string;
    Plane : PlaneResponse;
}