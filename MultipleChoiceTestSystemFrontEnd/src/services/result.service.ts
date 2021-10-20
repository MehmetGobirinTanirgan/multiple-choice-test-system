import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResultCreateModel } from 'src/models/ResultCreateModel';
import { ResultModel } from 'src/models/ResultModel';

@Injectable()
export class ResultService {
  constructor(private httpClient: HttpClient) {}

  sendResult(result: ResultCreateModel) {
    return this.httpClient.post<ResultModel>('Result/AddResult', result);
  }

  getResult(id: string) {
    return this.httpClient.get<ResultModel>(`Result/GetResult/${id}`);
  }

  saveResultID(id: string) {
    localStorage.setItem('resultID', id);
  }

  getResultID(): string | null{
    return localStorage.getItem('resultID');
  }
}
