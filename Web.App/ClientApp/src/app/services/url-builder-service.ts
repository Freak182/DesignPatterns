import { HttpParams } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { of } from "rxjs";

export class UrlBuilderService {
    constructor( 
        @Inject('BASE_URL') public baseUrl: string
    ){}    

    public getBaseURL(){
        return of(this.baseUrl);
    }

    public getQueryParams(): HttpParams {
        return new HttpParams();
    }
}