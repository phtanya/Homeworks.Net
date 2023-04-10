import React from "react";
import storeItems from "../data/items.json";
import { Button, Offcanvas, Stack } from "react-bootstrap";
import { useShoppingCart } from "../context/ShoppingCartContex";
import { CartItem } from "./CartItem";
import { Link } from "react-router-dom";

type ShoppingCartProps = {
  isOpen: boolean;
};
export function ShoppingCart({ isOpen }: ShoppingCartProps) {
  const { closeCart, cartItems, cartQuantity } = useShoppingCart();
  return (
    <Offcanvas show={isOpen} onHide={closeCart} placement="end">
      <Offcanvas.Header closeButton>
        <Offcanvas.Title>Cart</Offcanvas.Title>
      </Offcanvas.Header>
      <Offcanvas.Body>
        <Stack gap={3}>
          {cartItems.map((item) => (
            <CartItem key={item.id} {...item} />
          ))}
          <div className="ms-auto fw-bold fs-5">
            Total{" "}
            {cartItems.reduce((total, cartItem) => {
              const item = storeItems.find((i) => i.id === cartItem.id);
              return total + (item?.price || 0) * cartItem.quantity;
            }, 0)}{" "}
            USD
          </div>
        </Stack>
        {cartQuantity > 0 && (
          <Button>
            <Link to="/login" style={{ color: "white" }}>
              Buy
            </Link>
          </Button>
        )}
      </Offcanvas.Body>
    </Offcanvas>
  );
}
