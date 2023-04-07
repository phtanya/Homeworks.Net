import React, { useEffect, useState } from "react";
import { Button, Form } from "react-bootstrap";

type User = {
  email: string;
  password: string;
};

export function Login() {
  const [users, setUsers] = useState<User[]>([]);
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  useEffect(() => {
    const fetchUsers = async () => {
      const response = await fetch("../data/users.json");
      const data = await response.json();
      setUsers(data);
    };
    fetchUsers();
  }, []);

  const handleLogin = () => {
    const foundUser = users.find(
      (user) => user.email === email && user.password === password
    );
    if (foundUser) {
      console.log("Logged in!");
    } else {
      console.log("Invalid email or password.");
    }
  };

  return (
    <div className="d-flex justify-content-center align-items-center vh-100">
      <Form onSubmit={(e) => e.preventDefault()}>
        <Form.Group controlId="formBasicEmail">
          <h1>Login</h1>
          <Form.Label>Email address</Form.Label>
          <Form.Control
            type="email"
            placeholder="Enter email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </Form.Group>

        <Form.Group controlId="formBasicPassword">
          <Form.Label>Password</Form.Label>
          <Form.Control
            type="password"
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </Form.Group>
        <Button variant="primary" type="submit" onClick={handleLogin}>
          Submit
        </Button>
      </Form>
    </div>
  );
}
