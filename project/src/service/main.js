import {UserManager, WebStorageStateStore, User} from 'oidc-client';
import {setAuthHeader} from './auth-header'

const STS_DOMAIN = 'https://localhost:8001';
const settings = {
    client_id: 'notes-web-app',
    redirect_uri: 'http://localhost:8080/signin-oidc',
    post_logout_redirect_uri: 'http://localhost:8080/signout-oidc',
    response_type: 'code',
    scope: 'openid profile NotesWebAPI',
    authority: STS_DOMAIN,
    // userStore: new WebStorageStateStore({store: window.localStorage}),
};
const userManager = new UserManager(settings);

export async function loadUser(){
    const user = await userManager.getUser()
    console.log('User: ' + user)
    const token = user?.access_token;
    setAuthHeader(token)
}
export const signinRedirect = () => userManager.signinRedirect()

export const  signinRedirectCallback =async () => userManager.signinRedirectCallback()

export const signoutRedirect = () => {
    userManager.clearStaleState();
    userManager.removeUser();
    return userManager.signoutRedirect();
}
export const signoutRedirectCallback = () => {
    userManager.clearStaleState()
    userManager.removeUser()
    return userManager.signoutRedirectCallback()
}
export default userManager;
