import axios, { AxiosInstance } from "axios";

function criarApi(): AxiosInstance {

    return axios.create({
        baseURL: 'https://localhost:7015'
    })

}

export const api = criarApi();