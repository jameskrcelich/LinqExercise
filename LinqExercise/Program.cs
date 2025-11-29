using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /* Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine($"Sum of numbers = {numbers.Sum()}");

            //TODO: Print the Average of numbers
            Console.WriteLine($"Average of numbers = {numbers.Average()}");

            //TODO: Order numbers in ascending order and print to the console
            var orderedNumbers = numbers.OrderBy(x => x);
            foreach (var number in orderedNumbers)
            {
                Console.Write(number);
            }

            //TODO: Order numbers in descending order and print to the console
            Console.WriteLine();
            orderedNumbers = numbers.OrderByDescending(x => x);
            foreach (var number in orderedNumbers)
            {
                Console.Write(number);
            }

            //TODO: Print to the console only the numbers greater than 6
            var greaterThanSix = from num in numbers
                where num > 6
                select num;

            Console.WriteLine("\nNumbers greater than 6 (Query Syntax):");
            foreach (var number in greaterThanSix)
            {
                Console.Write(number);
            }

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            IEnumerable<int> firstFourNumbers = numbers.Take(4);

            Console.WriteLine("\nFirst four numbers: ");
            foreach (int number in firstFourNumbers)
            {
                Console.Write(number);
            }

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            numbers[4] = 29;
            var sortedRemainingElements = numbers.Skip(4).OrderByDescending(n => n);
            Console.WriteLine("\nNumbers in descending order starting at index 4 (Query Syntax):");
            foreach (var number in sortedRemainingElements)
            {
                Console.Write(number);
            }

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var filtered = employees.Where(e => e.FirstName.StartsWith('C') || e.FirstName.StartsWith('S'));
            filtered.OrderBy(e => e.FirstName);
            Console.WriteLine("First names beginning with 'C' or 'S':");
            foreach(var employee in filtered)
            {
                Console.WriteLine(employee.FirstName);
            }

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            filtered = employees.Where(e => e.Age > 26).OrderBy(e => e.Age).ThenBy(e => e.FirstName);
            Console.WriteLine("Employees older than 26");
            Console.WriteLine("=======================");
            foreach(var employee in filtered)
            {
                Console.WriteLine($"Employee full name: {employee.FullName} Age: {employee.Age} YOE: {employee.YearsOfExperience}");
            }
           
            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            filtered = employees.Where(e => e.YearsOfExperience <= 10 && e.Age > 35).OrderBy(e => e.Age).ThenBy(e => e.FirstName);
            
            var sumYOEexp = filtered.Sum(e => e.YearsOfExperience);
            Console.WriteLine($"\nFiltered Sum YOE <= 10 and Age > 35 = {sumYOEexp}");
           
            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var avgYOEexp = filtered.Average(e => e.YearsOfExperience);
            Console.WriteLine($"Filtered Avg YOE <= 10 and Age > 35 = {Math.Round(avgYOEexp,2)}");
            
            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Nuno", "Bettencourt", 58, 16)).ToList();
            Console.WriteLine("\nEmployees list with our new employee Nuno Bettencourt");
            Console.WriteLine("=====================================================");
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FullName}, {employee.Age}, {employee.YearsOfExperience}");
            }
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
