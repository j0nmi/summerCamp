import { Injectable } from '@angular/core';
import { GlobalData } from './global';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class GlobalService {
  private subject = new BehaviorSubject<GlobalData>(new GlobalData());
  state = this.subject.asObservable();

  globalData = new GlobalData(); // this is the variable you will use

  constructor() {
    this.state.subscribe((state) => (this.globalData = state));
  }
}