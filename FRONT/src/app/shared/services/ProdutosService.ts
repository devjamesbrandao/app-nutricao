import { api } from "./ApiConfig";

export interface IProduto {
    idProduto: string;
    consumivel: boolean;
    codBarras: string;
    urlImagem: string;
    titulo: string;
    marca: string;
    descricao: string;
    ingredientes: string[];
}

const getByEan = async (ean: string): Promise<IProduto | undefined> => {

    try {

        const r = await api.get<IProduto[]>(`/nutri/v1/verificar-consumo?CodBarra=${ean}&CodUsuario=1`);

        if (r.data[0]) return r.data[0];

        console.log(r.data)

        throw new Error("");

    }
    catch (e){

        console.log(e);

        throw new Error("");

    }

}

export const ProdutosService = { getByEan };