import React, {createContext, useState} from 'react';
import logo from './logo.svg';
import './App.css';
import {Route, Routes} from "react-router-dom";
import UserPage from "./Pages/UserPage/UserPage";
import CreateUserPage from "./Pages/UserPage/compontments/CreateUserPage";
import UpdateUserPage from "./Pages/UserPage/compontments/UpdateUserPage";
import ResourcePage from "./Pages/ResourcePage/ResourcePage";
import {IAppStore} from "./utils/store/appStore";
import AuthStore from "./utils/store/AuthStore";

const store: IAppStore = {
    'authStore':  new AuthStore()
}
export const AppStoreContext = createContext(store);

function App() {
    const [appStore, setAppStore] = useState(store);

  return (
    <div className="wrapper">
        <AppStoreContext.Provider value={appStore}>
            <Routes>
              <Route path='/' element={<UserPage/>}></Route>
              <Route path='create' element={<CreateUserPage/>}></Route>
              <Route path='update' element={<UpdateUserPage/>}></Route>
              <Route path='resource' element={<ResourcePage/>}></Route>
            </Routes>
        </AppStoreContext.Provider>
    </div>
  );
}

export default App;
