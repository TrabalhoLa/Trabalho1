namespace Course;

public class Aluno{
    public string nome;
    public double[] nota = new double[3];

    public double NotaFinal() {
        return nota[0] + nota[1] + nota[2];
    }
    
    public bool Aprovado() {
        if (NotaFinal() >= 60)
            return true;

        else
            return false;
    }

    public double NotaRestante() {
        return 60.00 - NotaFinal();
    }
}