export const API_BASE_URL = 'https://localhost:7035/api/note';
const CURRENT_URL = "http://localhost:3000"

export const AUTH_CONFIG = {
    authority: 'https://localhost:10001/',
    client_id: 'client_id_react',
    redirect_uri: `${CURRENT_URL}/signin-oidc`,
    post_logout_redirect_uri: `${CURRENT_URL}/login`,
    response_type: 'id_token token',
    scope: 'openid profile email NotesApi offline_access',
    accessTokenExpiringNotificationTime: 300,
    automaticSilentRenew: true,
    silent_redirect_uri: `${CURRENT_URL}/silent-renew`,
    extraQueryParams: {
        scope: 'openid profile email name api'
      },
    persistAccessToken: true,
}