using System;

namespace oop
{
    public class Person
    {
        public string Name { get; set; }
        
        public Person(string Name)
        {
            this.Name = Name;   
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Student : Person
    {
        public string Major { get; set; }

        public Student(string Name, string Major) : base(Name)
        {
            this.Major = Major;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.Major;
        }
    }

    public class Teacher : Person
    {
        public string Room { get; set; }

        public Teacher(string Name, string Room) : base(Name)
        {
            this.Room = Room;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.Room;
        }

        public void teach()
        {
            Console.Write("Teaching");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Tom", "CS");

            Person[] persons = new Person[5];
            persons[0] = new Student("John", "IT");
            persons[1] = new Teacher("Mike", "A5");

            foreach(Person person in persons)
            {
                if (person != null)
                {
                    if(person.GetType().ToString() == "oop.Student")
                    {
                        Console.WriteLine("do student stuff");
                    }
                    else if (person.GetType().ToString() == "oop.Teacher")
                    {
                        Console.WriteLine("do teacher stuff");
                    }
                    
                }
            }

            Console.WriteLine(student);
        }
    }
}
