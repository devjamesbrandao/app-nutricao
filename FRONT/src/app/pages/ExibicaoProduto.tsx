import { useEffect, useRef } from "react"

// react-router
import { useNavigate } from "react-router-dom";

// contexts
import { useProdutoEncontradoProv } from "../shared/context/ProdutoEncontradoProvider";

// images
import imagemProdutoSemImg from '../assets/imagemProdutoSemImg.svg';

// material-ui
import { Button, IconButton, makeStyles } from "@material-ui/core";

// react-icons
import { BsChevronLeft } from 'react-icons/bs';
import { RiCupFill } from 'react-icons/ri';
import { testarImagem } from "../shared/functions/functions";
import { useAutorizacaoConsumoProv } from "../shared/context/AutorizacaoConsumoProvider";
import { useEfeitoAlteracaoPaginaProv } from "../shared/context/EfeitoAlteracaoPaginaProvider";

const useStyles = makeStyles({

    paginaExibicaoProduto: {
        padding: '1em 1.5em',
        display: 'grid',
        rowGap: '1em',
        backgroundColor: 'white'
    },

    topo: {
        display: 'flex',
        alignItems: 'center',
        fontFamily: `"Montserrat", sans-serif`,
        color: '#37325D',
        fontWeight: 600,
        fontSize: '1.1em'
    },

    tituloTopo: {
        width: '100%',
        textAlign: 'center',
    },

    containerImagem: {
        background: 'rgba(222, 222, 233, 0.15)',
        borderRadius: '0.3em',
        padding: '1em',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center'
    },

    containerInfoItem: {
        paddingBottom: '1em',
        borderBottom: '1px solid rgba(186, 185, 208, 0.4)',
    },

    tituloItem: {
        color: '#37325D',
    },

    marcaItem: {
        fontWeight: 700,
        color: '#4754F0',
    },

    descricaoItem: {
        marginTop: '0.5em',
        fontFamily: `"Poppins", sans-serif`,
        textAlign: 'justify',
        color: '#6A6495',
        lineHeight: '22px'
    },

    tituloIngredientes: {
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'space-between'
    },

})

interface IImagemExibicaoProdutoProps {
    src: string
}

const ImagemExibicaoProduto: React.FC<IImagemExibicaoProdutoProps> = ({ src }) => {

    return <img src={src} alt="foto do produto" style={{ height: '7.5em', maxWidth: '100%' }} />

}

export const ExibicaoProduto: React.FC = () => {

    const classes = useStyles();

    const { produtoEncontrado, setProdutoEncontrado, valorInicialProdutoEncontrado } = useProdutoEncontradoProv();

    const { setPodeConsumir } = useAutorizacaoConsumoProv();

    const { avancandoPagina, setAvancandoPagina, setVoltandoPagina } = useEfeitoAlteracaoPaginaProv();

    const navigate = useNavigate();

    const refPaginaExibicaoProduto = useRef<HTMLDivElement>(null);

    function verificarPodeConsumir() {

        const valor = Math.random() * (3 - 1) + 1;

        if (valor % 2 === 0) { setPodeConsumir(true) } else { setPodeConsumir(false) }

        setAvancandoPagina(true);

        navigate("/autorizacao-consumo");

    }

    function voltarParaBusca() {

        setProdutoEncontrado(valorInicialProdutoEncontrado);

        setVoltandoPagina(true);

        navigate("/");

    }

    useEffect(() => {

        if (!produtoEncontrado.idProduto) { navigate("/") }

        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, []);

    useEffect(() => {

        if (avancandoPagina) {

            refPaginaExibicaoProduto.current?.classList.add("avancandoPagina");

            setAvancandoPagina(false);

        }

        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, []);

    return <div className={classes.paginaExibicaoProduto} ref={refPaginaExibicaoProduto}>

        <section className={classes.topo}>

            <IconButton onClick={voltarParaBusca}>
                <BsChevronLeft color="#37325D" />
            </IconButton>

            <span className={classes.tituloTopo}>

                <p>Produto encontrado</p>

            </span>

        </section>

        <section className={classes.containerImagem}>

            {
                produtoEncontrado.urlImagem.length > 0 ?
                    <ImagemExibicaoProduto src={produtoEncontrado.urlImagem} />
                    :
                    <ImagemExibicaoProduto src={imagemProdutoSemImg} />
            }

        </section>

        <section className={classes.containerInfoItem}>

            <h1 className={classes.tituloItem}>{produtoEncontrado.titulo || "Desconhecido"}</h1>

            <span className={classes.marcaItem}>{produtoEncontrado.marca || "Marca desconhecida"}</span>

            <p className={classes.descricaoItem}>{produtoEncontrado.descricao}</p>

        </section>

        <section>

            <div className={classes.tituloIngredientes}>

                <span style={{
                    fontFamily: `"Montserrat", sans-serif`,
                    color: '#37325D',
                    fontWeight: 600,
                    marginBottom: '0.5em'
                }}>Ingredientes</span>

                <RiCupFill size="1.1em" color="#DEDEE9" />

            </div>

            {
                produtoEncontrado.ingredientes.length > 0 ?
                    <div style={{
                        display: 'flex',
                        flexDirection: 'column'
                    }}>

                        {
                            produtoEncontrado.ingredientes.map((nomeIngrediente, k) => {

                                return <span
                                    key={k}
                                    style={{
                                        color: '#37325D',
                                        padding: '0.5em',
                                        background: k % 2 === 0 ? 'white' : 'rgba(222, 222, 233, 0.15)',
                                        width: '100%'
                                    }}
                                >{nomeIngrediente}</span>

                            })
                        }

                    </div>
                    :
                    <em>Não foi possível encontrar nenhum ingrediente deste produto.</em>
            }

            <Button
                variant="contained"
                color="primary"
                style={{
                    textTransform: 'none',
                    fontWeight: 'bold',
                    height: '3.5em',
                    width: '100%',
                    fontSize: '1.1em',
                    marginTop: '1em'
                }}
                onClick={verificarPodeConsumir}
            >
                Posso ingerir o produto ?
            </Button>

        </section>

    </div>

}