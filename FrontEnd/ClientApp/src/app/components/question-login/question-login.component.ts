import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray  } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { QuestionService } from '../../services';
import { Question, UserName, QuestionAuth } from '../../models';

@Component({
  selector: 'app-question-login',
  templateUrl: './question-login.component.html',
  styleUrls: ['./question-login.component.css']
})

export class QuestionLoginComponent implements OnInit {

  userNameForm: FormGroup;
  userName : UserName;
  questionsArray : Question[];
  questionAuth : QuestionAuth;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private questionService : QuestionService
  ) { }

  ngOnInit() {
    this.userNameForm = this.formBuilder.group({
      username: ['', Validators.required],
    });
  }
  onSubmit() {
    if (this.userNameForm.invalid) {
        return;
    }
    this.userName = new UserName(this.userNameForm.value.username);
    this.questionService.getQuestions(this.userName)
        .subscribe(
            questions => {
                this.questionsArray = questions;
                console.log(this.questionsArray);
            }
    );
    
  }

  onQuestionsSubmit() {
    this.questionAuth = new QuestionAuth(this.userNameForm.value.username, this.questionsArray);
    this.questionService.login(this.questionAuth)
        .subscribe(
            questions => {
                this.router.navigate(['/']);
              }
        );
  }
}
