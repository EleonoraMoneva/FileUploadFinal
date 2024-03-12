import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { TextFileModel } from '../models/TextFileModel';

@Injectable({
  providedIn: 'root',
})
export class TextFileService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  uploadFile(file: File): Observable<any> {
    const formData: FormData = new FormData();
    formData.append('file', file);
    return this.http.post(`${this.apiUrl}TextFile/upload`, formData).pipe(
      catchError((error) => {
        console.error('Error during file upload:', error);
        throw error;
      })
    );
  }

  getAllFiles(): Observable<TextFileModel[]> {
    return this.http.get<any[]>(`${this.apiUrl}TextFile/files`);
  }
}
