import './App.css';
import React from 'react';
import { Route, Routes, useNavigate } from 'react-router-dom'
import 'bootstrap/dist/css/bootstrap.min.css';
import HomePage from './Pages/HomePage';
import PrivateRouter from './utils/Router/PrivateRouter';
import LoginCallbackPage from './Pages/CallBackPages/LoginCallbackPage';
import LoginRedirectPage from './Pages/LoginPage/LoginRedirectPage';
import { createNewNote } from './utils/Services/NotesService';
import CreateNotePage from './Pages/CreateNotePage/CreateNotePage';
import EditNotePage from './Pages/EditNotePage/EditNotePage';


export const CreateNoteContext = React.createContext(null);
function App() {
  const navigate = useNavigate();

  async function createNote(title, details) {
    console.log({title, details});
    var data = await createNewNote(title, details).then(id=>navigate(`edit/${id}`));
  }

  return (
    <CreateNoteContext.Provider value={createNote}>
      <Routes className="container">
        <Route element={<PrivateRouter />}>
          <Route element={<HomePage />} path='/'></Route>
          <Route element={<CreateNotePage />} path='/create'></Route>
          <Route element={<EditNotePage/>} path='/edit/:id'></Route>
        </Route>

        <Route path='/login' element={<LoginRedirectPage />}></Route>
        <Route path='/signin-oidc' element={<LoginCallbackPage />}></Route>
      </Routes>
    </CreateNoteContext.Provider>
  );
}

export default App;
