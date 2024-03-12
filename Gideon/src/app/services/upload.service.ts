import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const baseUrl = 'https://localhost:44350/api';

@Injectable({
  providedIn: 'root',
})
export class UploadService {
  constructor(private http: HttpClient) {}

  upload(document: File): Observable<any> {
    const formData = new FormData();
    formData.append('file', document, document.name);

    return this.http.post(`${baseUrl}/FileUpload/upload`, formData);
  }
 
}
