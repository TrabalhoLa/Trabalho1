using System.Globalization;

namespace Course;

public class Program {
    public static void Main(string[] args) {
        //Vetor de Rooms
        Rooms[] room;
        
        Console.Write("How many rooms will be rented? ");
        int rooms = int.Parse(Console.ReadLine());

        //Instanciando o vetor de Rooms com a quantidade pedida
        room = new Rooms[rooms];
        
        //Objeto Nullable para poder usar durante o resto do código
        Nullable<int> aux = 1;

        for (int i = 0; i < rooms; i++) {
            Console.WriteLine();
            Console.WriteLine("Rent #:" + aux);

            //Instanciando cada posição do vetor de Rooms
            room[i] = new Rooms();

            Console.Write("Name: ");
            room[i].Name = Console.ReadLine();
            
            Console.Write("Email: ");
            room[i].Email = Console.ReadLine();
            
            Console.Write("Room: ");
            room[i].Room = int.Parse(Console.ReadLine());

            //Se por algum motivo conseguir não ocupar algum quarto, ele declara aux como null, para uma parte futura do código
            if (i == rooms - 1)
                aux = null;

            else
                aux++;
        }

        Console.WriteLine("Busy Rooms: ");

        //For each de para passar por cada Room
        foreach (Rooms busyRooms in room) {
            for (int i = 0; i < rooms; i++) {
                //Comparando se a room atual do foreach está ocupada com alguma do vetor utilizando .Equals por ser string
                if (busyRooms.Room.Equals(room[i].Room)) {
                    Console.WriteLine(room[i].Room + ": " + room[i].Name + ", " + room[i].Email);
                    aux++;
                }
            }
            
            //Se por algum motivo não tiver alguma sala ocupada, o programa avisa
            if(aux == 0)
                Console.WriteLine("No busy rooms!");
        }
    }
}