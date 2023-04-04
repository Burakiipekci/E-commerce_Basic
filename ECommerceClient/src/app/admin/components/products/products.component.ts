import { Component, OnInit } from '@angular/core';
import { HttpClientService } from 'src/app/services/common/http-client.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit{
/**
 *
 */
constructor(private httpClientService: HttpClientService) {}
  ngOnInit(): void {
    this.httpClientService.get({controller:"product"}).subscribe(data => console.log(data));
    // this.httpClientService.post({
    //   controller:"product"},{name:"kalem", stock:100, price:15}).subscribe();
// this.httpClientService
//   .put(
//     { controller: "product" },
//     {
//       id: "f3d693b4-3d8c-4169-ac6c-f2d744eaf7a8", name: "test",stock: 1500, price: 50,}).subscribe();
//   }
this.httpClientService.delete({controller:"product"},"7052a49a-ce4d-406e-98d2-de45e0f2cda0").subscribe()

}
}
