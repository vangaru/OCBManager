import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConfigService } from '../configuration/app-config.service';
import { TurnoverSheetDetailsDto } from '../dto/turnover-sheet-details-dto';
import { TurnoverSheetSummaryDto } from '../dto/turnover-sheet-summary-dto';

@Injectable({
  providedIn: 'root'
})
export class TurnoverSheetHttpService {

  constructor(private readonly httpClient: HttpClient, private config: AppConfigService) { }

  public fetchTurnoverSheetSummary(): Observable<TurnoverSheetSummaryDto[]> {
    return this.httpClient.get<TurnoverSheetSummaryDto[]>(this.config.serverBaseUrl);
  }

  public fetchTurnoverSheet(id: number): Observable<TurnoverSheetDetailsDto> {
    return this.httpClient.get<TurnoverSheetDetailsDto>(`${this.config.serverBaseUrl}/${id}`);
  }
}