import React, { useState } from 'react';
import Form from 'react-bootstrap/Form';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
import Alert from 'react-bootstrap/Alert';
import { Card } from "react-bootstrap";
import styled from 'styled-components';

function FileInput() {
    const [file, setFile] = useState(null);
    const [uploadError, setUploadError] = useState(null)
    const [processedFileModel, setProcessedFileModel] = useState(null)

    function handleSubmit(event) {
        console.log("Start")
        event.preventDefault();
        const formData = new FormData();
        formData.append('file', file);

        fetch('/upload', {
            method: 'POST',
            body: formData
        })
            .then(response => response.json())
            .then(data => {
                if (data.hasOwnProperty('errorMessage')) {
                    setUploadError(data.errorMessage);
                    setTimeout(() => {
                        setUploadError(null);
                    }, 5000);
                }
                if (data.hasOwnProperty('processedText'))
                {
                    setProcessedFileModel(data)
                    console.log(processedFileModel)
                }
            })
            .catch(error => {
                console.error(error);
            });
    }

    function handleFileChange(event) {
        const file = event.target.files[0];
        setFile(file);
        setProcessedFileModel(null);
    }

    return (
        <StyledContainer fluid="sm" >
            <Row>
                <Col sm={8}>
                    <Form onSubmit={handleSubmit}>
                            <Form.Group controlId="formFile" className="mb-3">
                                <Form.Control type="file" onChange={handleFileChange} />
                            </Form.Group>
                            <Button variant="primary" type="submit">
                                Submit
                            </Button>
                    </Form>
                    {uploadError && (
                        <Alert variant="warning" className="mt-3">
                            {uploadError}
                        </Alert>
                    )}
                </Col>
            </Row>
            {processedFileModel && (
                
                <Row>
                    <StyledCol>
                        <StyledDiv>All words count: {processedFileModel.wordsCount}</StyledDiv>
                        <StyledDiv>The most frequent word is: {processedFileModel.mostFrequentWord}</StyledDiv>
                        <StyledDiv>The most frequent word count is: {processedFileModel.mostFrequentWordCount}</StyledDiv>
                        <ScrollableCard>
                            <Card.Body>{processedFileModel.processedText}</Card.Body>
                        </ScrollableCard>
                    </StyledCol>
                </Row>
            )}
            
        </StyledContainer>
    );
}

export default FileInput;

const ScrollableCard = styled(Card)`
  max-height: 500px;
  overflow-y: scroll;
`;

const StyledCol = styled(Col)`
  padding-top: 50px;
`;

const StyledContainer = styled(Container)`
  padding: 10px;
`;

const StyledDiv = styled.div`
  padding: 5px;
`;