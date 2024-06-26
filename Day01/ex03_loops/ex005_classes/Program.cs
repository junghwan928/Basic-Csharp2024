﻿using System.Diagnostics.CodeAnalysis;

namespace ex005_classes
{
    class ArmorSuite
    {
        public virtual void Initialize()
        {
            Console.WriteLine("Armor Suite");
        }
    }

    class WarMachine : ArmorSuite
    {
        public override void Initialize()
        {
            base.Initialize(); //일단 부모의 Initialize()를 먼저 실행
            Console.WriteLine("Micro Rocket Launch Armor");
        }
    }

    class IronMan : ArmorSuite
    {
        public override void Initialize()
        {
            // base.Initialize(); //부모의 메서드를 실행 안했음
            Console.WriteLine("리펄서 레이아머드");
        }
    }

    interface ILogger
    {
        void WritLog(string log); //인터페이스 전부
    }

    // 인터페이스는 구현 -> ILogger를 구현한 ConsoleLogger 클래스를 만든다 
    class ConsoleLogger : ILogger
    {
        public void WritLog(string log)
        {
            // 나는 ILogger에 있는 WriteLog를 이렇게 구현
            Console.WriteLine($"{DateTime.Now.ToLocalTime()} : {log}");
        }
    }

    class IronMan3 : ArmorSuite, ILogger
    {
        public override void Initialize()
        {
            base.Initialize();
        }

        public void WritLog(string log)
        {
            Console.WriteLine(log);
        }
    }

    internal class Program
    { 
        static (int count, int sum, double average) Calc(List<int> data)
        {
            int cnt = 0, sum = 0;
            double avg = 0.0;

            foreach (int i in data) 
            {
                cnt++;
                sum += i;
            }

            avg = (double) sum / cnt;
            return(cnt, sum, avg); // 이게 처음부터 지원되었으면 out 파라미터 필요 없음
        }
        static void Main(string[] args)
        {
            WarMachine machine = new WarMachine();
            machine.Initialize();

            IronMan man = new IronMan();
            machine.Initialize();

            var list = new List<int> { 1, 2, 3, 4,5,6,7,8,9,10 };
            (int cnt, int sum, double avg) r = Calc(list);
            Console.WriteLine($"갯수 = {r.cnt}, 합계 = {r.sum}, 평균 = {r.avg}");
        }
    }
}
