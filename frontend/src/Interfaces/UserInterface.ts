import axios from "axios";
import settings from "../settings.json"

axios.defaults.headers.common['Access-Control-Allow-Headers'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Methods'] = '*';

export interface User {
    id: Number,
    Login: String,
    Role: String
}

const client = axios.create({
    baseURL: `${settings.url}/api/v1/users`,
    validateStatus: function (status) {
        return status < 500;
    }
})

export default {
    execute(method: any, resource: any, data?: any, params?: any) {
        return client({
            method,
            url: resource,
            data,
            headers: { },
            params: params
        })
    },

    login (login: String, password: String) {
        return this.execute('post', '/login', {login, password});
    },

    register (login: String, password: String) {
        return this.execute('post', 'register', {login, password});
    },

    getAll() {
        return this.execute('get', '/');
    },

    getAllFavorites(
        userId: number,
        Name: string, 
        Game: string, 
        PlatformId: number | null = null,
        page: number | null = null, 
        pageSize: Number | null = null
    ) {
      return this.execute('get', `/${userId}/favorites`, {userId}, {Name, Game, PlatformId, page, pageSize});
    },

    addFavoriteServer(userId: number, serverId: number) {
        return this.execute('post', `/${userId}/favorites/${serverId}`, {serverId, userId});
    },

    deleteFavoriteServer(userId: number, serverId: number) {
        return this.execute('delete', `/${userId}/favorites/${serverId}`);
    },

    getFavoriteServer(userId: number, serverId: number) {
        return this.execute('get', `/${userId}/favorites/${serverId}`, {serverId, userId});
    },
}

