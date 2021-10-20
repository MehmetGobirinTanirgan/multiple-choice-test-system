import { Injectable } from '@angular/core';
import { ResultCreateModel } from 'src/models/ResultCreateModel';

@Injectable()
export class DataService {
  constructor() {}
  result: ResultCreateModel | undefined;
}
