import './styles/reset.css';
import './shared/animations/animations.css';

import { Routes } from './routes/routes';

// material-ui
import { createTheme, ThemeProvider } from '@material-ui/core';

import { RefsBuscarProdProvider } from './shared/context/RefsBuscarProdProvider';
import { ProdutoEncontradoProvider } from './shared/context/ProdutoEncontradoProvider';
import { NotificacaoProvider } from './shared/context/NotificacaoProvider';
import { AutorizacaoConsumoProvider } from './shared/context/AutorizacaoConsumoProvider';
import { EfeitoAlteracaoPaginaProvider } from './shared/context/EfeitoAlteracaoPaginaProvider';

const theme = createTheme({
    palette: {
        primary: { main: "#4754F0" },
        secondary: { main: "#37325D" },
    }
});

export const App: React.FC = () => {
    return (
        <ThemeProvider theme={theme}>
            <EfeitoAlteracaoPaginaProvider>
                <AutorizacaoConsumoProvider>
                    <NotificacaoProvider>
                        <ProdutoEncontradoProvider>
                            <RefsBuscarProdProvider>
                                <Routes />
                            </RefsBuscarProdProvider>
                        </ProdutoEncontradoProvider>
                    </NotificacaoProvider>
                </AutorizacaoConsumoProvider>
            </EfeitoAlteracaoPaginaProvider>
        </ThemeProvider>
    )
}
