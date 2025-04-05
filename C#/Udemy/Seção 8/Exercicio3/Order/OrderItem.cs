using System;
using System.Globalization;
using System.Text;

namespace Exercicio3;

class OrderItem{
    //Objetos
    public int Quantity { get; set; }
    public double Price { get; set; }
    public Product Product { get; set; }

    //Construtores
    public String ToString(){
        StringBuilder sb = new StringBuilder();

        sb.Append(Product.ToString() + 
                      ", Quantity: " + Quantity +
                      ", Subtotal: $" + subTotal().ToString("F2", CultureInfo.InvariantCulture)
        );

        return sb.ToString();
    }

    public OrderItem(){
    }

    public OrderItem(int quantity, double price, Product product){
        Quantity = quantity;
        Price = price;
        Product = product;
    }

    //Métodos
    public double subTotal(){
        return Price * Quantity;
    }
}