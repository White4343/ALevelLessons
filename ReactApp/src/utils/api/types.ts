export interface IUsers {
    "page": number,
    "per_page": number,
    "total": number,
    "total_pages": number,
    "data": IUserItem[]
}

export interface IUser {
    "data": IUserItem
    "support": {
        "url": string,
        "text": string
    }
}

export interface IReqUser {
    "name": string,
    "job": string
}

export interface IResPostUser {
    "name": string,
    "job": string,
    "id": number,
    "updatedAt": string
}

export interface IResPutUser {
    "name": string,
    "job": string,
    "updatedAt": string
}

export interface IUserItem {
    "id": number,
    "email": string,
    "first_name": string,
    "last_name": string,
    "avatar": string
}

export interface IResources {
    "page": number,
    "per_page": number,
    "total": number,
    "total_pages": number,
    "data": IResourcesItem[]
}

export interface IResource {
    "data": IResourcesItem
    "support": {
        "url": string,
        "text": string
    }
}

export interface IResourcesItem {
    "id": number,
    "name": string,
    "year": number,
    "color": string,
    "pantone_value": string
}