import React from 'react';
import {IResourcesItem} from "../../../utils/api/types";
import CardContent from "@mui/material/CardContent";
import {CardMedia} from "@mui/material";
import Typography from "@mui/material/Typography";
import Card from "@mui/material/Card";

const ResourceItem:React.FC<IResourcesItem> = ({id, name, year, color, pantone_value}) => (
    <Card sx={{ maxWidth: 345 }}>
        <CardContent>
            <Typography variant="body2">
                {name}
            </Typography>
            <Typography variant="body2">
                {year}
            </Typography>
            <Typography variant="body2">
                {color}
            </Typography>
            <Typography variant="body2">
                {pantone_value}
            </Typography>
        </CardContent>
    </Card>
);

export default ResourceItem;