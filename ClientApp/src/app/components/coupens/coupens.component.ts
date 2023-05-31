import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-coupens',
  templateUrl: './coupens.component.html',
  styleUrls: ['./coupens.component.css']
})
export class CoupensComponent implements OnInit {
  

  constructor(public modal:NgbModal) { }

  ngOnInit(): void {

  }
}
