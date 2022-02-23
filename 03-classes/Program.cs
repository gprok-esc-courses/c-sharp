using System;

namespace classes
{
    class Patient
    {
        public string Name { get; set; }
        public int Ssn { get; set; }

        private string clinic;
       
        public Patient(string name, int ssn)
        {
            Name = name;
            Ssn = ssn;
            clinic = null;
        }

        public Patient(Patient p) : this(p.Name, p.Ssn, p.GetClinic()) { }

        public Patient(string name, int ssn, string clinic) : this(name, ssn)
        {
            this.clinic = clinic;
        }

        public bool AddToClinic(string clinic)
        {
            if (clinic == "A" || clinic == "B" ||  clinic == "C")
            {
                this.clinic = clinic;
                return true;
            }
            else
            {
                this.clinic = null;
                return false;
            }
        }

        public bool AddToClinic(int c)
        {
            return true;
        }

        public void LeaveHospital()
        {
            this.clinic = null;
        }

        public string GetClinic()
        {
            if(this.clinic == null)
            {
                return "None";
            }
            else
            {
                return this.clinic;
            }
        }


        public override string ToString()
        {
            return "SSN: " + Ssn + ", " + Name + " clinic: " + GetClinic();
        }

        public void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine(a + ", " + b);
        }

        public void Swap( int a,  int b)
        {
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine(a + ", " + b);
        }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Patient p1 = new Patient("George", 111);
            Patient p2 = new Patient("John", 222, "C");
            Patient p3 = new Patient(p1);

            p3.Name = "Bob";
         

            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);

            int x = 6;
            int y = 7;
            p1.Swap( x,  y);
            Console.WriteLine(x + ", " + y);
        }
    }
}
