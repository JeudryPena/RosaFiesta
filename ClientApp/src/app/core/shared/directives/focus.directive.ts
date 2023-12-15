import { AfterViewInit, Directive, ElementRef, HostBinding, HostListener } from '@angular/core';

@Directive({
  selector: '[focus]'
})
export class FocusDirective implements AfterViewInit {

  constructor(private el: ElementRef) { }

  @HostBinding('class.focus') isFocused = false;

  @HostListener('focus') onFocus() {
    this.isFocused = true;
  }

  @HostListener('blur') onBlur() {
    if (!this.el.nativeElement.value) {
      this.isFocused = false;
    }
  }

  ngAfterViewInit() {
    this.isFocused = this.el.nativeElement === document.activeElement;
  }
}
