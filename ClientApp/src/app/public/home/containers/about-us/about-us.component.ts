import {Component, OnDestroy, OnInit, ViewEncapsulation} from '@angular/core';

@Component({
  selector: 'app-about-us',
  templateUrl: './about-us.component.html',
  styleUrls: ['./about-us.component.sass'],
  encapsulation: ViewEncapsulation.None
})
export class AboutUsComponent implements OnInit, OnDestroy {

  myClass = document.getElementById('main');

  constructor() {
    this.myClass.classList.add('about-us-main');
  }

  ngOnInit(): void {

  }

  ngOnDestroy() {
    this.myClass.classList.remove('about-us-main');
  }
}
