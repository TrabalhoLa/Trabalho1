import javax.swing.JOptionPane;

public class CriptografiaSimples {
    public static void main(String[] args) {
        // Entrada da mensagem
        String mensagem = JOptionPane.showInputDialog("Digite a mensagem a ser criptografada:");

        // Conversão para vetor de caracteres
        char[] caracteres = mensagem.toCharArray();

        // Vetor para armazenar os valores ASCII
        int[] asciiValores = new int[caracteres.length];

        // Vetor para armazenar os caracteres criptografados
        char[] criptografado = new char[caracteres.length];

        // Processamento: Conversão, soma e reconversão
        for (int i = 0; i < caracteres.length; i++) {
            asciiValores[i] = (int) caracteres[i]; // Conversão para ASCII
            asciiValores[i] += 10; // Soma 10 unidades
            criptografado[i] = (char) asciiValores[i]; // Conversão de volta para caractere
        }

        // Construção da string criptografada
        String mensagemCriptografada = new String(criptografado);

        // Saída dos dados
        JOptionPane.showMessageDialog(null, "Mensagem criptografada: " + mensagemCriptografada);
    }
}
