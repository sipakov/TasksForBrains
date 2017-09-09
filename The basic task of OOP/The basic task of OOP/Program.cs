using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace The_basic_task_of_OOP
{   
        [Serializable]
        abstract class Employee // This abstract class is simple. I did not create the interfaces . SRP SOLID principle works.
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public Employee(string name, int id)
            {
                this.Name = name;
                this.Id = id;
            }
            public abstract double Salary { get; set; }
            public abstract double GetSalary();
            public override string ToString()
            {
                return "Имя: " + Name + "; Id: " + Id + "; Зарплата: " + Salary + ";";
            }

        }
    [Serializable]
    sealed class BadEmployee : Employee //I used abstraction in this example and LSP SOLID principle is not appropriate. Barbara Liscov is happy.
    {
        public double Stavka { get; private set; }
        public override double Salary { get; set; }
        public BadEmployee(string name, int id, double stavka) : base(name, id)
        {
            this.Stavka = stavka;
            this.Salary = GetSalary();
        }
        public override double GetSalary()
        {
            return this.Stavka * 20.8 * 8;
        }
    }
            [Serializable]
            sealed class GoodEmployee : Employee
            {
                public override double Salary { get; set; }
                public GoodEmployee(string name, int id, double salary) : base(name, id)
                {
                    this.Salary = salary;
                }
                public override double GetSalary()
                {
                    return this.Salary;
                }
            }
            class Employees
            {
                private object tl = new object();
                private List<Employee> empList { get; set; }
                public Employees()
                {
                    empList = new List<Employee>();
                }
                public void AddEmployee(Employee employee)
                {
                    empList.Add(employee);
                }
                private IOrderedEnumerable<Employee> A;
                public IOrderedEnumerable<Employee> OrderByA()
                {
                    Console.WriteLine("Задание А.");
                    A = empList.OrderByDescending(x => x.Salary).ThenBy(x => x.Name);
                    foreach (var item in A)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    return A;
                }
                public void TakeB(int x) // Easy implementation of the OCP SOLID principle
                {
                    Console.WriteLine("Задание Б.");

                    foreach (var item in A.Take(x))
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
                internal void Last3Id(int x)
                {
                    Console.WriteLine("Задание В.");
                    foreach (var item in A.Skip(A.Count() - x).Take(x))
                    {
                        Console.WriteLine("Id: {0};", item.Id);
                    }
                }
                public void SerializeToBinery(string fileName)
                {
                    Console.WriteLine("Задание Г.");
                    BinaryFormatter bf = new BinaryFormatter();
                    using (Stream sw = new FileStream(fileName, FileMode.OpenOrCreate))
                    {
                        bf.Serialize(sw, empList);
                    }
                    Console.WriteLine("Информация сериализована");
                }
                public void DeserializeFromBinery(string fileName)
                {
                    Console.WriteLine("Задание Д.");
                    BinaryFormatter bf = new BinaryFormatter();
                    try
                    {
                        using (Stream sr = new FileStream(fileName, FileMode.Open))
                        {

                            foreach (var item in bf.Deserialize(sr) as List<Employee>)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            Console.WriteLine("Информация десериализована");
                        }
                    }
                    catch (Exception e) { Console.WriteLine(e.Message); }
                }            
                }
            class Program
            {
                static void Main(string[] args)
                {
                    Employees emp = new Employees();

                    var Ivanov = new BadEmployee("Иван", 1, 200);
                    var Petrov = new BadEmployee("Петр", 2, 170);
                    var Tsarev = new BadEmployee("Василий", 3, 200);
                    var Sidorova = new GoodEmployee("Аня", 4, 70000);
                    var Kunko = new GoodEmployee("Галя", 5, 65000);
                    var Medvedeva = new BadEmployee("Олеся", 6, 210);
                    emp.AddEmployee(Ivanov);
                    emp.AddEmployee(Petrov);
                    emp.AddEmployee(Tsarev);
                    emp.AddEmployee(Sidorova);
                    emp.AddEmployee(Kunko);
                    emp.AddEmployee(Medvedeva);

                    emp.OrderByA();                                 
                    emp.TakeB(5);
                    emp.Last3Id(3);
                    emp.SerializeToBinery(@"D:\19.dat");
                    emp.DeserializeFromBinery(@"D:\19.dat");
                    Console.WriteLine("Задание Д. Некорректный формат ввода организован");

                    Console.ReadLine();
                }
            }
        }
    
