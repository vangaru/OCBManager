import { Component, OnInit, ViewChild } from '@angular/core';
import { MessageService } from 'primeng/api';
import { FileUpload } from 'primeng/fileupload';
import { TurnoverSheetSummaryDto } from 'src/app/core/dto/turnover-sheet-summary-dto';
import { TurnoverSheetHttpService } from 'src/app/core/http/turnover-sheet-http.service';

@Component({
  selector: 'ocb-turnover-sheet',
  templateUrl: './turnover-sheet.component.html',
  styleUrls: ['./turnover-sheet.component.css'],
  providers: [MessageService]
})
export class TurnoverSheetComponent implements OnInit {
  
  @ViewChild('uploadOcb') private fileUpload: FileUpload = {} as FileUpload;

  public turnoverSheet: TurnoverSheetSummaryDto[] = [];

  constructor(
    private readonly turnoverSheetHttpService: TurnoverSheetHttpService,
    private readonly messageService: MessageService) {}

  public ngOnInit(): void {
    this.refreshSheet();
  }

  public onOcbAttached(event: any): void {
   let ocbFile = event.files[0] as File;
   const formData = new FormData();
   formData.append('file', ocbFile, ocbFile.name);
   this.turnoverSheetHttpService.uploadOcbFile(formData).subscribe(_ => {
    this.refreshSheet();
    this.showSuccessMessage(ocbFile.name);
    this.fileUpload.clear();
   },
    (error) => {
      this.showFailureMessage(error.error.message);
      this.fileUpload.clear();
    });
  }

  private refreshSheet(): void {
    this.turnoverSheetHttpService.fetchTurnoverSheetSummary().subscribe(sheetSummary => {
      this.turnoverSheet = [...sheetSummary];
    });
  }

  private showSuccessMessage(fileName: string): void {
    this.messageService.add({severity: "success", summary: "OCB файл был успешно загружен.", detail: fileName});
  }

  private showFailureMessage(errorMessage: string): void {
    this.messageService.add({severity: "error", summary: "Ошибка сервера", detail: errorMessage});
  }
}