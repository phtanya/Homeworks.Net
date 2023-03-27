import React, { useState, useEffect } from "react";
import axios from 'axios';
import ApiBaseUrl, { EndPoints, EndPointInfo, ResponseInfo } from "../Config";
import Container from 'react-bootstrap/esm/Container';
import Col from "react-bootstrap/esm/Col";
import Row from 'react-bootstrap/esm/Row';
import Card from 'react-bootstrap/Card';
import ListGroup from 'react-bootstrap/ListGroup';
import Badge from 'react-bootstrap/Badge';
import Spinner from 'react-bootstrap/Spinner';

function Reqres() {
  const [currentEndpoint, setCurrentEndpoint] = useState<EndPointInfo>(EndPoints[0]);
  const [currentResponse, setCurrentResponse] = useState<ResponseInfo>();
  const [requestInProgress, setRequestInProgress] = useState<boolean>(false);

   useEffect(() => {
    const url = `${ApiBaseUrl}${currentEndpoint?.path}`;
    setRequestInProgress(true);
    axios({
      method: currentEndpoint?.method,
      url: url,
      data: currentEndpoint?.body
    })
      .then((response) => {
        setCurrentResponse({
          statusCode: response.status,
          isSuccess: true,
          result: response.data,
        });
        setRequestInProgress(false);
      })
      .catch((error) => {
        setCurrentResponse({
          statusCode: error.response.status,
          isSuccess: false,
          result: {}
        });
        setRequestInProgress(false);
      });
  }, [currentEndpoint]);

  
  return (
    <Container>
      <br />
      <Row>
        <Col className='col-xxl-5 col-xl-5'>
          <Card style={{ width: '20rem', marginLeft: "auto", marginRight: 0 }}>
            <ListGroup variant="flush" bs-list-group-action-hover-bg = "#ede1f0;">
              {EndPoints.map((endpoint, index) => (
                <ListGroup.Item 
                      action 
                      className="d-flex justify-content-between" 
                      style={{ textTransform: "uppercase", textAlign: "right" }} 
                      key={index} 
                      onClick ={() => setCurrentEndpoint(endpoint)}>
                  <Badge className="px-1 gradient-custom" bg="secondary">{endpoint.method}</Badge>
                  {endpoint.description}
                </ListGroup.Item>))}
            </ListGroup>
          </Card>
        </Col>
        <Col className='col-xxl-7 col-xl-7'>
          <Row>
            <Col className='col-xxl-4 col-xl-5'>
              <Card style={{ width: '15rem' }}>
                <Card.Body>
                  <Card.Title>Request</Card.Title>
                  <Card.Text style={{ color: "#4ba144" }}>
                    <b>{currentEndpoint?.path}</b>
                  </Card.Text>
                </Card.Body>
              </Card>
              <br />
              <Card hidden={currentEndpoint?.body == null} style={{ width: '15rem' }} as="pre">
                <Card.Body>
                  <Card.Text>{JSON.stringify(currentEndpoint?.body, null, 2)}</Card.Text>
                </Card.Body>
              </Card>
            </Col>
            <Col className='col-xxl-8 col-xl-7'>
              <Card style={{ width: '20rem' }}>
                <Card.Body>
                  <Card.Title>Response</Card.Title>
                  <Card.Text style={{ color: currentResponse?.isSuccess ? "#4ba144" : "#d14" }}>
                    <b>{currentResponse?.statusCode}</b>
                  </Card.Text>
                </Card.Body>
              </Card>
              <br />
              <Card style={{ width: '20rem', backgroundColor:'rgb(238, 230, 244)' }} as="pre">
                <Card.Body>
                  { requestInProgress ? 
                    <Spinner animation="border" /> : 
                    <Card.Text>{JSON.stringify(currentResponse?.result, null, 2)}</Card.Text>
                  }
                </Card.Body>
              </Card>
            </Col>
          </Row>
        </Col>
      </Row>
    </Container>
  );
}

export default Reqres;