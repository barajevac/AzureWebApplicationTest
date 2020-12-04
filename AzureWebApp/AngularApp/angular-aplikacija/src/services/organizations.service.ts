import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Organization } from 'src/modes/organizations.model';
//import { url } from 'inspector';

@Injectable({
    providedIn: 'root',
  })
export class OrganizatiosService {
    private readonly defaultProductionURL = "https://azurewebapiapplication20201128124852.azurewebsites.net/api/organization";
    private readonly defaultLocalURL = "http://localhost:53906/api/organization";
    constructor(private http: HttpClient) { }

    public getOrganizations():Observable<Organization>{
        console.log("usao u organizations service")
        return this.http.get<Organization>(this.defaultProductionURL);
    }
}