export class TextFileModel {
  fileName: string;
  uploadedOn: Date;

  constructor() {
    this.fileName = '';
    this.uploadedOn = new Date();
  }
}
