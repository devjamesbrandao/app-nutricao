import { createContext, useContext, useState } from "react";

// interfaces
import { IProduto } from "../services/ProdutosService";

interface IProdutoEncontradoContext {
    produtoEncontrado: IProduto;
    valorInicialProdutoEncontrado: IProduto;
    setProdutoEncontrado: (v: IProduto) => void;
}

export const ProdutoEncontradoContext = createContext<IProdutoEncontradoContext>({} as IProdutoEncontradoContext);

export const ProdutoEncontradoProvider: React.FC = ({ children }) => {

    const valorInicialProdutoEncontrado: IProduto = {
        idProduto: 0,
        codBarras: "",
        urlImagem: "",
        titulo: "",
        marca: "",
        descricao: "",
        ingredientes: []
    }

    const [produtoEncontrado, setProdutoEncontrado] = useState<IProduto>({ ...valorInicialProdutoEncontrado });

    return <ProdutoEncontradoContext.Provider
        value={{
            valorInicialProdutoEncontrado,
            produtoEncontrado, setProdutoEncontrado
        }}
    >
        {children}
    </ProdutoEncontradoContext.Provider>

}

export const useProdutoEncontradoProv = () => { return useContext(ProdutoEncontradoContext) };