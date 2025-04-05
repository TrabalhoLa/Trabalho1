using System.Globalization;
using Exercicio2.Accounts.Exceptions;

namespace Exercicio2.Accounts;

public class Account {
    //Atributos
    public int Number { get; set; }
    public String Holder { get; set; }
    public double Balance { get; set; }
    public double WithdrawLimit { get; set; }
    
    //Construtores
    public Account(int number, String holder, double balance, double withdrawLimit) {
        Number = number;
        Holder = holder;
        Balance = balance;
        WithdrawLimit = withdrawLimit;
    }
    
    //Métodos
    public void Deposit(double amount) {
        Balance += amount;
    }

    public void Withdraw(double amount) {
        if (WithdrawLimit < amount) {
            throw new DomainException("Withdraw error: The amount exceeds withdraw limit");
        }

        if (Balance < amount) {
            throw new DomainException("Withdraw error: Not enough balance");
        }
        
        Balance -= amount;
    }
}