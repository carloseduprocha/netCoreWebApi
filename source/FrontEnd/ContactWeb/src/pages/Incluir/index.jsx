import { useState } from "react";
import configApi from "../../configApi";

export default function Incluir(){
    const [contato, setContato] = useState({
        name: '',
        email: '',
        phone: ''
    });

    function handleSubmit(e){
        e.preventDefault();
        configApi.post('/'+ "contacts", contato)
        .then(response => {
            alert('Contato incluído com sucesso!');
            setContato({ name: '', email: '', phone: '' });
             window.history.back();
        })
        .catch(error => {
            if (error.response && error.response.data) {
                const apiErrors = error.response.data.errors;
                
                if (apiErrors) {
                    const mensagensDeErro = Object.values(apiErrors).flat().join('\n');
                    alert('Erro de validação:\n' + mensagensDeErro);
                } else {
                    const mensagemMensagem = error.response.data.message || error.response.data.title || 'Dados inválidos.';
                    alert('Erro na API: ' + mensagemMensagem);
                }

            } else {
                alert('Erro ao incluir contato: ' + (error.message || 'Tente novamente'));
            }
        });
    }

    return(
        <div>
            <h1>Incluir Contato</h1>
            <form onSubmit={handleSubmit}>
                <div>   
                    <label>Nome:</label>
                    <input type="text" name="nome" value={contato.name} onChange={(e) => setContato({...contato, name: e.target.value})} />
                    <br />
                    <label>E-mail:</label>
                    <input type="email" name="email" value={contato.email} onChange={(e) => setContato({...contato, email: e.target.value})} />
                    <br />
                    <label>Telefone:</label>
                    <input type="text" name="telefone" value={contato.phone} onChange={(e) => setContato({...contato, phone: e.target.value})} />
                    <br />
                </div>
            </form>
            <button className="btn btn-primary texto-botao" onClick={handleSubmit}>Incluir</button>
            <button className="btn btn-secondary texto-botao" onClick={() => window.history.back()}>Voltar</button>
        </div>
    )
}