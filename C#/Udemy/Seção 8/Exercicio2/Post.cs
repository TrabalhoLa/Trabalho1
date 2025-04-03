using System;
using System.Text;

namespace Exercicio2;
class Post{
    //Propriedades
    public DateTime Moment { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int Likes { get; set; }
    public List<Comment> Comments { get; set; } = new List<Comment>();

    //Construtores
    public Post(){
    }

    public Post(DateTime moment, string title, string content, int likes){
        Moment = moment;
        Title = title;
        Content = content;
        Likes = likes;
    }

    //Métodos
    public override string ToString(){
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(Title);
        sb.AppendLine(Likes + " Likes - " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
        sb.AppendLine(Content);

        sb.AppendLine("Comments:");

        if(Comments.Count == 0){
            sb.AppendLine("No comments yet.");
        }

        else{
            foreach (Comment comment in Comments){
                sb.AppendLine(comment.ToString());
            }
        }
        
        return sb.ToString();
    }

    public void AddComment(Comment comment){
        Comments.Add(comment);
    }

    public void RemoveComment(Comment comment){
        Comments.Remove(comment);
    }

}