import React, { Component } from 'react';
import { Container } from 'reactstrap';

export class Layout extends Component {
    static displayName = Layout.name;

    render() {
        return (
            <div>
                <Container>
                <h1>Alacrity People Collection</h1>
                    {this.props.children}
                    <br></br><br></br>

                    <br></br><br></br>

                    <span className="span"><em>2023 Jermaine Co.</em></span>

                </Container>
            </div>
        );
    }
}