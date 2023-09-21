import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { UrlBuilderService } from "./url-builder-service";

@Injectable()
export class HttpClientBase {

    constructor(protected http: HttpClient,
        protected urlBuilderService: UrlBuilderService){
            
        }
    
    public get<T>(endpointPath: string): Observable<T> {
        return this.http.get<T>(this.urlBuilderService.getBaseURL() + endpointPath);
    }
}