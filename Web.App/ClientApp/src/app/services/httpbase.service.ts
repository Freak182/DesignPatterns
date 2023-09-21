import { Injectable } from "@angular/core";
import { HttpClientBase } from "./httpClientBase";

@Injectable()
export class HttpBaseService {
    constructor(protected httpClient: HttpClientBase) {}

    protected get<T>(endpointPath: string){
        this.httpClient.get(endpointPath);
    }
}