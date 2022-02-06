// material-ui
import { makeStyles } from "@material-ui/core";

export const useStyles = makeStyles({

    fontMontserrat: {
        fontFamily: `"Montserrat", sans-serif`,
    },

    imagemFundoBuscaProduto: {
        position: 'fixed',
        zIndex: 1,
        width: '100%'
    },

    containerPaginaBuscaProduto: {
        width: '100%',
        height: '100%',
    },
    
    paginaBuscaProduto: {
        display: 'flex',
        flexDirection: 'column',
        position: 'fixed',
        zIndex: 2,
        padding: '1.8em 1.3em'
        // backgroundColor: '#F6F6FB'
    },

    selectAlergia: {
        border: 'none',
        backgroundColor: 'white',
        borderRadius: '0.4em',
        fontFamily: `"Montserrat", sans-serif`,
        fontWeight: 500,
        color: '#37325D'
    },

    textfieldCodBarras: {
        borderRadius: '0.6em 0.6em 0 0',
        borderColor: "#4754F0",
    },

    textoBox: {
        fontFamily: `"Nunito", sans-serif`,
        fontWeight: 'bold',
        color: "#37325D"
    }

});