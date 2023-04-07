import React from "react";
import { Button, Col, Row } from "react-bootstrap";
import { useShoppingCart } from "../context/ShoppingCartContex";
import { getId } from "../components/StoreItem";
import storeItems from "../data/items.json";

export function ItemPage() {
  const item = storeItems.find((i) => i.id === getId);
  const {
    getItemQuantity,
    increaseCartQuantity,
    decreaseCartQuantity,
    removeFromCart,
  } = useShoppingCart();
  const quantity = getItemQuantity(getId);
  return (
    <>
      <Row>
        <Col>
          <img
            src={item?.imgUrl}
            height="500px"
            style={{ objectFit: "cover" }}
          />
        </Col>
        <Col>
          <Row>
            <h1>{item?.name}</h1>
          </Row>
          <Row>
            <h3>Price:</h3>
            <div className="fs-1 text-muted">{item?.price}$</div>
          </Row>
          <Row>
            <div className="mt-auto">
              {quantity === 0 ? (
                <Button
                  className="w-100"
                  onClick={() => increaseCartQuantity(getId)}
                >
                  Add to cart
                </Button>
              ) : (
                <div
                  className="d-flex align-items-center flex-column"
                  style={{ gap: ".5rem" }}
                >
                  <div
                    className="d-flex align-items-center justify-content-center"
                    style={{ gap: ".5rem" }}
                  >
                    <Button onClick={() => decreaseCartQuantity(getId)}>
                      -
                    </Button>
                    <div>
                      <span className="fs-3">{quantity}</span> in cart
                    </div>
                    <Button onClick={() => increaseCartQuantity(getId)}>
                      +
                    </Button>
                  </div>
                  <Button
                    variant="danger"
                    size="sm"
                    onClick={() => removeFromCart(getId)}
                  >
                    Remove
                  </Button>
                </div>
              )}
            </div>
          </Row>
          <Row>
            <div>Info:</div>
            <div>{item?.info}</div>
          </Row>
        </Col>
      </Row>
    </>
  );
}
