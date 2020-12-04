import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrganizationComponent } from 'src/components/organization/organization.component';
import { StudentComponent } from 'src/components/student/student.component';

const routes: Routes = [
  {path:"organizations", component: OrganizationComponent},
  {path:"students", component: StudentComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
