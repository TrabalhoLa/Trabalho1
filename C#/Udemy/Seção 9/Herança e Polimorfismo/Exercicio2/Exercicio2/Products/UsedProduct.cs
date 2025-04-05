using System.Globalization;

namespace Exercicio2.Products;

public class UsedProduct : Product {
    //Objetos
    public DateTime ManufactureDate {get; set;}
    
    //Construtores
    public UsedProduct() {
    }

    public UsedProduct(string name, double price, DateTime manufactureDate) 
        : base(name, price) {
        ManufactureDate = manufactureDate;
    }
    
    //Métodos
    public override String ToString() {
        return PriceTag();
    }

    public override String PriceTag(){
        return $"{Name} (used) - $ {Price.ToString("F2", CultureInfo.InvariantCulture)} " +
               $"(Manufacture date: {ManufactureDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)})";
    }
}