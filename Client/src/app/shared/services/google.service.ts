import { Injectable } from '@angular/core';
import { GoogleAuthService } from "ng-gapi";

@Injectable()
export class GoogleService {
    public static SESSION_STORAGE_KEY: string = 'accessToken';
    private user: any;
    
    constructor(private googleAuth: GoogleAuthService){ 
    }
    
    public getToken(): string {
        let token: string = sessionStorage.getItem(GoogleService.SESSION_STORAGE_KEY);
        if (!token) {
            throw new Error("no token set , authentication required");
        }
        return sessionStorage.getItem(GoogleService.SESSION_STORAGE_KEY);
    }
    
    public signIn(): void {
        this.googleAuth.getAuth()
            .subscribe((auth) => {
                auth.signIn().then(res => this.signInSuccessHandler(res)).then(()=>{
                    return this.user;
                });
            });
    }
    
    private signInSuccessHandler(res: any) {
            this.user = res;
            sessionStorage.setItem(
                GoogleService.SESSION_STORAGE_KEY, res.getAuthResponse().access_token
            );
        }
}