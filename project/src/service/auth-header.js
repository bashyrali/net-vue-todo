export function setAuthHeader(token) {
    localStorage.setItem('token', token ? token : '');
}