namespace Exercicio1.Services;

public interface OnlinePaymentService {
    public double PaymentFee(double amount);
    public double Interest(double amount, int months);
}