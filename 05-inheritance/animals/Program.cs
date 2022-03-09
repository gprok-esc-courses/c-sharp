using System;

namespace animals
{
    public class Animal
    {
        public string Name { get; set; }

        public Animal(string Name)
        {
            this.Name = Name;   
        }

        public virtual void Sound()
        {
            // No sound
        }
    }

    public class Dog : Animal
    {
        public Dog(string Name) : base(Name) {  }

        public override void Sound()
        {
            Console.WriteLine("Wooof");
        }
    }

    public class Cat : Animal
    {
        public Cat(string Name) : base(Name) { }

        public override void Sound()
        {
            Console.WriteLine("Mieow");
        }
    }

    public class Duck : Animal
    {
        public Duck(string Name) : base(Name) { }

        public override void Sound()
        {
            Console.WriteLine("Quack");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Animal[] animals = new Animal[3];
            animals[0] = new Dog("Pluto");
            animals[1] = new Cat("Sylvester");
            animals[2] = new Duck("Donald");

            foreach(Animal animal in animals)
            {
                animal.Sound();
            }
            /*
            foreach(Animal animal in animals)
            {
                if (animal.GetType().ToString() == "animals.Dog")
                {
                    Dog d = (Dog)animal;
                    d.Sound();
                }
                else if (animal.GetType().ToString() == "animals.Cat")
                {
                    Cat c = (Cat)animal;
                    c.Speak();
                }
                else if (animal.GetType().ToString() == "animals.Duck")
                {
                    Duck d = (Duck)animal;
                    d.Quack();
                }
            }*/
        }
    }
}
