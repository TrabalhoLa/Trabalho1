using System.Globalization;
using Exercicio_1.Reservations;
using Exercicio_1.Reservations.Exceptions;

namespace Exercicio1;

public class Program {
    public static void Main(string[] args) {
        try
        {
            Console.Write("Room number: ");
            int roomNumber = int.Parse(Console.ReadLine());

            Console.Write("Check-In date (dd/MM/yyyy): ");
            DateTime checkInDate = DateTime.ParseExact(Console.ReadLine(), ("dd/MM/yyyy"), CultureInfo.InvariantCulture);

            Console.Write("Check-Out date (dd/MM/yyyy): ");
            DateTime checkOutDate = DateTime.ParseExact(Console.ReadLine(), ("dd/MM/yyyy"), CultureInfo.InvariantCulture);

            Reservation reservation = new Reservation(roomNumber, checkInDate, checkOutDate);

            Console.WriteLine(reservation);

            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Enter data to update the reservation: ");

            Console.Write("Check-in date (dd/MM/yyyy): ");
            checkInDate = DateTime.ParseExact(Console.ReadLine(), ("dd/MM/yyyy"), CultureInfo.InvariantCulture);

            Console.Write("Check-out date (dd/MM/yyyy): ");
            checkOutDate = DateTime.ParseExact(Console.ReadLine(), ("dd/MM/yyyy"), CultureInfo.InvariantCulture);

            reservation.UpdateDates(checkInDate, checkOutDate);

            Console.WriteLine(reservation);
        }

        catch (DomainException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (FormatException e) {
            Console.WriteLine("Input string was not in a correct format.");
        }
    }
}