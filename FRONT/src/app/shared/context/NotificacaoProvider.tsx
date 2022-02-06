import React, { createContext, useContext, useRef } from "react";

interface INotificacaoContext {
    refNotificacao: React.RefObject<HTMLDivElement>
}

export const NotificacaoContext = createContext<INotificacaoContext>({} as INotificacaoContext);

export const NotificacaoProvider: React.FC = ({ children }) => {

    const refNotificacao = useRef<HTMLDivElement>(null);

    return <NotificacaoContext.Provider
        value={{
            refNotificacao
        }}
    >
        {children}
    </NotificacaoContext.Provider>

}

export const useNotificacaoProv = () => { return useContext(NotificacaoContext) }