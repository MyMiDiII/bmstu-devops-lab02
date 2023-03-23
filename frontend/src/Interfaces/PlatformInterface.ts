import axios from "axios";
import settings from "../settings.json"

axios.defaults.headers.common['Access-Control-Allow-Headers'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Methods'] = '*';

export interface Platform {
    id: Number,
    name: string,
    cost: Number,
    popularity: Number
}

const client = axios.create({
    baseURL: `${settings.url}/api/v1/platforms`,
    validateStatus: function (status) {
        return status < 500;
    }
})

export default {
    name: "PlatformInterface",

    execute(method: any, resource: any, data?: any) {
        return client({
                    method,
                    url: resource,
                    data,
                    headers: { }
                });
    },

    getAll() {
      return this.execute('get', '/');
    },

    async getById(id: Number) {
        return await this.execute('get', `/${id}`)
    },
}

