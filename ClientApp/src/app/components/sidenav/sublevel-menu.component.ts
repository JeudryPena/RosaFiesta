import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, Input, OnInit } from '@angular/core';
import { CategoryPreviewResponse } from '../../interfaces/Product/Response/categoryPreviewResponse';

@Component({
  selector: 'app-sublevel-menu',
  template: `
    <ul *ngIf="collapsed && data.subCategories && data.subCategories.length > 0"
    [@submenu]="expanded
    ? {value: 'visible',
      params: {transitionParams: '400ms cubic-bezier(0.86, 0, 0.07, 1)', height: '*'}}
    : {value: 'hidden',
      params: {transitionParams: '400ms cubic-bezier(0.86, 0, 0.07, 1)', height: '0'}}"
    class="sublevel-nav"
    >
      <li *ngFor="let item of data.subCategories" class="sublevel-nav-item">
        <a class="sublevel-nav-link" (click)="Navigate(item.id)"
        >
        <i class= "sublevel-link-icon fa fa-circle"></i>
        <span class="sublevel-link-text" @fadeInOut *ngIf="collapsed">{{item.name}}</span>
        </a>
      </li>
    </ul>
  `,
  styleUrls: ['./sidenav.component.scss'],
  animations: [
    trigger('submenu', [
      state('hidden', style({
        height: '0',
        overflow: 'hidden',
      })),
      state('visible', style({
        height: '*'
      })),
      transition('visible <=> hidden', [style({ overflow: 'hidden' }),
      animate('{{transitionParams}}')]),
      transition('void => *', animate(0))
    ]),
    trigger('fadeInOut', [
      transition(':enter', [
        style({ opacity: 0 }),
        animate('350ms',
          style({ opacity: 1 })
        )
      ]),
      transition(':leave', [
        style({ opacity: 1 }),
        animate('350ms',
          style({ opacity: 0 })
        )
      ])
    ]),
  ]
})
export class SublevelMenuComponent implements OnInit {
  ngOnInit(): void { }

  @Input() data: CategoryPreviewResponse = {
    id: 0,
    name: '',
    icon: '',
    description: '',
    subCategories: []
  }

  Navigate(id: number): void {
    console.log(id);
  }

  @Input() collapsed = false
  @Input() animating: boolean | undefined;
  @Input() expanded: boolean | undefined;
  @Input() multiple: boolean = false;

  constructor() { }

  handleClick(item: any): void {
    if (!this.multiple) {
      if (this.data.subCategories && this.data.subCategories.length > 0) {
        for (let modelItem of this.data.subCategories) {
          if (item !== modelItem && modelItem.expanded) {
            modelItem.expanded = false;
          }
        }
      }

    }
    item.expanded = !item.expanded;
  }

}
