import {AfterContentInit, Directive, ElementRef, HostBinding, HostListener} from '@angular/core';

@Directive({
    selector: '[isFocus]',

})
export class IsFocusDirective implements AfterContentInit {
    @HostBinding('class.focus') isFocused = false;

    constructor(private el: ElementRef) {
    }

    @HostListener('focusin', ['$event.target'])
    onFocus(element) {
        if (this.el.nativeElement.querySelector('input, textarea, select')) {
            this.isFocused = true;
        }
    }

    @HostListener('focusout', ['$event.target'])
    onBlur(element) {
        const input = this.el.nativeElement.querySelector('input, textarea, select');
        if (input.value)
            return;
        this.isFocused = false;
    }

    ngAfterContentInit(): void {
        this.checkFocus()
    }

    checkFocus() {
        const input = this.el.nativeElement.querySelector('input, textarea, select');

        if (input && input.value) {
            this.isFocused = true;
        } else {
            this.isFocused = this.el.nativeElement === document.activeElement;
        }
    }
}
