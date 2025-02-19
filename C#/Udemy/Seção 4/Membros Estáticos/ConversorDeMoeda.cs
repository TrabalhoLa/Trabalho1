namespace Course;

public class ConversorDeMoeda {
    public static double Total(double cotacao, double valor){
        return (cotacao * valor) + ((cotacao * valor) * 0.06);
    }
}