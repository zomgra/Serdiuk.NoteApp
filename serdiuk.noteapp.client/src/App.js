import './App.css';
import { Route, Routes } from 'react-router-dom'
import 'bootstrap/dist/css/bootstrap.min.css';
import HomePage from './Pages/HomePage';
import PrivateRouter from './utils/Router/PrivateRouter';
import LoginCallbackPage from './Pages/CallBackPages/LoginCallbackPage';
import LoginRedirectPage from './Pages/LoginPage/LoginRedirectPage';

function App() {
  return (
    <Routes className="container">
      <Route element={<PrivateRouter />}>
        <Route element={<HomePage />} path='/'></Route>
      </Route>

      <Route path='/login' element={<LoginRedirectPage />}></Route>
      <Route path='/signin-oidc' element={<LoginCallbackPage />}></Route>
    </Routes>
  );
}

export default App;
