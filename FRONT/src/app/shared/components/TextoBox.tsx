import { useStyles } from "../../styles/styles"

interface ITextoBoxProps {
    marginBottom?: string;
}

export const TextoBox: React.FC<ITextoBoxProps> = ({ children, marginBottom }) => {

    const classes = useStyles();

    return <p className={classes.textoBox} style={{ marginBottom: marginBottom || '' }}>{children}</p>

}