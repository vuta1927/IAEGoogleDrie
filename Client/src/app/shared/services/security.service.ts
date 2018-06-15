import { Injectable } from '@angular/core';
import { StorageService } from './storage.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/Rx';
import { OAuthService, JwksValidationHandler } from 'angular-oauth2-oidc';
import { authPasswordFlowConfig } from '../../auth.config';
import * as _ from 'lodash';
import { ConfigurationService } from './configuration.service';
import { UtilityService } from './utility.service';
import { GoogleAuthService } from 'ng-gapi';
@Injectable()
export class SecurityService {

    constructor(private oauthService: OAuthService, private gapi: GoogleAuthService, private configurationService: ConfigurationService, private utilService: UtilityService) { }

    public Config() {
        console.log("url", this.configurationService.serverSettings.identityUrl);
        this.oauthService.configure(authPasswordFlowConfig(this.utilService.stripTrailingSlash(this.configurationService.serverSettings.identityUrl)));
        this.oauthService.setStorage(sessionStorage);
        this.oauthService.tokenValidationHandler = new JwksValidationHandler();
        this.oauthService.loadDiscoveryDocumentAndTryLogin();
        this.oauthService.setupAutomaticSilentRefresh();
    }

    public get IsAuthorized(): boolean {
        return this.oauthService.hasValidAccessToken();
    }

    public get CurrentUserData(): Observable<Object> {
        return Observable.fromPromise(this.oauthService.loadUserProfile());
    }

    public Login(id_token: string): Observable<any> {

        return Observable.fromPromise(this.oauthService.fetchTokenUsingGoogleGrant(id_token));
    }



    public getToken(): any {
        return this.oauthService.getAccessToken();
    }

    public Logoff() {
        this.oauthService.logOut();
        var auth2 = gapi.auth2.getAuthInstance();
        auth2.signOut().then();
    }

    public IsGranted(permission: string): boolean {
        if (!this.IsAuthorized) {
            return false;
        }

        let dataAccessToken: any = this.getDataFromToken(this.oauthService.getAccessToken());
        let permissions = _.values(dataAccessToken.Permission);

        return _.includes(permissions, permission);
    }

    private urlBase64Decode(str: string) {
        let output = str.replace('-', '+').replace('_', '/');
        switch (output.length % 4) {
            case 0:
                break;
            case 2:
                output += '==';
                break;
            case 3:
                output += '=';
                break;
            default:
                throw 'Illegal base64url string!';
        }

        return window.atob(output);
    }

    private getDataFromToken(token: any) {
        let data = {};
        if (typeof token !== 'undefined') {
            let encoded = token.split('.')[1];
            data = JSON.parse(this.urlBase64Decode(encoded));
        }

        return data;
    }
}