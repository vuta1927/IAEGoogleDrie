import { AuthConfig } from 'angular-oauth2-oidc';

export function authPasswordFlowConfig(identityUrl: string): AuthConfig {

    return {
        // Url of the Identity Provider
        issuer: identityUrl,

        // URL of the SPA to redirect the user to after login
        redirectUri: window.location.origin,

        // URL of the SPA to redirect the user after silent refresh
        silentRefreshRedirectUri: window.location.origin,

        clientId: 'iae-client',

        dummyClientSecret: 'secret',

        scope: 'offline_access iae-api',

        showDebugInformation: true,

        oidc: false,

        requireHttps: false
    }
}