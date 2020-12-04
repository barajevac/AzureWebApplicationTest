import { Component, OnInit } from '@angular/core';
import { OrganizatiosService } from 'src/services/organizations.service';

@Component({
  selector: 'app-organization',
  templateUrl: './organization.component.html',
  styleUrls: ['./organization.component.sass']
})
export class OrganizationComponent implements OnInit {

  constructor(private organizationService: OrganizatiosService) { }

  ngOnInit(): void {
   this.organizationService.getOrganizations().subscribe(res=>{
     console.log(res);
   })
    
  }

}
