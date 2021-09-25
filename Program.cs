using System;
using System.Collections.Generic;

namespace Part1_Mod6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task_6_2_2();
            //Task_6_3();
            //Task_6_3_1();
            //Task_6_3_2();
            //Task_6_5_2();
            //Task_6_6_1();
            //Task_6_6_2();
            Task_6_6_5();


            Console.WriteLine("-- End --");
        }

        private static void Task_6_6_5()
        {
            throw new NotImplementedException();
        }

        class Triangle_6_6_5
        {
            private double side1, side2, side3;
            public double Side1
            {
                get
                {
                    return side1;
                }
                set
                {
                    if(value > 0)       // Ввел проверку на длину для 3й стороны. Не вижу, как можно ввести такую проверку для каждой из сторон:
                                        // если мы вводим первую сторону, а длины длины второй и третьей пока не заданы (т.е., равны нулю), проверка не будет работать
                    {
                        side1 = value;
                    }
                }
            }
            public double Side2
            {
                get
                {
                    return side2;
                }
                set
                {
                    if (value > 0)
                    {
                        side2 = value;
                    }
                }
            }
            public double Side3
            {
                get
                {
                    return side3;
                }
                set
                {
                    if (value > 0 && value < side1 + side2)
                    {
                        side3 = value;
                    }
                }
            }
        }
        #region Task_6_6_5

        #endregion Task_6_6_5

        #region Task_6_6_2
        private static void Task_6_6_2()    //Добавьте в класс User из примера выше свойства для логина и почты:
                                            //Поле логина должно быть не менее 3 символов длиной.
                                            //Поле почты должно содержать знак @.
        {
            User u = new User();
            Console.Write("enter email: ");
            u.Email = Console.ReadLine();
            Console.WriteLine(u.Email);
        }

        class User
        {
            private int age;
            public int Age 
            {
                get
                {
                    return age;
                }
                set
                {
                    if (Age > 18)
                    {
                        age = value;
                    }
                    else
                    {
                        Console.WriteLine("Age should be greater than 18");
                    }
                } 
            }
            private string login;
            public string Login
            {
                get
                {
                    return login;
                }
                set
                {
                    if(value.Length < 3)
                    {
                        login = value;
                    }
                    else
                    {
                        Console.WriteLine("Login must contain more than 2 chars");
                    }
                }
            }
            private string email;
            public string Email
            {
                get
                {
                    return email;
                }
                set
                {
                    var em = new System.ComponentModel.DataAnnotations.EmailAddressAttribute();
                    if (em.IsValid(value))
                    {
                        email = value;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect email entered");
                    }
                }
            }
        }


        #endregion Task_6_6_2

        #region Task_6_6_1
        private static void Task_6_6_1()   //Напишите класс светофор (TrafficLight) с 2 методами:
                                           //Закрытый метод ChangeColor, принимающий 1 строковый параметр color.
                                           //Открытый метод GetColor, который не принимает параметры, но выдает строковое значение цвета.
                                           //Методы реализовывать не нужно.
        {
            Console.WriteLine("Task_6_1_1: see the class code below this method"); //see the class below
        }

        class TrafficLight
        {
            private void ChangeColor(string color)
            {

            }
            public string GetColor()
            {
                return "some color";
            }
        }
        #endregion Task_6_6_1

        #region Task_6_5_2
        private static void Task_6_5_2()
        {
            Circle c = new Circle(new Point("1", "1"), 1);
            c.Show();
            Triangle t = new Triangle(new Point("1", "1"), new Point("3", "1"), new Point("2", "3"));
            t.Show();
            Square s = new Square(new Point("1", "1"), new Point("2", "2"));
            s.Show();

        }

        class Point
        {
            internal double x, y;
            public Point(string x, string y)
            {
                bool correctInput = Double.TryParse(x, out this.x);
                correctInput = Double.TryParse(y, out this.y);
                if (!correctInput)
                {
                    Console.WriteLine($"Failed to create Point for pair {x} and {y}  - Point (0;0) was created");
                }
            }
            public string Show()
            {
                return $"({x},{y})";
            }
        }
        class Circle
        {
            Point center;
            double radius;
            public Circle(Point c, double r)
            {
                center = c;
                radius = (r >= 0 ? r : 0);
            }
            public void Show()
            {
                Console.WriteLine($"Circle with center {center.Show()} and radius {radius}; perimeter {this.Perimeter()} and surface {this.Surface()}");
            }
            public double Perimeter()
            {
                return 2 * Math.PI * radius;
            }
            public double Surface()
            {
                return Math.PI * radius * radius;
            }

        }
        class Triangle
        {
            private Point a, b, c;
            public Triangle(Point a, Point b, Point c)
            {
                this.a = a;
                this.b = b;
                this.c = c;
                if((a.x == b.x && b.x == c.x) || (a.y == b.y && b.y == c.y))
                {
                    Console.WriteLine($"This is not a real triangle: {a.Show()}, {b.Show()}, {c.Show()}");
                }
            }
            public void Show()
            {
                Console.WriteLine($"Triangle with points {a.Show()}, {b.Show()}, {c.Show()}; perimeter {Perimeter()} and  {Surface()} surface");
            }
            public double Perimeter()
            {
                return SideLength(a, b) + SideLength(b, c) + SideLength(c, a);
            }
            public double SideLength(Point p1, Point p2)
            {
                return Math.Sqrt((p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y));
            }
            public string Surface()
            {
                return "some";
            }

        }
        class Square
        {
            Point a, c;
            public Square(Point a, Point c)
            {
                this.a = a;
                this.c = c;
            }
            public void Show()
            {
                Console.WriteLine($"Square with points {a.Show()} and {c.Show()}, perimeter {Perimenter()} and surface {Surface()}");
            }
            double DiagLength()
            {
                return Math.Sqrt((a.x - c.x) * (a.x - c.x) + (a.y - c.y) * (a.y - c.y));
            }
            double SideLength()
            {
                return Math.Sqrt((DiagLength() * DiagLength()) / 2);
            }
            public double Perimenter()
            {
                return SideLength() * 4;
            }
            public double Surface()
            {
                return SideLength() * SideLength();
            }
        }

        #endregion

        #region Task_6_3_2
        private static void Task_6_3_2()    //Отображение колиества пассажиров в автобусе
        {
            Bus b = new Bus();
            b.PrintStatus();
            b.load = 0;
            b.PrintStatus();
            b.load += 12;
            b.PrintStatus();
        }
        class Bus
        {
            public int? load;
            public void PrintStatus()
            {
                Console.WriteLine($"There are {load??0} people in a bus");
                Console.WriteLine($"There are {(load.HasValue ? load : "no")} people in the bus");
            }
        }
        #endregion

        #region Task_6_3_1
        private static void Task_6_3_1()    //Напишите такой код, который бы при типе компании, равному типу "Банк", и городе "Санкт-Петербург" выводил в консоль сообщение "У банка ??? есть отделение в Санкт-Петербурге", где вместо "???" выводилось бы название компании.
                                            //Если у компании нет названия, вместо него должно быть "Неизвестная компания".
        {
            Company[] companies = {new Company("bank", "name1"), new Company(null, "name2"), new Company("not-a-bank", "name3"), new Company("bank", null), null };
            City[] cities = { new City { name = "SPB" }, new City { name = "MOW" }, new City { name = "NYC" }, null };
            List <Department> deptList = new List<Department>();
            foreach(Company co in companies)
            {
                foreach(City ci in cities)
                {
                    deptList.Add(new Department(co, ci));
                }
            }

            foreach(Department dept in deptList)
            {
                if (dept.city?.name == "SPB" && dept.company?.type == "bank")
                {
                    Console.WriteLine($"++ Bank {dept.company?.name?? "Unknown Company"} has a branch in SPB");
                }
                else
                {
                    Console.WriteLine($"-- Company {dept.company?.name??"Unknown Company"} of type {dept.company?.type??"Unknown Type"} with office in {dept.city?.name??"Unknown City"} is out of scope");
                }
            }
        }

        class Company
        {
            public string type;
            public string name;
            public Company (string type, string name)
            {
                this.type = type;
                this.name = name;
            }
        }

        class Department
        {
            public Company company;
            public City city;
            public Department(Company company, City city)
            {
                this.company = company;
                this.city = city;
            }

            void IsBankHasSpbOffice(Department dept)
            {

            }
        }

        class City
        {
            public string name;
        }
        private static void Task_6_3()
        {
            int? first = 1;
            object second = first ?? 100;
            int? third = null;
            Console.WriteLine($"-- {third ?? 25}");


            Data data = new Data { name = "record", length = 10, version = 1, array = new int[] { 15, 30 } };
            Obj obj = new Obj { name = "table", isAlive = false, waight = 15 };

            var dataCopy = data;
            var objCopy = obj;
            data.name = "sOMEvALUE";
            data.length = 35;
            data.version = 2;
            data.array[0] = 0;

            obj.name = "cat";
            obj.isAlive = true;
            obj.waight = 3;

            objCopy = new Obj { name = obj.name, isAlive = obj.isAlive, waight = obj.waight };

            obj.name = "table";
            obj.isAlive = false;
            obj.waight = 15;

            Console.ReadKey();
        }
        #endregion
        struct Data
        {
            public string name;
            public int length;
            public int version;
            public int[] array;
        }
        class Obj
        {
            public string name;
            public bool isAlive;
            public int waight;
        }

        #region Task_6_2_2
        private static void Task_6_2_2()    // Добавьте в класс Pen, указанный ниже, 2 конструктора.
                                            // Описание класса и конструкторы приведены ниже 
        {
            Pen aPen = new Pen { color = "white", cost = 99 };
        }

        class Pen   //для задачи 6.2.2
        {
            public string color;
            public int cost;
            public Pen()
            {
                color = "black";
                cost = 100;
            }
            public Pen (string penColor, int penCost)
            {
                color = penColor;
                cost = penCost;
            }
        }
        #endregion
        class Rectangle // Задача 6.2.8
        {
            int a;
            int b;
            public int Square()
            {
                return a * b;
            }
            public Rectangle()
            {
                a = 6;
                b = 4;
            }
            public Rectangle(int a)
            {
                this.a = this.b = a;
            }
            public Rectangle(int a, int b)
            {
                this.a = a;
                this.b = b;
            }
        }


    }
}
