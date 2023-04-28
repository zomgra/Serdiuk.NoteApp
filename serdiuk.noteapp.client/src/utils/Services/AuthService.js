import {UserManager} from 'oidc-client'
import { AUTH_CONFIG } from '../Constances'

export const userManager = new UserManager(AUTH_CONFIG);
export async function getToken(){
    const user = await userManager.getUser();
    const token = `Bearer ${user.access_token}`
    return token;
}