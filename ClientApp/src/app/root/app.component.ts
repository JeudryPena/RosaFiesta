import {Component, OnInit} from '@angular/core';
import {AuthenticateService} from '@auth/services/authenticate.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {

    constructor(private authService: AuthenticateService) {

    }

    ngOnInit(): void {
        this.authService.sendAuthStateChangeNotification(true);
    }
}
