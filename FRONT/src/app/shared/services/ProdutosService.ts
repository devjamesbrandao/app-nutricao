import { api } from "./ApiConfig";

export interface IProduto {
    idProduto: number;
    codBarras: string;
    urlImagem: string;
    titulo: string;
    marca: string;
    descricao: string;
    ingredientes: string[];
}

const getByEan = async (ean: string): Promise<IProduto | undefined> => {

    try {

        const r = await api.get<IProduto[]>(`/produtos?codBarras_like=${ean}`);

        if (r.data[0]) return r.data[0];

        throw new Error("");

    }
    catch {

        throw new Error("");

    }

}

export const ProdutosService = { getByEan };