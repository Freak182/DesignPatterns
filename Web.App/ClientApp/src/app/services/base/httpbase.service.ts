import { Injectable } from "@angular/core";
import { HttpClientBase } from "./httpClientBase";
import { Observable } from "rxjs";

@Injectable()
export class HttpBaseService {
    constructor(protected httpClient: HttpClientBase) {}

    protected get<T>(endpointPath: string) : Observable<T>{
        return this.httpClient.get<T>(endpointPath);
    }
}