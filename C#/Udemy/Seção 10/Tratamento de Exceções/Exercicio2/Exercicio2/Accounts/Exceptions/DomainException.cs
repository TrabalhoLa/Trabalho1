namespace Exercicio2.Accounts.Exceptions;

public class DomainException : ApplicationException{
    public DomainException(string message) : base(message){}
}