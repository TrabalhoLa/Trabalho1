using System.Globalization;
using Exercicio_1.Reservations.Exceptions;

namespace Exercicio_1.Reservations;

public class Reservation {
    //Atributos
    public int RoomNumber { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    
    //Construtores
    public Reservation() {
    }
    
    public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut) {
        if (checkIn < DateTime.Now || checkOut < DateTime.Now) 
            throw new DomainException("Error in reservation: Reservation dates must be future dates");
        
        if (checkOut <= checkIn)
            throw new DomainException("Error in reservation: Check-out date must be after check-in date");
        
        RoomNumber = roomNumber;
        CheckIn = checkIn;
        CheckOut = checkOut;
    }
    
    //Métodos
    public override string ToString() {
        return $"Reservation: Room {RoomNumber}, " +
               $"Check-In: {CheckIn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}, " +
               $"Check-Out: {CheckOut.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}, " +
               $"{Duration()} nights";
    }

    public int Duration() {
        TimeSpan duration = CheckOut.Subtract(CheckIn);
        
        return (int)duration.TotalDays;
    }

    public void UpdateDates(DateTime checkIn, DateTime checkOut) {
        DateTime now = DateTime.Now;

        if (checkIn < now || checkOut < now) 
            throw new DomainException("Error in reservation: Reservation dates for update must be future dates");
        
        if (checkOut <= checkIn)
            throw new DomainException("Error in reservation: Check-out date must be after check-in date");
        
        CheckIn = checkIn;
        CheckOut = checkOut;
    }
}