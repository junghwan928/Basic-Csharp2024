using System;

namespace ex06_properties
{
    class kiturami
    {
        private int temperature; // 온도
        private string name;
        private int year;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public int Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                if (value < 10)
                    temperature = 20;
                else if (value > 70)
                    temperature = 50;
                else
                    temperature = value;
            }
        }

        public kiturami(string Name, int Temperature, int Year)
        {
            this.Name = Name;
            this.Temperature = Temperature;
            this.Year = Year;
        }

        public void On()
        {
            Console.WriteLine("보일러 On");
        }

        public void Off()
        {
            Console.WriteLine("보일러 off");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("보일러 시작!");

            kiturami k = new kiturami(Name: "rami", Temperature: 25, Year: 2023);
            Console.WriteLine(k.Name);
            Console.WriteLine($"제작년도: {k.Year}");
            k.Temperature = 180;
            Console.WriteLine($"제작년도: {k.Year}, 현재온도는 {k.Temperature}");
        }
    }
}
