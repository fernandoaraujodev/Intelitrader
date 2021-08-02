import React from 'react';

import { Container, Navbar, Nav } from 'react-bootstrap';

const Menu = () => {
    return (

        <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
            <Container>
                <Navbar.Brand href="/">
                    <a class="navbar-brand" href="/">
                        <img src="https://intelitrader.com.br/images/logo@2x.png" width="200" height="80" alt="logomarca da Intelitrader" />
                    </a>
                </Navbar.Brand>
                <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                <Navbar.Collapse id="responsive-navbar-nav">
                    <Nav className="mr-auto">
                        <Nav.Link href="/cadastrar-usuario">Cadastrar</Nav.Link>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
            
    )
}

export default Menu;