import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class QuizService {
  //---------------- Properties---------------
  readonly rootUrl = 'https://localhost:44376';

   qns: any[];
  seconds: number;
  timer:any;
  qnProgress: number;
  correctAnswerCount: number = 0;

  constructor(private http: HttpClient) {
    this.qns = [];
    this.seconds=0;
    this.timer=0;
    this.qnProgress=0;
   }

  //---------------- Http Methods---------------

  insertParticipant(name: string, email: string) {
    var body = {
      Name: name,
      Email: email
    }
    return this.http.post(this.rootUrl + '/api/InsertParticipant', body);
  }

  getQuestions() {
    return this.http.get(this.rootUrl + '/api/Questions');
  }

}

