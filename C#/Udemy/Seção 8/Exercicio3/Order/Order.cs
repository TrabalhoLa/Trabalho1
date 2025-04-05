using System;
using System.Text;
using System.Globalization;

namespace Exercicio3;

class Order{
    //Objetos
    public DateTime Moment { get; set; }
    public OrderStatus Status { get; set; }
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    public Client Client { get; set; }

    //Construtores
    public Order(){
    }

    public Order(DateTime moment, OrderStatus status, Client client){
        Moment = moment;
        Status = status;
        Client = client;
    }

    //Métodos
    public String ToString (){
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Order Moment: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
        sb.AppendLine("Order Status: " + Status);

        sb.AppendLine("Client: " + Client.ToString());

        sb.AppendLine("Order items: ");

        foreach(OrderItem item in Items){
            sb.AppendLine(item.ToString());
        }

        sb.AppendLine("Total price: $" + total().ToString("F2", CultureInfo.InvariantCulture));

        return sb.ToString();
    }

    public void addItem(OrderItem item){
        Items.Add(item);
    }

    public void removeItem(OrderItem item){
        Items.Remove(item);
    }

    public double total(){
        double sum = 0;

        foreach(OrderItem item in Items){
            sum += item.subTotal();
        }

        return sum;
    }
}