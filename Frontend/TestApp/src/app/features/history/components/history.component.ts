import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { HistoryService } from '../services/history.service';
import { HistoryData } from '../models/history.model';
import { RouterModule } from '@angular/router';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-history',
  imports: [RouterModule, DatePipe],
  templateUrl: './history.component.html',
})
export class HistoryComponent implements OnInit {
  historyData: HistoryData[] = [];

  constructor(
    private historyService: HistoryService,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.getHistoryAsync();
  }

  getHistoryAsync(): void {
    this.historyService.getHistoryAsync().subscribe({
      next: (response) => {
        if (response.success) {
          this.historyData = [...response.data];
          this.cdr.detectChanges();
        }
      },
      error: (err) => console.error('Error en la llamada HTTP:', err)
    });
  }
}
