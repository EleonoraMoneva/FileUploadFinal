import { Component, OnInit } from '@angular/core';
import { UploadFileModel } from 'src/app/models/UploadFileModel';
import { FileUploadService } from 'src/app/services/file-upload.service';
import * as Color from 'color';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css'],
})
export class ChartComponent implements OnInit {
  chartData: any[] = [];

  constructor(private fileUploadService: FileUploadService) {}

  ngOnInit(): void {
    this.fileUploadService.getChartData().subscribe((data) => {
      this.chartData = data.map((item) => ({
        name: item.label,
        value: item.number,
        color: this.getColorByName(item.color),
      }));
    });
  }

  getColorByName(colorName: string): string {
    try {
      const color = Color(colorName);
      return color.rgb().string();
    } catch (error) {
      return 'pink';
    }
  }
}
