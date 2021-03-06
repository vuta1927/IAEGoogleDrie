import { Injectable } from '@angular/core';
import { IConfiguration } from '../models/configuration.model';

import { Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { StorageService } from './storage.service';

@Injectable()
export class ConfigurationService {
    serverSettings: IConfiguration;
    // observable that is fired when settings are loaded from server
    private settingsLoadedSource = new Subject();
    settingsLoaded$ = this.settingsLoadedSource.asObservable();
    isReady: boolean = false;

    constructor(private http: HttpClient, private storageService: StorageService) {}

    load() {
        this.serverSettings = {identityUrl: '', apiUrl: ''}
        this.serverSettings.identityUrl = 'http://localhost:5000';
        this.serverSettings.apiUrl = 'http://localhost:5000';
        this.storageService.store('identityUrl', this.serverSettings.identityUrl);
        this.isReady = true;
        this.settingsLoadedSource.next();
        // const baseURI = document.baseURI.endsWith('/') ? document.baseURI : `${document.baseURI}/`;
        // let url = `${baseURI}Home/Configuration`;
        // this.http.get<IConfiguration>(url).subscribe(result => {
        //     this.serverSettings = result;
        //     console.log(this.serverSettings)
        //     this.storageService.store('identityUrl', this.serverSettings.identityUrl);
        //     this.isReady = true;
        //     this.settingsLoadedSource.next();
        // })
    }
}