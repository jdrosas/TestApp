import { ChangeDetectorRef, Component, type OnInit } from '@angular/core';
import { FactData } from '../models/fact.model';
import { FactService } from '../services/fact.service';
import { GifService } from '../services/gif.service';
import { GifData } from '../models/gif.model';
import { HistoryCreateData } from '../../history/models/history.model';
import { HistoryService } from '../../history/services/history.service';
import { getLocalIsoString } from '../../../utils/date-utils';

@Component({
  selector: 'app-result',
  imports: [],
  templateUrl: './result.component.html',
})
export class ResultComponent implements OnInit {

  factData: FactData | null = null;
  factText: string = "";
  gifs: GifData[] = [];
  currentGifUrl: string = '';
  currentIndex: number = 0;

  constructor(
    private factService: FactService,
    private gifService: GifService,
    private historyService: HistoryService,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit() {
    this.getFactAsync();
  }

  getFactAsync() {
    this.factService.getFactAsync().subscribe({
      next: (response) => {
        if (response.success) {
          this.factData = response.data;
          this.factText = response.data.fact;
          this.getGifAsync(this.formatText(this.factText))
          this.cdr.detectChanges();
        }
      },
      error: (err) => console.error('Error en la llamada HTTP:', err)
    });
  }

  getGifAsync(query: string) {
    this.gifService.getGifAsync(query).subscribe({
      next: (response) => {
        if (response.success && response.data.length > 0) {
          this.gifs = response.data;
          this.currentIndex = 0;
          this.currentGifUrl = this.gifs[this.currentIndex].images.original.url;
          console.log(this.gifs)
          this.cdr.detectChanges();
          this.createHistoryAsync();
        }
      },
      error: (err) => {
        console.error('Error en la llamada HTTP:', err);
        this.gifs = [];
        this.currentGifUrl = '';
      }
    });
  }

  createHistoryAsync() {
    const recordsHistory: HistoryCreateData = {
      dateSearch: getLocalIsoString(),
      factInfo: this.factText,
      factQuery: this.formatText(this.factText),
      urlGif: this.currentGifUrl
    };

    this.historyService.createHistoryAsync(recordsHistory).subscribe(
      {
        next: (response) => {
          if (response.success) {
            console.log('Historial guardado correctamente:', response.data);
          } else {
            console.error('Error al guardar historial:', response.message);
          }
        },
        error: (err) => console.error('Error en la llamada HTTP:', err)
      }
    )
  }

  refreshGif() {
    try {
      if (this.gifs.length === 0) return;
      this.currentIndex = (this.currentIndex + 1) % this.gifs.length;
      this.currentGifUrl = this.gifs[this.currentIndex].images.original.url;
      this.createHistoryAsync();
    } catch (error) {
      console.log(`Se ha producido un error: ${error}`)
    }
  }

  formatText(query: string) {
    const text = query.trim().replace(/\s+/g, ' ').split(' ');
    return text.slice(0, 3).join(' ');
  }

}
