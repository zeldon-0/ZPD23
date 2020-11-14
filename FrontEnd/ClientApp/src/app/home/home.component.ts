import { Component } from '@angular/core';
import { Router } from '@angular/router';

const MINUTES_UNITL_AUTO_LOGOUT = 2.5
const CHECK_INTERVAL = 1000 

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  loginTime : number;
  constructor(private router: Router) {
    this.loginTime = Date.now();
    this.check();
    this.initInterval();

  }
  public remainder : number;
  initInterval() {
    setInterval(() => {
      this.check();
    }, CHECK_INTERVAL);
  }

  check() {
    const now = Date.now();
    const timeleft = this.loginTime + MINUTES_UNITL_AUTO_LOGOUT * 60 * 1000;

    const diff = timeleft - now;
    this.remainder = diff;
    const isTimeout = diff < 0;

    if (isTimeout) {
      localStorage.clear();
      this.router.navigate(['/passwordLogin']);
    }
  }
}
