using System;

namespace Exercicio2;

class Comment{
    //Propriedades
    public string Text { get; set; }

    //Construtores
    public Comment(){
    }

    public Comment(String text){
        Text = text;
    }

    //Métodos
    public override string ToString(){
        return Text;
    }
}