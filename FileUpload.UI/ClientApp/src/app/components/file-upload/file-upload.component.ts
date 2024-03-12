import { Component } from '@angular/core';
import { FileUploadService } from 'src/app/services/file-upload.service';
import { TextFileService } from 'src/app/services/text-file.service';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css'],
})
export class FileUploadComponent {
  selectedFile: File | null = null;

  constructor(private textFileService: TextFileService) {}

  onFileSelected(event: any): void {
    this.selectedFile = event.target.files[0];
  }

  onUpload(): void {
    if (this.selectedFile) {
      debugger;
      this.textFileService
        .uploadFile(this.selectedFile)
        .subscribe((response) => {
          console.log('File uploaded successfully:', response);
        });
    }
  }
}
