import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TurnoverSheetDetailsComponent } from './ui/components';
import { TurnoverSheetComponent } from './ui/components';

const routes: Routes = [
  { path: '', redirectTo: '/sheet', pathMatch: 'full' },
  { path: 'sheet', component: TurnoverSheetComponent },
  { path: 'sheet/:id', component: TurnoverSheetDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
