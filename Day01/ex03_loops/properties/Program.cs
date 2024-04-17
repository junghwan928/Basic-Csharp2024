namespace properties
{
    class Kiturami
    {
        private int temperature; // 온도

        public void SetTemperature(int temp)
        {
            if (temp > 50)
            {
                Console.WriteLine("온도가 너무 높습니다. 50도로 조정");
                this.temperature = 50;
            }
            else if (temp < 20)
            {
                Console.WriteLine("온도가 너무 낮습니다 . 20도로 조정");
                this.temperature = 20;
            }
            else
            {
                this.temperature = temp;
            }
        }

        public int GetTemperature()
        {
            return this.temperature;
        }

        public void Run()
        {
            Console.WriteLine("Boiler On");
        }

        public void Off()
        {
            Console.WriteLine("Boiler Off");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("보일러 시작!");
            Kiturami boiler = new Kiturami();
            //boiler.temperature = 40;
            //Console.WriteLine($"보일러 온도 = {boiler.temperature}도");
            boiler.SetTemperature(50);
            Console.WriteLine($"보일러 온도 = {boiler.GetTemperature()}도");
            boiler.Run();
        }
    }
}
