import { HttpParams } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { of } from "rxjs";

@Injectable()
export class UrlBuilderService {
    constructor( 
        @Inject('BASE_URL') public baseUrl: string
    ){}    

    public getBaseURL(){
        return this.baseUrl;
    }

    public getQueryParams(): HttpParams {
        return new HttpParams();
    }
}