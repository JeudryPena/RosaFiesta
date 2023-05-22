import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  isSearchInputFocused = false;
  isAuthenticated = false;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit() {
  }

  onSearchInputFocus() {
    this.isSearchInputFocused = true;
  }

  onSearchInputBlur() {
    this.isSearchInputFocused = false;
  }

  Search() {
    this.router.navigate(['/authenticate']);
  }

  
}
