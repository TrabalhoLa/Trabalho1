using System;
using System.Text;
using System.Globalization;

namespace Exercicio3;

class Client{
    //Objetos
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime Birth { get; set; }

    //Construtores
    public String ToString(){
        StringBuilder sb = new StringBuilder();

        sb.Append(Name + " (" + Birth.ToString("dd/MM/yyyy") + ") - " + Email);

        return sb.ToString();
    }
    
    public Client(){
    }
    
    public Client(string name, string email, DateTime birth){
        Name = name;
        Email = email;
        Birth = birth;
    }
}