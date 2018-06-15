import { Component, OnInit, ViewEncapsulation, AfterViewInit } from '@angular/core';
import { SecurityService } from '../../shared/services/security.service';
import { UtilityService } from '../../shared/services/utility.service';
import { FormGroup } from '@angular/forms';
import { ScriptLoaderService } from '../../shared/services/script-loader.service';
import { Helpers } from '../../helpers';
import { GoogleApiModule, GoogleApiService, GoogleAuthService, NgGapiClientConfig, NG_GAPI_CONFIG, GoogleApiConfig } from "ng-gapi";
import { GoogleService } from '../../shared/services/google.service';
@Component({
    selector: '.m-grid.m-grid--hor.m-grid--root.m-page',
    templateUrl: './login.component.html',
    encapsulation: ViewEncapsulation.None
})
export class LoginComponent implements OnInit, AfterViewInit {

    public isLoggingin: boolean = false;
    public isLoginFail: boolean = false;
    constructor(
        private service: SecurityService,
        private utilityService: UtilityService,
        private _script: ScriptLoaderService,
        private gapi: GoogleApiService,
        private googleService: GoogleService,
        private gauth: GoogleAuthService,
    ) {
        gapi.onLoad().subscribe(() => {
            // Here we can use gapi
        });

        if (service.IsAuthorized) {
            utilityService.navigateToReturnUrl();
        }
    }

    ngOnInit() {
        this._script.loadScripts('body', [
            'assets/vendors/base/vendors.bundle.js',
            'assets/demo/default/base/scripts.bundle.js'
        ], true).then(() => {
            Helpers.setLoading(false);
        })
    }

    ngAfterViewInit() {
        // this._script.loadScripts('.m-grid.m-grid--hor.m-grid--root.m-page', ['assets/snippets/pages/user/login.js']);
        Helpers.bodyClass('m--skin- m-header--fixed m-header--fixed-mobile m-aside-left--enabled m-aside-left--skin-dark m-aside-left--offcanvas m-footer--push m-aside--offcanvas-default');
    }

    public login(): void {
        this.isLoggingin = true;
        this.isLoginFail = false;

        this.gauth.getAuth()
            .subscribe((auth) => {
                auth.signIn().then(res => this.signInSuccessHandler(res));
            });
        // this.service.Login(this.loginForm.value.username, this.loginForm.value.password)
        //     .subscribe(() => {
        //         this.isLoggingin = false;
        //         this.utilityService.navigateToReturnUrl();
        //     }, err => {
        //         this.isLoggingin = false;
        //         this.isLoginFail = true;
        //     });
    }

    private signInSuccessHandler(res: any) {
        var id_token = res.getAuthResponse().id_token;
        console.log(id_token);
        sessionStorage.setItem(
            GoogleService.SESSION_STORAGE_KEY, res.getAuthResponse().access_token
        );
        this.service.Login(id_token).subscribe(() => {
            this.isLoggingin = false;
            this.utilityService.navigateToReturnUrl();
        }, err => {
            this.isLoggingin = false;
            this.isLoginFail = true;
        });
    }
}