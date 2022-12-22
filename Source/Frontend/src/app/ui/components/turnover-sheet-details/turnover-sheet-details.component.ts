import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BillClassDto } from 'src/app/core/dto/bill-class-dto';
import { TurnoverSheetDetailsDto } from 'src/app/core/dto/turnover-sheet-details-dto';
import { TurnoverSheetHttpService } from 'src/app/core/http/turnover-sheet-http.service';
const fileSaver = require("file-saver");

@Component({
  selector: 'ocb-turnover-sheet-details',
  templateUrl: './turnover-sheet-details.component.html',
  styleUrls: ['./turnover-sheet-details.component.css']
})
export class TurnoverSheetDetailsComponent implements OnInit {

  private sheetId?: number;
  
  public sheetDetails?: TurnoverSheetDetailsDto;
  public billClasses: BillClassDto[] = []

  constructor(private readonly route: ActivatedRoute, private readonly turnoverSheetHttpService: TurnoverSheetHttpService) { }

  public ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.sheetId = params["id"] as number;
      this.turnoverSheetHttpService.fetchTurnoverSheet(this.sheetId).subscribe(sheet => {
        this.sheetDetails = sheet;
        this.billClasses = [...sheet.billClasses];
      });
    });
  }

  public downloadAsJson(): void {
    const ocbJson = new Blob([JSON.stringify(this.sheetDetails, null, 4)], {type: "application/json"});
    fileSaver.saveAs(ocbJson, `${this.sheetDetails?.name}.json`);
  }
}
