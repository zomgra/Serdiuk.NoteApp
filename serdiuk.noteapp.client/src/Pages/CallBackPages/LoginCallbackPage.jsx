import React, {useEffect} from 'react'
import { userManager } from '../../utils/Services/AuthService';

const LoginCallbackPage = () => {

    useEffect(() => {
        async function setAccessToken() {
            try {
                const user = await userManager.signinRedirectCallback();
                console.log(user);
                if (user) window.location.href = '/';
            } catch (e) {
                console.error("AUTH ERROR: " + e);
            }
        }
        setAccessToken();
    }, []);

    return (
        <div>
            LOADING...
        </div>
    )
}

export default LoginCallbackPage