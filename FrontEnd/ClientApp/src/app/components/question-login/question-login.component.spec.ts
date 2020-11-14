import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuestionLoginComponent } from './question-login.component';

describe('QuestionLoginComponent', () => {
  let component: QuestionLoginComponent;
  let fixture: ComponentFixture<QuestionLoginComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuestionLoginComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuestionLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
