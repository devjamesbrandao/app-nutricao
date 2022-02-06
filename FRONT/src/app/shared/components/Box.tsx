import { useRefsBuscarProdProv } from "../context/RefsBuscarProdProvider"

interface IBoxProps {
    displayCentro?: boolean;
    marginBottom?: string;
    onClick?: () => void;
}

export const Box: React.FC<IBoxProps> = (props) => {

    const { refBoxBuscarProd } = useRefsBuscarProdProv();

    return <section
        style={{
            width: '100%',
            borderRadius: '0.4em',
            padding: '1em',
            backgroundColor: 'white',
            marginBottom: props.marginBottom || '',
            display: props.displayCentro ? 'grid' : '',
            placeItems: 'center',
            rowGap: '1em',
            flexDirection: 'column',
            boxShadow: '0.2em 0.2em 0.2em rgba(0,0,0,0.1)'
        }}
        ref={refBoxBuscarProd}
        onClick={props.onClick || undefined}
    >

        {props.children}

    </section>

}