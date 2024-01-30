import {Component, OnInit} from '@angular/core';
import {ProductsService} from "@admin/inventory/services/products.service";
import {QuotesService} from "@intranet/services/quotes.service";
import {PurchaseService} from "@intranet/services/purchase.service";
import {lastValueFrom} from "rxjs";
import {MostPurchasedProductsResponse} from "@core/interfaces/Product/Response/MostPurchasedProductsResponse";
import {CurrentUserResponse} from "@core/interfaces/Security/Response/userResponse";
import {AuthenticateService} from "@auth/services/authenticate.service";

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.sass']
})
export class DashboardComponent implements OnInit {

  salesCount: number = 0;
  viewCount: number = 0;
  quoteCount: number = 0;
  gainsCount: number = 0;
  mostPurchasedProducts: MostPurchasedProductsResponse[] = [];
  user: CurrentUserResponse;

  constructor(
    private readonly productService: ProductsService,
    private readonly qouteService: QuotesService,
    private readonly purchaseService: PurchaseService,
    private readonly authService: AuthenticateService
  ) {
  }

  ngOnInit(): void {
    this.authenticate();
    this.retrieveData();
  }

  authenticate() {
    if (this.authService.isUserAuthenticated()) {
      this.user = this.authService.currentUser();
    }
  }

  async retrieveData() {
    const productsResponse = this.purchaseService.retrieveMostPurchasedProducts();
    const salesResponse = this.purchaseService.retrieveCountOrders();
    const viewResponse = this.productService.retrieveCountViews();
    const quoteResponse = this.qouteService.getQuotesCount();
    const gainsResponse = this.purchaseService.retrieveGains();
    const salesPromise = lastValueFrom(salesResponse);
    const viewPromise = lastValueFrom(viewResponse);
    const quotePromise = lastValueFrom(quoteResponse);
    const gainsPromise = lastValueFrom(gainsResponse);
    const productsPromise = lastValueFrom(productsResponse);
    Promise.all([salesPromise, viewPromise, quotePromise, gainsPromise, productsPromise]).then((values) => {
      this.salesCount = values[0];
      this.viewCount = values[1];
      this.quoteCount = values[2];
      this.gainsCount = values[3];
      this.mostPurchasedProducts = values[4];
    });
  }
}
