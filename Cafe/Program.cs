using System;
using System.Collections;
using System.Collections.Generic;

Cafe cafe = new Cafe(5);
cafe.AddEmployee(new Barista("Alice"));
cafe.AddEmployee(new Chef("Bob"));
cafe.AddEmployee(new Waiter("Charlie"));

foreach (Employee employee in cafe)
{
    employee.Description();
}

public abstract class Employee
{
    public string Name { get; set; }

    public Employee(string name)
    {
        Name = name;
    }

    public abstract void Description();
}

public class Barista : Employee
{
    public Barista(string name) : base(name) { }

    public override void Description()
    {
        Console.WriteLine($"This is barista {Name}");
    }
}

public class Chef : Employee
{
    public Chef(string name) : base(name) { }

    public override void Description()
    {
        Console.WriteLine($"This is chef {Name}");
    }
}

public class Waiter : Employee
{
    public Waiter(string name) : base(name) { }

    public override void Description()
    {
        Console.WriteLine($"This is waiter {Name}");
    }
}

public class Cafe : IEnumerable<Employee>
{
    private Employee[] employees;
    private int curPos = 0;

    public Cafe(int len)
    {
        employees = new Employee[len];
    }

    public void AddEmployee(Employee employee)
    {
        if (curPos < employees.Length)
        {
            employees[curPos] = employee;
            curPos++;
        }
        else
        {
            Console.WriteLine("Cafe is full!");
        }
    }

    public IEnumerator<Employee> GetEnumerator()
    {
        for (int i = 0; i < curPos; i++)
        {
            yield return employees[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
