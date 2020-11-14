import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators  } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PasswordService } from '../../services';
import { PasswordAuth } from '../../models';

@Component({
  selector: 'app-password-login',
  templateUrl: './password-login.component.html',
  styleUrls: ['./password-login.component.css']
})
export class PasswordLoginComponent implements OnInit {
  loginForm: FormGroup;
  authModel : PasswordAuth;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private passwordService : PasswordService
  ) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
  });
  }

  onSubmit() {

    if (this.loginForm.invalid) {
        return;
    }
    this.authModel = new PasswordAuth(this.loginForm.value.username, this.loginForm.value.password);
    this.passwordService.login(this.authModel)
        .subscribe(
            data => {
                this.router.navigate(['/']);
            }
    );
    
  }
}
