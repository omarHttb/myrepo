import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-server-error',
  templateUrl: './server-error.component.html',
  styleUrls: ['./server-error.component.scss']
})
export class ServerErrorComponent implements OnInit {
  Error: any;

  constructor(private router: Router) {
    const Navigation = this.router.getCurrentNavigation();
    this.Error = Navigation && Navigation.extras && Navigation.extras.state &&
    Navigation.extras.state.error;
   }

  ngOnInit() {
  }

}
