import React from 'react';
import {BottomNavigation, BottomNavigationAction} from "@mui/material";
import {useNavigate} from "react-router-dom";

const Footer:React.FC = (props) => {
    const [value, setValue] = React.useState(0);
    const navigate = useNavigate();

    return (
            <BottomNavigation
                showLabels
                value={value}
                onChange={(event, newValue) => {
                    setValue(newValue);
                }}
            >
                <BottomNavigationAction onClick={() => navigate(`/`)} label="Users"/>
                <BottomNavigationAction onClick={() => navigate(`/create`)} label="New User"/>
                <BottomNavigationAction onClick={() => navigate(`/update`)} label="Update User"/>
                <BottomNavigationAction onClick={() => navigate(`/resource`)} label="Resources"/>
            </BottomNavigation>
        )
};

export default Footer;