import { Alert } from "@material-ui/lab"

// material-ui
import { makeStyles } from "@material-ui/core";
import { useNotificacaoProv } from "../context/NotificacaoProvider";

export type TSeverityNotificacao = "success" | "error" | "warning" | "info" | '';

export interface INotificacao {
    severity: TSeverityNotificacao;
    mensagem: string;
}

const useStyles = makeStyles({

    notificacao: {
        position: 'fixed',
        top: 0,
        right: 0,
        zIndex: 10,
        marginRight: '1em',
        marginTop: '2em'
    }

})

export const Notificacao: React.FC<INotificacao> = ({ severity, mensagem }) => {

    const classes = useStyles();

    const { refNotificacao } = useNotificacaoProv();

    if (!mensagem || !severity) return null;

    return <div className={classes.notificacao + " fadeInRight"} ref={refNotificacao}>

        <Alert severity={severity}>
            {mensagem}
        </Alert>

    </div>

}