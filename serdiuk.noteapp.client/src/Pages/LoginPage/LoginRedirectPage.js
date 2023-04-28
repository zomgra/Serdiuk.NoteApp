import { userManager } from "../../utils/Services/AuthService";
import React from "react";

const LoginRedirectPage = () => {

    userManager.signinRedirect();
    return(<div>
        LOADING...
    </div>)
}

export default LoginRedirectPage