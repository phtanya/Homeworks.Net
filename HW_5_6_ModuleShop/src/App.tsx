import React from "react";
import { Routes, Route } from "react-router-dom";
import { Container } from "react-bootstrap";
import { Home } from "./pages/Home";
import { Store } from "./pages/Store";
import { About } from "./pages/About";
import { Navbar } from "./components/Navbar";
import { ShoppingCartProvider } from "./context/ShoppingCartContex";
import { ItemPage } from "./pages/ItemPage";
import Register from "./pages/Register";
import { Login } from "./pages/Login";
import Footer from "./components/Footer";

function App() {
  return (
    <ShoppingCartProvider>
      <Navbar />
      <Container className="mb-4">
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/store" element={<Store />} />
          <Route path="/itemPage" element={<ItemPage />} />
          <Route path="/about" element={<About />} />
          <Route path="/register" element={<Register />} />
          <Route path="/login" element={<Login />} />
        </Routes>
      </Container>
      <div className="fixed-bottom p-3 text-white bg-dark">
        <Footer />
      </div>
    </ShoppingCartProvider>
  );
}

export default App;
