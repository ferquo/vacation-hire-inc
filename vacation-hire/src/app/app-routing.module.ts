import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrderListComponent } from './orders/order-list/order-list.component';
import { OrderCreateComponent } from './orders/order-create/order-create.component';
import { OrderCreateReturnalComponent } from './orders/order-create-returnal/order-create-returnal.component';

const routes: Routes = [
  { path: '', redirectTo: 'orders', pathMatch: 'full' },
  { path: 'orders', component: OrderListComponent },
  { path: 'orders/new', component: OrderCreateComponent },
  { path: 'orders/:id/return-product', component: OrderCreateReturnalComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
