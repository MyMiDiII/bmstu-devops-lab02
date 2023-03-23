import axios from "axios";
import settings from "../settings.json"

axios.defaults.headers.common['Access-Control-Allow-Headers'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Origin'] = '*';
axios.defaults.headers.common['Access-Control-Allow-Methods'] = '*';

export interface Hosting {
    id: Number,
    name: string,
    pricePerMonth: Number,
    subMonths: Number
}

const client = axios.create({
    baseURL: `${settings.url}/api/v1/hostings`,
    validateStatus: function (status) {
        return status < 500;
    }
})

export default {
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

    getById(id: number) {
        return this.execute('get', `/${id}`);
    },
}

