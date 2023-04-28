import React, { useEffect, useState } from 'react'
import { userManager } from '../Services/AuthService';
import { Navigate, Outlet } from 'react-router-dom';

const PrivateRouter = () => {
    const [isAuth, setAuthorize] = useState( false);
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
      async function setAuth() {
          var user = await userManager.getUser();
          const isAuth = user !== null && !user.expired;
          await setAuthorize(isAuth)
          await setIsLoading(false);
        }
        setAuth();
      }, [])
    
      if (isLoading) {
        return <div>Loading...</div>;
      }
      else {
        return (
            <>
            {isAuth ? <Outlet /> : <Navigate to="/login" />}
            </>
        )
      }
}

export default PrivateRouter