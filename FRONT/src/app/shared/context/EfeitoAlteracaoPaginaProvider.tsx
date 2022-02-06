import React, { createContext, useContext, useState } from "react";

interface IEfeitoAlteracaoPaginaContext {
    avancandoPagina: boolean;
    voltandoPagina: boolean;
    setAvancandoPagina: (v: boolean) => void;
    setVoltandoPagina: (v: boolean) => void;
}

export const EfeitoAlteracaoPaginaContext = createContext<IEfeitoAlteracaoPaginaContext>({} as IEfeitoAlteracaoPaginaContext);

export const EfeitoAlteracaoPaginaProvider: React.FC = ({ children }) => {

    const [avancandoPagina, setAvancandoPagina] = useState<boolean>(false);

    const [voltandoPagina, setVoltandoPagina] = useState<boolean>(false);

    return <EfeitoAlteracaoPaginaContext.Provider
        value={{
            avancandoPagina, setAvancandoPagina,
            voltandoPagina, setVoltandoPagina
        }}
    >
        {children}
    </EfeitoAlteracaoPaginaContext.Provider>

}

export const useEfeitoAlteracaoPaginaProv = () => { return useContext(EfeitoAlteracaoPaginaContext) }