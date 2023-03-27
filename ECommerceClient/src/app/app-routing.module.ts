import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardModule } from './admin/components/dashboard/dashboard.module';
import { LayoutComponent } from './admin/layout/layout.component';
import { HomeComponent } from './ui/components/home/home.component';

const routes: Routes = [
  {
    path: 'admin',
    component: LayoutComponent,
    children: [
      { path: '', component: DashboardModule },

      {
        path: 'customers',
        loadChildren: () =>
          import('./admin/components/customer/customer.module').then(
            (module) => module.CustomerModule
          ),
      },
      {
        path: 'products',
        loadChildren: () =>
          import('./admin/components/products/products.module').then(
            (module) => module.ProductsModule
          ),
      },
      {
        path: 'Orders',
        loadChildren: () =>
          import('./admin/components/order/order.module').then(
            (module) => module.OrderModule
          ),
      },
    ],
  },
  { path: '', component: HomeComponent },
  {
    path: 'basket',
    loadChildren: () =>
      import('./ui/components/basket/basket.module').then(
        (module) => module.BasketModule
      ),
  },
  {
    path: 'products',
    loadChildren: () =>
      import('./ui/components/products/products.module').then(
        (module) => module.ProductsModule
      ),
  },{
    path: 'dashboard',
    loadChildren: () =>
      import('./admin/components/dashboard/dashboard.module').then(
        (module) => module.DashboardModule
      ),
  }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}