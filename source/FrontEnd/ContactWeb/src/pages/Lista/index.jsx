import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import configApi from '../../configApi';
import './lista.css';

export default function Lista() {
  const [contatos, setContatos] = useState([]);
  const [carregando, setCarregando] = useState(true);
  const [erro, setErro] = useState(null);
  const navigation = useNavigate();

  function handleEditar(contato){
    navigation('/editar/' + contato.id);
  }

  function handleExcluir(contato){
    if(window.confirm(`Tem certeza que deseja excluir o contato ${contato.name}?`)){
        configApi.delete('/' + "contacts/" + `${contato.id}`)
        .then(response => {
            alert('Contato excluído com sucesso!');
            setContatos(contatos.filter(c => c.id !== contato.id));
        })
        .catch(error => {
            alert('Erro ao excluir contato: ' + (error.message || 'Tente novamente'));
        });
    }
  }

  function handleAdicionar(){
    navigation('/adicionar/');
  }

  useEffect(() => {
    const buscarContatos = async () => {
      try {
        setCarregando(true);
        const response = await configApi.get('/'+ "contacts")

        setContatos(response.data);
        setErro(null);
      } catch (err) {
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

  return (
    <div className="container">
      <h1>Lista de Contatos</h1>
      {contatos.length === 0 ? (
        <p className="vazio">Nenhum contato encontrado.</p>
      ) : (
        <table className="tabela">
          <thead>
            <tr>
              <th>Nome</th>
              <th>E-mail</th>
              <th>Telefone</th>
              <th>Ações</th>
            </tr>
          </thead>
          <tbody>
            {contatos.map((contato) => (
              <tr key={contato.id}>
                <td>{contato.name}</td>
                <td>{contato.email}</td>
                <td>{contato.phone}</td>
                <td>
                    <button className="btn btn-primary texto-botao-pequeno" onClick={() => handleEditar(contato)}>Editar</button> 
                    <button className="btn btn-danger texto-botao-pequeno" onClick={() => handleExcluir(contato)}>Excluir</button>
                    
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
      <div className="botoes">
        <button className="btn-secondary texto-botao" onClick={() => handleAdicionar()}>Adicinar</button>
      </div>
      
    </div>
  );
}
