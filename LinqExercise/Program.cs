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
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            var sum = numbers.Sum();
            Console.WriteLine($"Sum:{sum}");

            var average = numbers.Average();
            Console.WriteLine($"Averag: {average}");
            Console.WriteLine("----------------------------");
            //Order numbers in ascending order and decsending order. Print each to console.
            var ascending = numbers.OrderBy( x => x);            
            foreach (var x in ascending)
            {
                Console.WriteLine($"Ascending order: {x}");
            }
            Console.WriteLine("-----------------------------");

            var descending = numbers.OrderByDescending(x => x);            
            foreach (var x in descending)
            {
                Console.WriteLine($"Descending order: {x}");
            }

            Console.WriteLine("------------------------------");

            //Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(x => x > 6);
            foreach (var x in greaterThanSix)
            {
                Console.WriteLine($"The numbers grater than six: {x}");
            }
            Console.WriteLine("------------------------------");
            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            
            foreach (var x in descending.Take(4)) 
            {
                Console.WriteLine($"Last four {x}");
            }
            Console.WriteLine("-------------------------------");

            //Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("My age at index [4]");
            numbers[4] = 47;
            foreach (var number in numbers.OrderByDescending(x => x))
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("--------------------------------");
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            Console.WriteLine("C or S Employees Sorted");

            var sortEmployees = employees.Where(person => person.FirstName.StartsWith("C") || person.FirstName.StartsWith("S")).OrderBy(person => person.FirstName);

            foreach (var staff in sortEmployees) 
            {
                Console.WriteLine(staff.FullName);
            }

            Console.WriteLine("--------------------------------");

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Fullname and Over 26");

            var fullNameOver26 = employees.Where(person => person.Age > 26).OrderBy(person => person.Age).ThenBy(person => person.FirstName);

            foreach (var staff in fullNameOver26) 
            {
                Console.WriteLine($"Age: {staff.Age}          Fullname: {staff.FullName}");
            }

            Console.WriteLine("--------------------------------");
            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            Console.WriteLine("Sum and Average of YOE.");

            var experience = employees.Where(person => person.YearsOfExperience <= 10 && person.Age > 35);

            var sumOfExperience = experience.Sum(experience => experience.YearsOfExperience);

            var averageOfExperience = experience.Average(experience => experience.YearsOfExperience);
            Console.WriteLine($"Sum: {sumOfExperience}        Average: {averageOfExperience}");

            Console.WriteLine("--------------------------------");

            //Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("Add Employee.");

            employees = employees.Append(new Employee("first", "lastname", 47, 1)).ToList();

                   
            Console.WriteLine();

            Console.ReadLine();
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
