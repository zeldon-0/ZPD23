import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-question-login',
  templateUrl: './question-login.component.html',
  styleUrls: ['./question-login.component.css']
})
export class QuestionLoginComponent implements OnInit {

  loginForm: FormGroup;
  authModel : PasswordAuth

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
