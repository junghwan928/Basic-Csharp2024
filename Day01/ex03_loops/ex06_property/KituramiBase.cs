namespace ex06_property
{
    internal class KituramiBase
    {

        public int SetTemperature(int temp)
        {
            if (temperature > 0)
            {
                Console.WriteLine("온도가 너무 높습니다. 50도로 조정");
                this.temperature = 50;
            }
            else if (temperature < 0)
            {
                Console.WriteLine("온도가 너무 낮습니다 . 20도로 조정");
                this.temperature = 20;
            }
            this.temperature = temp;
        }
    }
}