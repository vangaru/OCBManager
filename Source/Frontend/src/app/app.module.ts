import { APP_INITIALIZER, NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppConfigService } from './core/configuration/app-config.service';
import { AppComponent } from './app.component';
import { UiModule } from './ui/ui.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    AppRoutingModule,
    UiModule
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      deps: [AppConfigService],
      useFactory: (configService: AppConfigService) => {
        return async () => {
          await configService.loadAppConfig();
        }
      },
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }