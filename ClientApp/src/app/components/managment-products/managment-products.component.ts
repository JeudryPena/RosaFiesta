import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';


@Component({
  selector: 'app-managment-products',
  templateUrl: './managment-products.component.html',
  styleUrls: ['./managment-products.component.scss']
})
export class ManagmentProductsComponent implements OnInit {
  collectionSize = 0;
  pageSize = 10;
  page = 1;
  
  dataTable: any = [
    {
      id: "SDA-01",
      name: 'Product 1',
      price: 100,
      quantity: 10,
      description: 'Description 1',
      image: 'nada aun',
    },
    {
      id: "SDA-02",
      name: 'Product 2',
      price: 340,
      quantity: 15,
      description: 'Description 2',
      image: 'nada aun',
    },
    {
      id: "SDA-03",
      name: 'Product 3',
      price: 750,
      quantity: 200,
      description: 'Description 3',
      image: 'nada aun',
    },
  ];
  
  constructor() { }

  ngOnInit() {

    this.getData();
  }
  
  getData() {

  }
}
