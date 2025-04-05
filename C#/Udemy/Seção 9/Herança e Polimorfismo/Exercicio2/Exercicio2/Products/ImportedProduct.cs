using System.Globalization;

namespace Exercicio2.Products;

public class ImportedProduct : Product {
    //Objetos
    public double CustomsFee { get; set; }
    
    //Construtores
    public ImportedProduct() {
    }

    public ImportedProduct(string name, double price, double customsFee) 
        : base(name, price) {
        CustomsFee = customsFee;
    }
    
    //Métodos
    public override string ToString() {
        return PriceTag();
    }

    public double TotalPrice() {
        return Price + CustomsFee;
    }

    public sealed override String PriceTag() {
        return $"{Name} - $ {TotalPrice().ToString("F2", CultureInfo.InvariantCulture)} " +
               $"(Customs fee: $ {CustomsFee.ToString("F2", CultureInfo.InvariantCulture)})";
    }
}