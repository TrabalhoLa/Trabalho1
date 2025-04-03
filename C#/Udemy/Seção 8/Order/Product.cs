using System;
using System.Globalization;
using System.Text;

namespace Exercicio3;

class Product{
    //Objetos
    public string Name { get; set; }
    public double Price { get; set; }

    //Métodos
    public String ToString(){
        StringBuilder sb = new StringBuilder();

        sb.Append(Name + ", $" + 
                      Price.ToString("F2", CultureInfo.InvariantCulture)
        );

        return sb.ToString();
    }

    public Product() {
    }

    public Product(string name, double price) {
        Name = name;
        Price = price;
    }
}