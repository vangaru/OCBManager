import { Component, OnInit } from '@angular/core';
import { TurnoverSheetSummaryDto } from 'src/app/core/dto/turnover-sheet-summary-dto';
import { TurnoverSheetHttpService } from 'src/app/core/http/turnover-sheet-http.service';

@Component({
  selector: 'ocb-turnover-sheet',
  templateUrl: './turnover-sheet.component.html',
  styleUrls: ['./turnover-sheet.component.css']
})
export class TurnoverSheetComponent implements OnInit {
  
  public turnoverSheet: TurnoverSheetSummaryDto[] = [];

  constructor(private readonly turnoverSheetHttpService: TurnoverSheetHttpService) {}

  public ngOnInit(): void {
    this.refreshSheet();
  }

  private refreshSheet(): void {
    this.turnoverSheetHttpService.fetchTurnoverSheetSummary().subscribe(sheetSummary => {
      this.turnoverSheet = [...sheetSummary];
    });
  }
}