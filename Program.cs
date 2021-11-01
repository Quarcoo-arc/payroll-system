using System;
using System.Collections.Generic;

namespace payroll_system
{
    public class Rank : IEquatable<Rank>
    {
        public int RankId {get; set;}

        public int BasicSalary {get; set;}
    
        public override string ToString()
        {
            return "ID: " + ("R"+RankId) + "   Basic Salary: " + BasicSalary;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Rank objAsRank = obj as Rank;
            if (objAsRank == null) return false;
            else return Equals(objAsRank);
        }
        public override int GetHashCode()
        {
            return RankId;
        }
        public bool Equals(Rank other)
        {
            if (other == null) return false;
            return (this.RankId.Equals(other.RankId));
        }
        
    }
    public class Amount : IEquatable<Amount>
    {
        public Dictionary<string, int> allowances {get; set;}

        public double deductions (int BasicSalary)
        {
            double ssnit = BasicSalary * 0.03;
            double nhis = BasicSalary * 0.043;
            double vat = BasicSalary > 300 ? (BasicSalary * 0.03) : (BasicSalary * 0.075);
            
            return ssnit + nhis + vat;
        }

        public double bonuses ()
        {
            double totalBonus = 0;
            foreach (var item in allowances.Keys)
            {
                totalBonus += allowances[item];
            }
            return totalBonus;
        }

        public double amount (int BasicSalary)
        {
            var tax = deductions(BasicSalary);
            var bonus = bonuses();
            return BasicSalary + bonus - tax;
        }

        public int ID {get; set;}
        public string StaffName {get; set;}
        public double ActualSalary {get; set;}
        public int basicSalary {get; set;}

        public override string ToString()
        {
            return "ID: " + ID + "   Employee Name: " + StaffName + "   Basic Salary: " + basicSalary + "   Actual Salary: " + amount(basicSalary);
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Amount objAsAmount = obj as Amount;
            if (objAsAmount == null) return false;
            else return Equals(objAsAmount);
        }
        public override int GetHashCode()
        {
            return ID;
        }
         public bool Equals(Amount other)
        {
            if (other == null) return false;
            return (this.ID.Equals(other.ID));
        }
        
    }
    public class Employee : IEquatable<Employee>
    {
        public string EmployeeName { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeRank { get; set;}

        public override string ToString()
        {
            return "ID: " + EmployeeId + "   Name: " + EmployeeName + "   Rank: " + EmployeeRank;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Employee objAsEmployee = obj as Employee;
            if (objAsEmployee == null) return false;
            else return Equals(objAsEmployee);
        }
        public override int GetHashCode()
        {
            return EmployeeId;
        }
        public bool Equals(Employee other)
        {
            if (other == null) return false;
            return (this.EmployeeId.Equals(other.EmployeeId));
        }
    // Should also override == and != operators.
    }
    public class Program
    {
        public static void Main()
        {
            // Create a list of Employees.
            List<Employee> Employees = new List<Employee>();


            // Add Employees to the list.
            //TODO: add ranks to the Employee list & add a variable to hold last id
            Employees.Add(new Employee() { EmployeeId = 10001, EmployeeName = "Kwame Atta 01", EmployeeRank = "R1" });
            Employees.Add(new Employee() { EmployeeId = 10002, EmployeeName = "Kwame Atta 02", EmployeeRank = "R1" });
            Employees.Add(new Employee() { EmployeeId = 10003, EmployeeName = "Kwame Atta 03", EmployeeRank = "R1" });
            Employees.Add(new Employee() { EmployeeId = 10004, EmployeeName = "Kwame Atta 04", EmployeeRank = "R1" });
            Employees.Add(new Employee() { EmployeeId = 10005, EmployeeName = "Kwame Atta 05", EmployeeRank = "R1" });
            Employees.Add(new Employee() { EmployeeId = 10006, EmployeeName = "Kwame Atta 06", EmployeeRank = "R2" });
            Employees.Add(new Employee() { EmployeeId = 10007, EmployeeName = "Kwame Atta 07", EmployeeRank = "R3" });
            Employees.Add(new Employee() { EmployeeId = 10008, EmployeeName = "Kwame Atta 08", EmployeeRank = "R4" });
            Employees.Add(new Employee() { EmployeeId = 10009, EmployeeName = "Kwame Atta 09", EmployeeRank = "R1" });
            Employees.Add(new Employee() { EmployeeId = 10010, EmployeeName = "Kwame Atta 10", EmployeeRank = "R1" });
            Employees.Add(new Employee() { EmployeeId = 10011, EmployeeName = "Kwame Atta 11", EmployeeRank = "R1" });
            Employees.Add(new Employee() { EmployeeId = 10012, EmployeeName = "Kwame Atta 12", EmployeeRank = "R2" });


            // Write out the Employees in the list. This will call the overridden ToString method
            // in the Employee class.
            Console.WriteLine();
            foreach (Employee aEmployee in Employees)
            {
                Console.WriteLine(aEmployee);
            }

            //Creating a list of Ranks
            var ranks = new List<Rank>();
            
            //Add Ranks
            ranks.Add(new Rank() { RankId = 1, BasicSalary = 2100 });
            ranks.Add(new Rank() { RankId = 2, BasicSalary = 790 });
            ranks.Add(new Rank() { RankId = 3, BasicSalary = 1680 });
            ranks.Add(new Rank() { RankId = 4, BasicSalary = 810 });

            Console.WriteLine();

            //Print Ranks to Console
            Console.WriteLine("Ranks");
            foreach (Rank aRank in ranks)
            {
                Console.WriteLine(aRank);
            }


            //Create a Dictionary of Allowances
            Dictionary<string, int> bonuses = new Dictionary<string, int>(){{"Entertainment", 120}, {"Book", 112}, {"Car", 800}};
            
            //Create List of Actual Salaries
            List<Amount> ActualSalaries = new List<Amount> ();
            
            
            foreach (var Employee in Employees)  
            {
                ActualSalaries.Add(new Amount {ID = Employee.EmployeeId, StaffName = Employee.EmployeeName, basicSalary = ranks.Find(x => x.RankId.Equals(int.Parse(Employee.EmployeeRank.Substring(1)))).BasicSalary, allowances = bonuses});
            }

            Console.WriteLine();

            //Print actual amount to console
            Console.WriteLine("Actual Salaries");
            foreach (var actualSalary in ActualSalaries)
            {
                Console.WriteLine(actualSalary);
            }

            // // Check the list for Employee #1734. This calls the IEquatable.Equals method
            // // of the Employee class, which checks the EmployeeId for equality.
            // Console.WriteLine("\nContains(\"1734\"): {0}",
            // Employees.Contains(new Employee { EmployeeId = 1734, EmployeeName = "" }));

            // // Insert a new item at position 2.
            // Console.WriteLine("\nInsert(2, \"1834\")");
            // Employees.Insert(2, new Employee() { EmployeeName = "brake lever", EmployeeId = 1834 });

            // Console.WriteLine("\nEmployees[3]: {0}", Employees[3]);


            // Console.WriteLine("\nRemoveAt(3)");
            // // This will remove the Employee at index 3.
            // Employees.RemoveAt(3);

        }
    }
}
