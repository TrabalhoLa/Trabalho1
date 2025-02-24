namespace Course;

public class Program {
    public static void Main(string[] args) {
        Console.Write("Digite a quantidade de linhas e colunas da matriz: ");
        string[] aux = Console.ReadLine().Split(" ");
        int linha = int.Parse(aux[0]);
        int coluna = int.Parse(aux[1]);
        
        //Declarando aux como null para usar em outras partes do código sem ter que criar outra variável auxiliar
        int[,] matrix = new int[linha, coluna];
        aux = null;

        //Preenchendo a matriz
        for (int i = 0; i < linha; i++) {
            aux = Console.ReadLine().Split(" ");
            for (int j = 0; j < coluna; j++){
                matrix[i, j] = int.Parse(aux[j]);
            }
        }
        
        //Pedindo um número existente
        Console.WriteLine();
        Console.Write("Escolha um número existente na matriz: ");
        int escolha = int.Parse(Console.ReadLine());

        for (int i = 0; i < linha; i++) {
            Console.WriteLine();
            for (int j = 0; j < coluna; j++) {
                //Caso encontre o elemento, imprime a posição dele atual
                if (matrix[i, j] == escolha) {
                    Console.WriteLine("Position " + i + ", " + j + ": ");
                    
                    //Verificações para ver se tem vizinhos neste elemento da matriz
                    if(j > 0)
                        Console.WriteLine("Left: " + matrix[i, j - 1]);
                
                    if(i > 0)
                        Console.WriteLine("Up: " + matrix[i - 1, j]);
                
                    if(j < coluna - 1)
                        Console.WriteLine("Right: " + matrix[i, j + 1]);
                
                    if (i < linha - 1)
                        Console.WriteLine("Down: " + matrix[i + 1, j]);
                }
            }
        }
    }
}
