import React, { useCallback, useEffect, useRef, useState } from "react";
import { useNavigate } from "react-router-dom";

// styles
import { useStyles } from "../styles/styles";

// react-icons
import { FaBug } from 'react-icons/fa';

// images
import imagemFundoBuscaProduto from '../assets/imagemFundoBuscaProduto.svg';
import imagemBotaoBuscaProduto from '../assets/imagemBotaoBuscaProduto.svg';

// material-ui
import { FormControl, InputAdornment, MenuItem, Select, TextField } from "@material-ui/core";

// components
import { Box } from "../shared/components/Box";
import { TextoBox } from "../shared/components/TextoBox";

import { useRefsBuscarProdProv } from "../shared/context/RefsBuscarProdProvider";
import { ProdutosService } from "../shared/services/ProdutosService";
import { useProdutoEncontradoProv } from "../shared/context/ProdutoEncontradoProvider";
import { INotificacao, Notificacao } from "../shared/components/Notificacao";
import { NotificarUsuario } from "../shared/functions/functions";
import { useNotificacaoProv } from "../shared/context/NotificacaoProvider";
import { useEfeitoAlteracaoPaginaProv } from "../shared/context/EfeitoAlteracaoPaginaProvider";

export const BuscaProduto: React.FC = () => {

    const navigate = useNavigate();

    const classes = useStyles();

    const [alergiaSelecionada, setAlergiaSelecionada] = useState<string>("vazio");

    const [codigoBarrasProd, setCodigoBarrasProd] = useState<string>("");

    const { refBoxBuscarProd } = useRefsBuscarProdProv();

    const [notificacao, setNotificacao] = useState<INotificacao>({ severity: '', mensagem: '' });

    const { setProdutoEncontrado, valorInicialProdutoEncontrado } = useProdutoEncontradoProv();

    const { refNotificacao } = useNotificacaoProv();

    const refInputCodBarras = useRef<HTMLInputElement>(null);

    const refContainerPaginaBuscaProduto = useRef<HTMLDivElement>(null);

    const { voltandoPagina, setVoltandoPagina, setAvancandoPagina } = useEfeitoAlteracaoPaginaProv();

    const handleChangeCodBarrasProd = useCallback((e: React.ChangeEvent<{ name: string, value: any }>) => {

        const { value } = e.target;

        setCodigoBarrasProd(value);

    }, []);

    function adicionarEfeitoPulseNaOpcaoBuscarProd() {

        if (!(refBoxBuscarProd?.current?.classList.contains("pulse"))) {

            refBoxBuscarProd?.current?.classList.add("pulse");

        }

    }

    function removerEfeitoPulseNaOpcaoBuscarProd() {

        if (refBoxBuscarProd?.current?.classList.contains("pulse")) {

            refBoxBuscarProd?.current?.classList.remove("pulse");

        }

    }

    async function buscarProduto() {

        if (!alergiaSelecionada || !codigoBarrasProd) return;

        try {

            const produtoPesquisado = await ProdutosService.getByEan(codigoBarrasProd);

            setProdutoEncontrado(produtoPesquisado || valorInicialProdutoEncontrado);

            removerEfeitoPulseNaOpcaoBuscarProd();

            refBoxBuscarProd?.current?.classList.add("zoomOut");

            setTimeout(() => {

                setAvancandoPagina(true);

                navigate("/exibicao-produto");

            }, 500);

        }
        catch {

            const novaNotificacao: INotificacao = { severity: 'error', mensagem: 'Ocorreu um problema ao tentar buscar um produto com o código de barras informado' };

            NotificarUsuario(refNotificacao, novaNotificacao, setNotificacao, 5000);

            refInputCodBarras.current?.focus();

            refInputCodBarras.current?.select();

        }

    }

    useEffect(() => {

        if (alergiaSelecionada && codigoBarrasProd) {

            adicionarEfeitoPulseNaOpcaoBuscarProd();

        }
        else {

            removerEfeitoPulseNaOpcaoBuscarProd();

        }

        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [alergiaSelecionada, codigoBarrasProd]);

    useEffect(() => {

        if (voltandoPagina) {

            refContainerPaginaBuscaProduto.current?.classList.add("voltandoPagina");

            setVoltandoPagina(false);

        }

        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, []);

    return <div className={classes.containerPaginaBuscaProduto} ref={refContainerPaginaBuscaProduto}>

        <img
            className={classes.imagemFundoBuscaProduto}
            src={imagemFundoBuscaProduto}
            alt="imagemFundoBuscaProduto"
        />

        <Notificacao severity={notificacao.severity} mensagem={notificacao.mensagem} />

        <section className={`${classes.containerPaginaBuscaProduto} ${classes.paginaBuscaProduto}`} style={{ color: 'white' }}>

            <h1 style={{ marginBottom: '1em' }}>Bem vindo!</h1>

            <p className={classes.fontMontserrat} style={{ marginBottom: '2em', fontSize: '0.9em' }}>Consulte um produto abaixo e verifique se pode ou não ingerí-lo de acordo com sua alergia.</p>

            <FormControl className={classes.selectAlergia} style={{ marginBottom: '3em' }}>
                <Select
                    variant="outlined"
                    classes={{
                        root: classes.selectAlergia,
                    }}
                    startAdornment={
                        <InputAdornment position="start">
                            <FaBug size="1.3em" color="#4754F0" style={{ marginRight: '0.5em' }} />
                        </InputAdornment>
                    }
                    value={alergiaSelecionada}
                    onChange={(e) => typeof e.target.value === "string" ? setAlergiaSelecionada(e.target.value) : undefined}
                >
                    <MenuItem value="vazio">Vazio</MenuItem>
                    <MenuItem value="alergia">Nome da alergia</MenuItem>
                </Select>
            </FormControl>

            <Box marginBottom="2em">

                <TextoBox marginBottom='2em'>Informe o código de barras do produto</TextoBox>

                <TextField
                    variant="filled"
                    style={{ marginBottom: '2em', width: '100%' }}
                    InputProps={{
                        style: {
                            paddingBottom: '0.1em',
                            fontSize: '1.3em',
                            fontFamily: `"Montserrat", sans-serif`,
                            fontWeight: 500,
                            background: 'rgba(232, 232, 241, 0.4)',
                            color: "#37325D"
                        }
                    }}
                    classes={{
                        root: classes.textfieldCodBarras
                    }}
                    value={codigoBarrasProd}
                    onChange={handleChangeCodBarrasProd}
                    inputRef={refInputCodBarras}
                />

            </Box>

            <Box displayCentro onClick={buscarProduto}>

                <img src={imagemBotaoBuscaProduto} alt="caixa de pesquisa" />

                <TextoBox>Buscar informações do produto</TextoBox>

            </Box>

        </section>

    </div>

}