namespace Course;

public class Program {
    public static void Main(string[] args) {
        //Criando uma matriz e um futuro contador de negativos
        int[,] matrix;
        int negatives = 0;

        //Pedindo a ordem da matriz
        Console.Write("Digite a ordem da matriz: ");
        int index = int.Parse(Console.ReadLine());
        
        //Instanciando a matriz
        matrix = new int[index, index];

        //Preenchendo a matriz
        for (int i = 0; i < index; i++) {
            string[] values = Console.ReadLine().Split(" ");
            for (int j = 0; j < index; j++) {
                matrix[i, j] = int.Parse(values[j]);
            }
        }

        Console.WriteLine();
        Console.WriteLine("Main Diagonal: ");

        //Imprimindo a diagonal e contando os negativos
        for (int i = 0; i < index; i++) {
            for (int j = 0; j < index; j++) {
                if (i == j)
                    Console.Write(matrix[i, j] + " ");
                
                if(matrix[i, j] < 0)
                    negatives++;
            }
        }

        //Imprimindo os negativos
        Console.WriteLine();
        Console.WriteLine("Negative Numbers: " + negatives);
    }
}
