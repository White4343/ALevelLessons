import React, {useEffect, useState} from 'react';
import {IUsers} from "../../utils/api/types";
import {UserAPI} from "../../utils/api";
import UserItem from "./compontments/UserItem";
import s from './UserPage.module.scss'
import {BottomNavigation, BottomNavigationAction} from "@mui/material";
import {useNavigate} from "react-router-dom";
import Footer from "../../components/Footer/Footer";

const UserPage:React.FC = (props) => {
    const [users, setUsers] = useState<IUsers>()

    const fetchUsers = async () => {
        try {
            const users = await UserAPI.getUsers("2");
            setUsers(users);
        } catch (e) {
            console.log(e)
            alert(e)
        }
    }

    useEffect(() => {
        fetchUsers()
    }, [])

    return (
        <>
            <div className={s.wrapper}>
                {
                    users?.data.map(m => <UserItem avatar={m.avatar} email={m.email} first_name={m.first_name} id={m.id} last_name={m.last_name}/>)
                }
            </div>

            <Footer/>
        </>
        )
};

export default UserPage;