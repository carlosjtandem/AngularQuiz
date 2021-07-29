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

   displayTimeElapsed() {
    return Math.floor(this.seconds / 3600) + ':' + Math.floor(this.seconds / 60) + ':' + Math.floor(this.seconds % 60);
  }

  getParticipantName() {
  
    var participant = (localStorage.getItem('participant'));
    console.log(participant);
    // return participant.Name;
    return "carlitos";

  }

   getLocalStorage(): Storage {
    return localStorage;
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
  getAnswers() {
    var body = this.qns.map(x => x.QnID);
    return this.http.post(this.rootUrl + '/api/Answers', body);
  }

  // submitScore() {
  //   var body = JSON.parse(localStorage.getItem('participant'));
  //   body.Score = this.correctAnswerCount;
  //   body.TimeSpent = this.seconds;
  //   return this.http.post(this.rootUrl + "/api/UpdateOutput", body);
  // }
}

