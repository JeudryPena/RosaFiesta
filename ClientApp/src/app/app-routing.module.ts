import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticateComponent } from './components/authenticate/authenticate.component';

const routes: Routes = [
  {
    path: '**', redirectTo: 'home', pathMatch: 'full'
  },
  { path: 'authenticate', component: AuthenticateComponent },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
