using System;

namespace Exercicio2;
class Program{
    static void Main(string[] args){
        Comment comment = new Comment("Have a nice trip!");
        Comment comment2 = new Comment("Wow that's awesome!");

        Post post = new Post(DateTime.Now, 
                            "Traveling to New Zealand", 
                            "I'm going to visit this wonderful country!", 
                            12
        );
        post.AddComment(comment);
        post.AddComment(comment2);

        Console.WriteLine(post.ToString());
        Console.WriteLine("-------------------------------------------------");

        post.RemoveComment(comment2);
        post.RemoveComment(comment);

        Console.WriteLine(post.ToString());
        Console.WriteLine("-------------------------------------------------");
    }
}