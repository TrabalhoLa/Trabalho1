namespace Exercicio_1.Reservations.Exceptions;

public class DomainException : ApplicationException{
    public DomainException(string message) : base(message) { }
}