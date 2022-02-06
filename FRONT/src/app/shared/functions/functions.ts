import { INotificacao } from "../components/Notificacao";

function limparTimeouts() {

    let id = window.setTimeout(() => { }, 0);

    while (id--) {

        window.clearTimeout(id);

    }

}

export function NotificarUsuario(refNotificacao: React.RefObject<HTMLDivElement>, novaNotificacao: INotificacao, setNotificacao: (v: INotificacao) => void, tempo?: number) {

    limparTimeouts();

    setNotificacao({ ...novaNotificacao });

    setTimeout(() => {

        refNotificacao.current?.classList.remove("fadeInRight");

        refNotificacao.current?.classList.add("fadeOutRight");

    }, tempo ? tempo : 4000);

    setTimeout(() => {

        setNotificacao({ severity: '', mensagem: '' });

    }, tempo ? tempo + 200 : 4200);

}

export function carregarImagem(url: string, timeoutT?: number) {

    return new Promise(function (resolve, reject) {

        let timeout = timeoutT || 5000;

        let timer: NodeJS.Timeout | undefined = undefined;

        let img = new Image();

        img.onerror = img.onabort = function () {

            if (timer) { clearTimeout(timer) };

            reject("error");

        };
        img.onload = function () {

            if (timer) { clearTimeout(timer) };

            resolve("success");

        };

        timer = setTimeout(function () {

            // reset .src to invalid URL so it stops previous
            // loading, but doesn't trigger new load
            img.src = "//!!!!/test.jpg";

            reject("timeout");

        }, timeout);

        img.src = url;

    });
}

export function testarImagem(url: string): boolean {

    let resultado: boolean = false;

    carregarImagem(url)
        .then(() => {

            resultado = true;

        })
        .catch(() => {

            resultado = false;

        })

    return resultado;

}