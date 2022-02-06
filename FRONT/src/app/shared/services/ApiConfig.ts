import axios, { AxiosInstance } from "axios";

function criarApi(): AxiosInstance {

    return axios.create({
        baseURL: 'http://localhost:3333'
    })

}

export const api = criarApi();