import {Component} from '@angular/core';
import {NgOptimizedImage} from "@angular/common";

@Component({
  selector: 'app-test',
  standalone: true,
  imports: [
    NgOptimizedImage
  ],
  templateUrl: './test.component.html',
  styleUrl: './test.component.sass'
})
export class TestComponent {

}
