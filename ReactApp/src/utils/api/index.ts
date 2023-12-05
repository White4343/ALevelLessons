import axios from "axios";
import {IReqUser, IResource, IResources, IResPostUser, IResPutUser, IUser, IUsers} from "./types";

const baseAPI = axios.create({
    baseURL: `https://reqres.in/api`
})

export const UserAPI = {
    getUsers(page: string) {
        return baseAPI.get<IUsers>(`/users?page=${page}`).then(res => res.data)
    },

    getUser(userId: string) {
        return baseAPI.get<IUser>(`/users/${userId}`).then(res => res.data)
    },

    postUser({name, job} : IReqUser) {
        return baseAPI.post<IResPostUser>(`/users`).then(res => res.data)
    },

    putUser({name, job} : IReqUser, userId: string) {
        return baseAPI.put<IResPutUser>(`/users/${userId}`).then(res => res.data)
    }
}

export const ResourceAPI = {
    getResources(page: string) {
        return baseAPI.get<IResources>(`/unknown?page=${page}`).then(res => res.data)
    },

    getResource(resourceId: string) {
        return baseAPI.get<IResource>(`/unknown/${resourceId}`).then(res => res.data)
    }
}