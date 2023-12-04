import React from 'react';
import logo from './logo.svg';
import './App.css';
import {Route, Routes} from "react-router-dom";
import UserPage from "./Pages/UserPage/UserPage";
import CreateUserPage from "./Pages/UserPage/compontments/CreateUserPage";
import UpdateUserPage from "./Pages/UserPage/compontments/UpdateUserPage";
import ResourcePage from "./Pages/ResourcePage/ResourcePage";

function App() {
  return (
    <div className="wrapper">
        <Routes>
          <Route path='/' element={<UserPage/>}></Route>
          <Route path='create' element={<CreateUserPage/>}></Route>
          <Route path='update' element={<UpdateUserPage/>}></Route>
          <Route path='resource' element={<ResourcePage/>}></Route>
        </Routes>
    </div>
  );
}

export default App;
