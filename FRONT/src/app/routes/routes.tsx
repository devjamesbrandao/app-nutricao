// react-router
import { BrowserRouter, Routes as Switch, Route, Navigate } from "react-router-dom";

// pages
import { BuscaProduto } from "../pages/BuscaProduto";
import { ExibicaoProduto } from "../pages/ExibicaoProduto";
import { AutorizacaoConsumo } from "../pages/AutorizacaoConsumo";

export const Routes: React.FC = () => {
    return <BrowserRouter>
        <Switch>

            <Route path="/" element={<BuscaProduto />} />

            <Route path="/exibicao-produto" element={<ExibicaoProduto />} />

            <Route path="/autorizacao-consumo" element={<AutorizacaoConsumo />} />

            <Route path="*" element={<Navigate to="/" />} />

        </Switch>
    </BrowserRouter>
}