import React from 'react';
import {IUserItem} from "../../../utils/api/types";
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import Typography from '@mui/material/Typography';
import {CardMedia} from "@mui/material";
const UserItem:React.FC<IUserItem> = ({email, first_name, last_name, avatar}) => (
    <Card sx={{ maxWidth: 345 }}>
        <CardContent>
            <CardMedia
                sx={{ height: 140 }}
                image={avatar}
            />
            <Typography variant="body2">
                {email}
            </Typography>
            <Typography variant="body2">
                {first_name}
            </Typography>
            <Typography variant="body2">
                {last_name}
            </Typography>
        </CardContent>
    </Card>
);

export default UserItem;