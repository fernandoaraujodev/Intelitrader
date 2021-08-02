import React, {useEffect, useState} from 'react';
import { Card, Container, Form, Button, Table } from 'react-bootstrap';
import './index.css';
import { ToastProvider, useToasts } from 'react-toast-notifications';

import { url } from '../../utils/constants';

import Rodape from './../../components/Rodape/index';
import Menu from './../../components/Menu/index';

const Cadastro = () => {
    const [id, setId] = useState(0);
    const [nome, setNome] = useState('');
    const [dataNascimento, setDataNascimento] = useState(new Date());
    const [sexo, setSexo] = useState(0);
    const [usuarios, setUsuarios] = useState([]);
    //const { addToast } = useToasts();

    useEffect(() => {
        listar();
    }, [])

    const listar = () => {

        fetch(`${url}/usuario`)
            .then(response => response.json())
            .then(dados => {
                setUsuarios(dados);
                console.log(dados)
            })
            .catch(err => console.error(err));
    }

    const salvar = (event) => {
        event.preventDefault();

        const usuario = {
            nome : nome,
            dataNascimento : dataNascimento,
            sexo : parseInt(sexo)
        }
        console.log(JSON.stringify(usuario))

        //if ternário para saber se vai fazer um post ou put
        let method = (id === 0 ? 'POST' : 'PUT');
        let urlRequest = (id === 0 ? `${url}/usuario` :  `${url}/usuario/${id}`);

        fetch(urlRequest, {
            method : method,
            body : JSON.stringify(usuario),
            headers : {
                'content-type' : 'application/json'
            }
        })
        .then(response => response.json())
        .then(dados => {
            
            console.log(usuarios);
            
            limparCampos();

            listar();
        })
        
        .catch(err => {
            console.error(err)
        })

            
    }


    const limparCampos = () => {
        setId(0);
        setNome('');
        setDataNascimento(new Date());
        setSexo(0);
    }


    const editar = (event) => {
        event.preventDefault();

        fetch(`${url}/usuario/` + event.target.value, {
            method : 'GET',
        })
        .then(response => response.json())
        .then(dado => {
            setId(dado.id);
            setNome(dado.nome);
            setSexo(dado.sexo);
            setDataNascimento(dado.dataNascimento);

        })
        .catch(err => {
            console.error(err)
        })
    }

    const remover = (event) => {
        event.preventDefault();

        fetch(`${url}/usuario/` + event.target.value,{
            method : 'DELETE',
        })
        .then(response => response.json())
        .then(dados => {

            listar();
        })
    }

    

    return (
        <div>
            <Menu />
                <Container>
                    <h1 style={{marginTop: '3rem', fontFamily: 'Lato'}}>GERENCIANDO USUÁRIO</h1>
                    <Card style={{marginTop: '3rem'}}>
                        <Card.Body>
                        <Form onSubmit={ event => salvar(event)}>
                            <Form.Group controlId="formBasicName">
                                <Form.Label>Nome</Form.Label>
                                <Form.Control type="text" value={nome} onChange={event => setNome(event.target.value)} placeholder="Informe seu nome" />
                            </Form.Group>
                            
                            <Form.Group controlId="formBasicDate">
                                <Form.Label>Data de Nascimento</Form.Label>
                                <Form.Control type="date" value={dataNascimento} onChange={event => setDataNascimento(event.target.value)} />
                            </Form.Group>

                            <Form.Group >
                            <Form.Label>Sexo</Form.Label>    
                                <Form.Control as="select" value={sexo} onChange={event => setSexo(event.target.value)} >
                                    
                                    <option selected>Selecione</option>    
                                    <option value={1}>Masculino</option>
                                    <option value={2}>Feminino</option>
                                    <option value={3}>Outros</option>
                                   
                                </Form.Control>
                            </Form.Group>

                            <Button type="submit" style={{marginTop: '1rem', background: 'green'}} >Salvar</Button>
                            
                            <Button type="button" style={{marginTop: '1rem', marginLeft: '1rem', background: '#212529'}} onClick={ event => limparCampos(event)}>Cancelar</Button>
                        </Form>
                        </Card.Body>
                    </Card>

                    
                    <Table style={{marginTop: '3rem'}}>
                        <thead>
                            <tr>
                                <th>Nome</th>
                                <th>Data de nascimento</th>
                                <th>Sexo</th>
                                <th>Data Criação</th>
                                <th>Data Alteração</th>
                                <th>Ações</th>
                            </tr>
                        </thead>
                                
                        <tbody>
                            {
                                usuarios.map((item, index) => {
                                    return (
                                        
                                        <tr>
                                            <td>{item.nome}</td>
                                            <td>{item.dataNascimento}</td>
                                            <td>{item.sexo}</td>
                                            <td>{item.dataCriacao}</td>
                                            <td>{item.dataAlteracao}</td>
                                            
                                            
                                            <td>
                                                
                                            <Button type="button" variant="warning" value={item.id} onClick={ event => editar(event)}>Editar</Button>
                                            <Button type="button" variant="danger" value={item.id} style={{ marginLeft : '1rem',}} onClick={ event => remover(event)}>Remover</Button>
                                            
                                            </td>
                                            
                                        
                                        </tr>            
                                    
                                    )
                                })
                            }
                        </tbody>
                    </Table>

                </Container>
            <Rodape />   
        </div>
    )

}

export default Cadastro;