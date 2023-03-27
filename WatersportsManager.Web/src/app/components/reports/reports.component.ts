import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Report } from 'src/app/models/report';
import { ReportService } from 'src/app/services/report.service';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.scss']
})
export class ReportsComponent implements OnInit {
  @Output() reportUpdated = new EventEmitter<any[]>();

  public reports: any = [];
  reportToEdit?: Report;

  loading: boolean = false;

  constructor(
    private reportApi: ReportService
  ) { }

  ngOnInit(): void {
    this.getReports();
  }

  getReports() {
    this.reportApi.getReports()
      .then(res => {
        this.reports = res;
      });
  }

  updateReportList(reports: Report[]) {
    this.getReports();
    window.location.reload();
  }

  initNewReport() {
    this.reportToEdit = new Report();
  }

  editReport(report: Report) {
    this.reportToEdit = report;
  }

  deleteReport(report: Report) {
    this.reportApi
      .deleteReport(report)
      .then(res => {
        this.reportUpdated.emit(res);
        window.location.reload();
      })
  }
}
