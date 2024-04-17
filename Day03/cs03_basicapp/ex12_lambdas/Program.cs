using System.Runtime.InteropServices;

namespace ex12_lambdas
{
    delegate int Calculate(int a, int b); // 대리자의 정수값 두개 받아서 정수값을 리턴해주는 함수들은 내가 대신 실행
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculate calc;
            calc = delegate (int a, int b)
            {
                return a + b;
            };
            Console.WriteLine($"계산결과 = {calc(10, 4)}");

            // 람다식을 쓰면 훨씬 짧게 코딩 가능
            // calc와 동일한 기능, return문을 생략해야 함
            Calculate calc2 = (a, b) => a + b;//(int a, int b) => a + b;//{ return a + b; };
            Console.WriteLine($"계산결과 = {calc2(11, 5)}");


            // 문장형식의 람다식.
            // {} <= 여기 않에서는 return 생략 할 수 없음
            Calculate calc3 = (a, b) =>
            {
                Console.WriteLine("이런식 뺄셈이 됩니다.");
                var sum = a - b;
                return sum;
            };
            Console.WriteLine($"계산결과 = {calc3(11, 5)}");


            // Func, Action 빌트인 대리자 사용
            // Func 리턴값 있기 때문에 <int>는 리턴값이 int 란 뜻
            // <int, int>는 매개변수 하나 리턴 하나
            Func<int> func1 = () => 10;
            Console.WriteLine($"Func1 = {func1()}");

            Func<int, int> func2 = (x) => x ^ 2;
            Console.WriteLine($"Func2 = {func2(4)}");

            Func<int, int, double> func3 = (x, y) => (double)x / y;
            Console.WriteLine($"Func3 = {func3(22, 7)}");

            //Action은 리턴값이 없음
            int result = 0;
            Action<int> act1 = (x) => result = x * x;
            act1(3);
            Console.WriteLine($"Act = {result}");
            Action<double, double> act2 = (x, y) =>
            {
                double res = x / y;
                Console.WriteLine(res);
            };
            act2(21.1, 7.0);

        }
    }
    class Test
    {
        private int name;
        private double value;

        public int Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}
