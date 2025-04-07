using Exercicio1.Entities;

namespace Exercicio1.Services;

public class ContractService {
    //Atributos
    public OnlinePaymentService _onlinePaymentService;
    
    //Construtores
    public ContractService() {
    }

    public ContractService(OnlinePaymentService onlinePaymentService) {
        _onlinePaymentService = onlinePaymentService;
    }
    
    //Métodos
    public void ProcessContract(Contract contract, int months) {
        //Parcela básica
        double basicQuota = contract.TotalValue / months;

        for (int i = 1; i <= months; i++) {
            //Somando de mês em mês
            DateTime date = contract.Date.AddMonths(i);
            double updatedQuota = basicQuota + _onlinePaymentService.Interest(basicQuota, i);
            
            //Somando ao valor total 
            double totalQuota = updatedQuota + _onlinePaymentService.PaymentFee(updatedQuota);
            
            //Adicionando à lista de parcelas
            contract.Installments.Add(new Installment(date, totalQuota));
        }
    }
}