import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AppConfigService {

  private readonly appConfigPath: string = "/assets/configuration/app.config.json";
  private appConfig: any = null;

  constructor(private readonly httpClient: HttpClient) { }

  public async loadAppConfig() {
    this.appConfig = await lastValueFrom(this.httpClient.get(this.appConfigPath));
    console.log(this.appConfig);
  }

  public get serverBaseUrl() {
    if (this.appConfig == null) {
      throw Error(`Cannot load configuration file from ${this.appConfigPath}`);
    }
    
    return this.appConfig.serverBaseUrl; 
  }
}