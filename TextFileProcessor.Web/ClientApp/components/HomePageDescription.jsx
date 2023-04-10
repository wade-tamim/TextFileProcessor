import React, { useState } from 'react';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import styled from 'styled-components';

function HomeDescription() {

    return(
        <Container>
            <Row>
                <Col sm={8}>
                    <StyledDiv>
                        The code challenge is to build a web application that processes files containing text.
                        The user should upload a file from his or her browser to the server and then be presented with the processed text.
                        In the processed text, the application should surround every occurrence of the most used word with foo and bar.
                        Example: If the most used word is 'hiq', the processed text should display 'foohiqbar' instead of 'hiq'.
                    </StyledDiv>
                </Col>
            </Row>
        </Container>
    );
}

export default HomeDescription;


const StyledDiv = styled.div`
  padding: 5px;
`;