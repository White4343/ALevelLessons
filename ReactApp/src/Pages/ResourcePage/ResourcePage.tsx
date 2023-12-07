import React, {useEffect, useState} from 'react';
import Footer from "../../components/Footer/Footer";
import {IResources, IUsers} from "../../utils/api/types";
import {ResourceAPI, UserAPI} from "../../utils/api";
import s from './ResourcePage.module.scss'
import ResourceItem from "./compontments/ResourceItem";

const ResourcePage:React.FC = (props) => {
    const [resources, setResources] = useState<IResources>()

    const fetchResources = async () => {
        try {
            const resources = await ResourceAPI.getResources("2");
            setResources(resources);
        } catch (e) {
            console.log(e)
            alert(e)
        }
    }

    useEffect(() => {
        fetchResources()
    }, [])

    return (
        <>
            <div className={s.wrapper}>
                {
                    resources?.data.map(m => <ResourceItem color={m.color} id={m.id} name={m.name} pantone_value={m.pantone_value} year={m.year}/>)
                }
            </div>

            <Footer/>
        </>
        )
};

export default ResourcePage;