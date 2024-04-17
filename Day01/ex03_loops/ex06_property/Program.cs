namespace ex06_properties
{
    class kiturami
    {
        private int temperature; // 온도

        // Rosalyn VS 개발서포터
        public int Temperature
        {
            get { return temperature; }
            set
            {
                temperature = value;
            }
        }
        //    public void SetTemperature(int temp)
        //    {
        //        if (temp > 70)
        //        {
        //            Console.WriteLine("온도가 너무 높습니다. 50도로 조정합니다/");
        //            this.temperature = 50;
        //        }
        //        else if (temp < 10)
        //        {
        //            Console.WriteLine("온도가 너무 낮습니다. 20도로 조정합니다/");
        //            this.temperature = 20;
        //        }
        //        else
        //        {
        //            this.temperature = temp;
        //        }
        //    }

        //    public int GetTemperature()
        //    {
        //        return this.temperature;
        //    }

        //    public void On()
        //    {
        //        Console.WriteLine("보일러 On");
        //    }

        //    public void off()
        //    {
        //        Console.WriteLine("보일러 off");
        //    }
        //}
        internal class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("보일러 시작!");
                kiturami boiler = new kiturami();
                boiler.temperature = 40;
                Console.WriteLine($"보일러 온도는{boiler.temperature}도");
                boiler.On();
            }
        }
    }
}
