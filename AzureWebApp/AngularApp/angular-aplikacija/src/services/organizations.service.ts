import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Organization } from 'src/modes/organizations.model';
import { environment } from '../environments/environment'

@Injectable({
    providedIn: 'root',
  })
export class OrganizatiosService {
    // private readonly defaultProductionURL = "https://azurewebapiapplication20201128124852.azurewebsites.net/api/organization";
    // private readonly defaultLocalURL = "http://localhost:53906/api/organization";

    private readonly baseUrl : string = environment.baseUrl + '/organization'

    constructor(private http: HttpClient) { }

    public getOrganizations():Observable<Organization>{
        console.log("usao u organizations service");
        console.log(this.baseUrl);
        return this.http.get<Organization>(this.baseUrl);
    }
}