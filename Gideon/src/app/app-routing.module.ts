import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UploadsComponent } from './components/uploads/uploads.component';

const routes: Routes = [
  { path: '', redirectTo: 'uploads', pathMatch: 'full' },
  { path: 'uploads', component: UploadsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
