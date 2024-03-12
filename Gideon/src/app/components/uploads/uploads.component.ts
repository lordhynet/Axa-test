import { Component } from '@angular/core';
import { FormControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UploadService } from 'src/app/services/upload.service';

@Component({
  selector: 'app-uploads',
  templateUrl: './uploads.component.html',
  styleUrls: ['./uploads.component.css']
})
export class UploadsComponent {
  uploadForm!: FormGroup;
  fileTypeError: boolean = false;
  result : any
  constructor(private formBuilder: FormBuilder, private uploadService :UploadService ) { 
    this.uploadForm = this.formBuilder.group({
      document: [null]  
    });
  }


  onFileSelected(event: Event): void {
    const element = event.target as HTMLInputElement;
    let fileList: FileList | null = element.files;
    if (fileList && fileList.length > 0) {
      const file = fileList[0];
  
      const fileControl = this.uploadForm.get('file');
  
      if (fileControl) {
        if (!file.name.endsWith('.xlsx')) {
          fileControl.setErrors({ incorrectFileType: true });
        } else {
          fileControl.setValue(file);
          fileControl.setErrors(null);
        }
      }
    }
  }
  


  onFileSelect(event: Event) {
    const element = event.currentTarget as HTMLInputElement;
    let file: File | null = element.files?.item(0) ?? null;

    this.fileTypeError = false;
    
    if (file) {
      if (/(.csv|.xls|.xlsx)$/i.test(file.name)) {
        this.uploadForm.patchValue({
          document: file
        });
      } else {
        this.fileTypeError = true;
        this.uploadForm.reset();
      }
    }
  }

  onUpload(): void {
    if (this.uploadForm.valid && !this.fileTypeError) {
    
      const fileToUpload = this.uploadForm.get('document')?.value;
console.log(fileToUpload)
      
      if (fileToUpload) {
        // Call the upload service
        this.uploadService.upload(fileToUpload).subscribe(
          (event) => {
            
            console.log('Upload successful:', event);
            this.result = event
          },
          (error) => {
           
            console.error('Error uploading file:', error);
          }
        );
      }
    } else {
      console.error('Form is not valid or file type error exists');
    }
  }
  resetUpload() {
    this.uploadForm.reset();
    this.fileTypeError = false;
  }
}
