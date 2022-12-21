import { HttpClientModule } from '@angular/common/http';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppConfigService } from './core/configuration/app-config.service';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
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