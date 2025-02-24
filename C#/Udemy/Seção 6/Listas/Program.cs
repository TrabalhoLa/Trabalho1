using System.Globalization;

namespace Course;

public class Program {
    public static void Main(string[] args) {
        //Lista de Employees e um vetor de Employees
        List<Employees> employees = new List<Employees>();
        
        Console.Write("How many employees will be registered? ");
        int quantity = int.Parse(Console.ReadLine());
        
        Nullable<int> aux = 1;

        for (int i = 0; i < quantity; i++) {
            Console.WriteLine();
            Console.WriteLine("Employee #:" + aux);

            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            // Verifica se o Id já existe
            while (employees.Exists(e => e.Id == id)) {
                Console.Write("This ID already exists. Enter another Id: ");
                id = int.Parse(Console.ReadLine());
            }
            
            Console.Write("Name: ");
            string name = Console.ReadLine();
            
            Console.Write("Salary: ");
            double salary = double.Parse(Console.ReadLine().ToString(CultureInfo.InvariantCulture));
            
            //Adicionando o Employee à lista
            employees.Add(new Employees(id, name, salary));
            
            aux++;
        }

        //Perguntando qual funcionario aumentar o Salary
        Console.WriteLine();
        Console.Write("Enter the employee id that will have salary increased: ");
        int employeeId = int.Parse(Console.ReadLine());

        // Verifica se o Id fornecido existe
        Employees emp = employees.Find(e => e.Id == employeeId);

        //Caso o Id exista, aumenta a porcentagem do Salary
        if (emp != null) {
            Console.Write("Enter the percentage: ");
            double percentage = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            emp.increaseSalary(percentage);
        } else {
            Console.WriteLine("This id does not exist!");
        }

        Console.WriteLine();
        Console.WriteLine("Updated list of employees: ");

        foreach (Employees e in employees) {
            //Imprime a nova lista de Employees com salários atualizados
            Console.WriteLine(e);
        }
    }
}