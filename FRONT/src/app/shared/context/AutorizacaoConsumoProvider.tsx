import React, { createContext, useContext, useState } from "react";

interface IAutorizacaoConsumoContext {
    podeConsumir: boolean;
    setPodeConsumir: (v: boolean) => void;
}

export const AutorizacaoConsumoContext = createContext<IAutorizacaoConsumoContext>({} as IAutorizacaoConsumoContext);

export const AutorizacaoConsumoProvider: React.FC = ({ children }) => {

    const [podeConsumir, setPodeConsumir] = useState<boolean>(false);

    return <AutorizacaoConsumoContext.Provider
        value={{
            podeConsumir, setPodeConsumir
        }}
    >
        {children}
    </AutorizacaoConsumoContext.Provider>

}

export const useAutorizacaoConsumoProv = () => { return useContext(AutorizacaoConsumoContext) }