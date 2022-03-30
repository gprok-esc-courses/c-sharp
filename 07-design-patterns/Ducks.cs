using System;

namespace ducks
{
    interface FlyStrategy
    {
        public void Fly(); 
    }

    class FlyWithWings : FlyStrategy
    {
        public void Fly()
        {
            Console.WriteLine("Flying with wings");
        }
    }

    class FlyNoWay : FlyStrategy
    {
        public void Fly()
        {
            Console.WriteLine("Cannot fly");
        }
    }

    class FlyWithServoMotor : FlyStrategy
    {
        public void Fly()
        {
            Console.WriteLine("I'm a drone ...");
        }
    }

    class Duck
    {
        public FlyStrategy FlyingBehavior { get; set; }  

        public virtual void Display()
        {

        }
    }

    class Mallard : Duck
    {
        public Mallard() 
        {
            FlyingBehavior = new FlyWithWings();
        }

        public override void Display()
        {
            Console.WriteLine("A mallard duck");
        }
    }

    class Rubber : Duck
    {
        public Rubber()
        {
            FlyingBehavior = new FlyNoWay();
        }

        public override void Display()
        {
            Console.WriteLine("A rubber duck");
        }
    }

    class Redhead : Duck
    {
        public Redhead()
        {
            FlyingBehavior = new FlyWithWings();
        }

        public override void Display()
        {
            Console.WriteLine("A redhead duck");
        }
    }

    class Decoy : Duck
    {
        public Decoy()
        {
            FlyingBehavior = new FlyNoWay();
        }

        public override void Display()
        {
            Console.WriteLine("A decoy duck");
        }
    }


    class DuckFactory
    {
        public static Duck GetDuck(string type)
        {
            if(type == "mallard")
            {
                return new Mallard();
            }
            else if(type == "redhead")
            {
                return new Redhead();
            }
            else if(type == "decoy")
            {
                return new Decoy();
            }
            else if(type == "rubber")
            {
                return new Rubber();
            }
            return null;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Duck[] ducks = new Duck[4];

            ducks[0] = DuckFactory.GetDuck("mallard");
            ducks[1] = DuckFactory.GetDuck("redhead");
            ducks[2] = DuckFactory.GetDuck("decoy");
            ducks[3] = DuckFactory.GetDuck("rubber");

            ducks[0].FlyingBehavior = new FlyWithServoMotor();

            foreach (Duck d in ducks)
            {
                d.Display();
                d.FlyingBehavior.Fly();
            }
        }
    }
}
