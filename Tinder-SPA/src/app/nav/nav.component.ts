import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any={};

  constructor(private router:Router, public authService:AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  login (){
      this.authService.login(this.model).subscribe(next => {
        this.alertify.success('logged in successfully');
      },
        error => {
          this.alertify.error('login failed');
        }
        ,
        ()=> {
          this.router.navigate(['/members']);
        }
      );
  }

  loggedIn(){
    return this.authService.loggedIn();
  }


  logout(){
    localStorage.removeItem('token');
    this.alertify.message('logged out');
    this.router.navigate(['/home']);
  }

}
