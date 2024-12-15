import { PaymentPopupComponent } from './components/payment-popup/payment-popup.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TablerIconsModule } from 'angular-tabler-icons';
import * as TablerIcons from 'angular-tabler-icons/icons';
import { MaterialModule } from './material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FullComponent } from './layouts/full/full.component';
import { BlankComponent } from './layouts/blank/blank.component';
import { SidebarComponent } from './layouts/full/sidebar/sidebar.component';
import { HeaderComponent } from './layouts/full/header/header.component';
import { BrandingComponent } from './layouts/full/sidebar/branding.component';
import { AppNavItemComponent } from './layouts/full/sidebar/nav-item/nav-item.component';
import { JwtModule } from '@auth0/angular-jwt';
import { ModalsModule } from './shared/modals/modals.module';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { LoadingInterceptor } from './core/loading.interceptor';
import { ToastrModule } from 'ngx-toastr';
import { ErrorHandlerService } from './shared/services/error-handler.service';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { MenuComponent } from './components/menu/menu.component';
import { PosToolbarComponent } from './components/pos-toolbar/pos-toolbar.component';
import { CartSkeletonComponent } from './components/cart-skeleton/cart-skeleton.component';
import { CartComponent } from './components/cart/cart.component';
import { CatalogComponent } from './components/catalog/catalog.component';
import { HomeComponent } from './components/home/home.component';
import { PosComponent } from './components/pos/pos.component';
import { AppDashboardComponent } from './pages/dashboard/dashboard.component';

import { NgxSkeletonLoaderModule } from 'ngx-skeleton-loader';
import { CatalogSkeletonComponent } from './components/catalog-skeleton/catalog-skeleton.component';
import { NgxStripeModule } from 'ngx-stripe';
import { PaymentComponent } from './components/payment/payment.component';
import { PaymentGatewayComponentComponent } from './components/payment-gateway-component/payment-gateway-component.component';


export function tokenGetter() {
  return localStorage.getItem("token");
}
;

@NgModule({
  declarations: [
    AppComponent,
    FullComponent,
    BlankComponent,
    SidebarComponent,
    HeaderComponent,
    BrandingComponent,
    AppNavItemComponent,
    NotFoundComponent,
    ServerErrorComponent,

    HomeComponent,
    NavbarComponent,
    SidebarComponent,
    MenuComponent,
    PosComponent,
    CartComponent,
    CartSkeletonComponent,
    PosToolbarComponent,
    CatalogComponent,
    CatalogSkeletonComponent,
    PaymentComponent,
    PaymentPopupComponent,
    PaymentGatewayComponentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    // AppDashboardComponent,


    TablerIconsModule.pick(TablerIcons),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost:5001']
      }
    }),
    ModalsModule,
    NgxSpinnerModule,
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-top-right',
      preventDuplicates: true,
      progressBar: true,
      closeButton: true
    }),
    NgxSkeletonLoaderModule,
    NgxStripeModule.forRoot(),
  ],
  exports: [TablerIconsModule],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorHandlerService,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoadingInterceptor,
      multi: true
    },

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
