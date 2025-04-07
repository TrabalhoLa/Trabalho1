namespace Exercicio1.Services;

public class PaypalService : OnlinePaymentService {
    //Atributos
    private const double MonthlyInterest = 0.01;
    private const double FeePercentage = 0.02;    
        
    //Métodos    
    public double PaymentFee(double amount) {
        return amount * FeePercentage;
    }

    public double Interest(double amount, int months) {
        return amount * MonthlyInterest * months;
    }

}