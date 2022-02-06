import { createContext, useContext, useRef } from "react";

interface IRefsBuscarProdContext {
    refBoxBuscarProd: React.RefObject<HTMLElement> | undefined;
}

export const RefsBuscarProdContext = createContext<IRefsBuscarProdContext>({} as IRefsBuscarProdContext);

export const RefsBuscarProdProvider: React.FC = ({ children }) => {

    const refBoxBuscarProd = useRef<HTMLElement>(null);

    return <RefsBuscarProdContext.Provider
        value={{
            refBoxBuscarProd
        }}
    >
        {children}
    </RefsBuscarProdContext.Provider>

}

export const useRefsBuscarProdProv = () => { return useContext(RefsBuscarProdContext) };