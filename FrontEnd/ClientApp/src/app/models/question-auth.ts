import { Question } from './';
export class QuestionAuth{
    public username : string;
    public questionAnswers : Question[];
    public constructor(username : string, questions : Question[]){
        this.username = username;
        this.questionAnswers = questions;
    } 
}