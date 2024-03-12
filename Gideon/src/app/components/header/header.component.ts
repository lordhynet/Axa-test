import { Component } from '@angular/core';
import { Upload } from 'src/app/models/upload.model';
import { UploadService } from 'src/app/services/upload.service';

@Component({
  selector: 'header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent {
  tutorial: Upload = {
    title: '',
    description: '',
    published: false
  };
  submitted = false;

  constructor(private tutorialService: UploadService) {}

 
}
