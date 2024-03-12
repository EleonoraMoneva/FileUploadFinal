import { Component, OnInit } from '@angular/core';
import { TextFileModel } from 'src/app/models/TextFileModel';
import { FileUploadService } from 'src/app/services/file-upload.service';
import { TextFileService } from 'src/app/services/text-file.service';

@Component({
  selector: 'app-file-list',
  templateUrl: './file-list.component.html',
  styleUrls: ['./file-list.component.css'],
})
export class FileListComponent implements OnInit {
  textFiles: TextFileModel[] = [];

  constructor(private textFileService: TextFileService) {}

  ngOnInit(): void {
    this.textFileService.getAllFiles().subscribe((files) => {
      this.textFiles = files;
    });
  }
}
