import { Button, createTheme, ThemeProvider } from "@material-ui/core"
import { BsThreeDots, BsCheck } from "react-icons/bs"
import { useAutorizacaoConsumoProv } from "../shared/context/AutorizacaoConsumoProvider";
import { IoClose } from 'react-icons/io5';
import { AiOutlineReload } from 'react-icons/ai';
import { makeStyles } from "@material-ui/styles";
import { useEffect, useRef } from "react";
import { useEfeitoAlteracaoPaginaProv } from "../shared/context/EfeitoAlteracaoPaginaProvider";
import { useNavigate } from "react-router-dom";
import { useProdutoEncontradoProv } from "../shared/context/ProdutoEncontradoProvider";

const theme = createTheme({
    palette: {
        primary: {
            main: "#4E9A00",
        },
        secondary: {
            main: "#E42E4B",
        }
    }
})

const useStyles = makeStyles({

    containerAutorizacaoConsumo: {
        height: '93vh',
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: 'space-between'
    },

    gridSection: {
        display: 'grid',
        rowGap: '1em',
        placeItems: 'center'
    },

    iconeAutorizacao: {
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        fontSize: '3.7em',
        color: 'white',
        padding: '0.5em',
        borderRadius: '1.5em',
        filter: 'drop-shadow(0px 4px 4px rgba(0, 0, 0, 0.25))'
    },

    autorizacaoVermelha: {
        backgroundColor: '#F64662',
        border: '4px solid rgba(228, 46, 75, 0.7)'
    },

    autorizacaoVerde: {
        backgroundColor: '#66C109',
        border: '4px solid rgba(78, 154, 0, 0.7)'
    },

    tituloAviso: {
        color: '#37325D',
        fontWeight: 600,
        fontFamily: `"Montserrat", sans-serif`,
        fontSize: '2em'
    },

    aviso: {
        color: '#6A6495',
        fontSize: '1.4em',
        textAlign: 'center'
    },

    btnBuscarOutroProd: {
        width: '85%',
        textTransform: 'none',
        color: 'white',
        fontSize: '1.2em',
        height: '3.5em',
        fontWeight: 700,
        fontFamily: `"Montserrat", sans-serif`
    }

})

export const AutorizacaoConsumo: React.FC = () => {

    const { podeConsumir } = useAutorizacaoConsumoProv();

    const { setProdutoEncontrado, valorInicialProdutoEncontrado } = useProdutoEncontradoProv();

    const corAutorizacao = podeConsumir ? '#4E9A00' : '#E42E4B';

    const classes = useStyles();

    const navigate = useNavigate();

    const refContainerAutorizacaoConsumo = useRef<HTMLDivElement>(null);

    const { avancandoPagina, setAvancandoPagina, setVoltandoPagina } = useEfeitoAlteracaoPaginaProv();

    function pesquisarOutroProduto() {

        setProdutoEncontrado(valorInicialProdutoEncontrado);

        setVoltandoPagina(true);

        navigate(`/`);

    }

    useEffect(() => {

        if (avancandoPagina) {

            refContainerAutorizacaoConsumo.current?.classList.add("avancandoPagina");

            setAvancandoPagina(false);

        }
        else {

            setVoltandoPagina(true);

            navigate(`/`);

        }

        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, []);

    return <ThemeProvider theme={theme}>

        <div className={classes.containerAutorizacaoConsumo} ref={refContainerAutorizacaoConsumo}>

            <section className={classes.gridSection}>

                <BsThreeDots size="5em" color={corAutorizacao} />

                <span className={`${classes.iconeAutorizacao} ${podeConsumir ? classes.autorizacaoVerde : classes.autorizacaoVermelha}`}>

                    {
                        podeConsumir ?
                            <BsCheck />
                            :
                            <IoClose />
                    }

                </span>

                <span className={classes.tituloAviso}>

                    {
                        podeConsumir ?
                            "Tudo certo!"
                            :
                            "Ops!"
                    }

                </span>

                <span className={classes.aviso}>

                    {
                        podeConsumir ?
                            "Você pode consumir o produto informado."
                            :
                            "Você não pode consumir o produto informado."
                    }

                </span>

                <span className={classes.aviso}>

                    {
                        podeConsumir ?
                            ""
                            :
                            "Contém os ingredientes: (colocar aqui os ingredientes)"
                    }

                </span>

            </section>

            <Button
                className={`${classes.btnBuscarOutroProd} ${podeConsumir ? classes.autorizacaoVerde : classes.autorizacaoVermelha}`}
                variant="contained"
                color={podeConsumir ? "primary" : "secondary"}
                onClick={pesquisarOutroProduto}
            >
                Pesquisar outro produto <AiOutlineReload size="1.3em" style={{ marginLeft: '0.5em' }} />
            </Button>

        </div>

    </ThemeProvider>

}