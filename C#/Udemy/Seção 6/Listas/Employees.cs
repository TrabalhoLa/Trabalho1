using System.Globalization;

namespace Course;

public class Employees {
    public int Id { get; private set; }
    public string Name { get; private set; }
    public double Salary { get; private set; }

    public Employees(int id, string name, double salary) {
        Id = id;
        Name = name;
        Salary = salary;
    }

    public override string ToString() {
        return Id + ", " 
             + Name + ", " 
             + Salary.ToString("F2", CultureInfo.InvariantCulture);
    }
    
    //Método para aumentar o salário do Employee
    public double increaseSalary(double percentage) {
        return Salary += Salary * (percentage / 100.0);
    }
}