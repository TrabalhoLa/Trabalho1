using System.Globalization;

namespace Exercicio2.Products;

public class Product {
    //Objetos
    public string Name { get; protected set; }
    public double Price { get; protected set; }
    
    //Construtores
    public Product() {
    }
    
    public Product(string name, double price) {
        Name = name;
        Price = price;
    }
    
    //Métodos
    public override string ToString() {
        return PriceTag();
    }

    public virtual String PriceTag() {
        return $"{Name} - $ {Price.ToString("F2", CultureInfo.InvariantCulture)}";
    }
}