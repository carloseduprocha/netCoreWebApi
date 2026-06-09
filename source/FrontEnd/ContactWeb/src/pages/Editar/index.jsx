import { useParams } from "react-router-dom"
import { useEffect, useState } from "react";
import configApi from "../../configApi";
import './Editar.css';

export default function Editar(){
const {id} = useParams();
const [contatos, setContatos] = useState([]);
const [carregando, setCarregando] = useState(true);
const [erro, setErro] = useState(null);

function editar(){
    configApi.put('/'+ "contacts/" + `${id}`, contatos)
    .then(response => {
        alert('Contato editado com sucesso!');
        window.history.back();
    })
    .catch(error => {
        alert('Erro ao editar contato: ' + (error.message || 'Tente novamente'));
    });
}

 useEffect(() => {
    const buscarContatos = async () => {
      try {
        setCarregando(true);
        const response = await configApi.get('/'+ "contacts/" + `${id}`)

        setContatos(response.data);
        setErro(null);
      } catch (err) {
        if (err.response && err.response.data) {
            const apiErrors = err.response.data.errors;
            
            if (apiErrors) {
                const mensagemErro = Object.values(apiErrors).flat().join(' | ');
                alert('Erro de validação:\n' + mensagemErro);
            } else {
               const mensagemErro = err.response.data.message || err.response.data.title || mensagemErro;
                alert('Erro na API: ' + mensagemErro);
            }
        }

        setErro('Erro ao carregar contatos: ' + (err.message || 'Tente novamente'));
        setContatos([]);
      } finally {
        setCarregando(false);
      }
    };

    buscarContatos();
  }, []);

   if (carregando) {
    return <div className="container"><p className="carregando">Carregando contatos...</p></div>;
  }

  if (erro) {
    return <div className="container"><p className="erro">{erro}</p></div>;
  }

    return(
        <div>
            <h1>Editar Contato</h1>
            <form>
                <div>
                    <label>Nome:</label>
                    <input type="text" name="nome" value={contatos.name} onChange={(e) => setContatos({...contatos, name: e.target.value})} />
                    <br />
                    <label>E-mail:</label>
                    <input type="email" name="email" value={contatos.email} onChange={(e) => setContatos({...contatos, email: e.target.value})} />
                    <br />
                    <label>Telefone:</label>
                    <input type="text" name="telefone" value={contatos.phone} onChange={(e) => setContatos({...contatos, phone: e.target.value})} />
                </div>
            </form>
            <button className="btn btn-primary texto-botao" onClick={editar}>Editar</button>
            <button className="btn btn-secondary texto-botao" onClick={() => window.history.back()}>Voltar</button>
        </div>
    )
}