using System.Reflection;

namespace ex14_attributes
{
    class MyClass
    {
        [Obsolete("이 메서드는 다음버전에서 폐기됩니다. NewMethod()를 사용하세요",false)] // , true 는 아예 사용불가
        /// <summary>
        /// OldMethod. 이렇게 쓰셈
        /// </summary>
        public void OldMethod() // 최초에 제작 메써드
        {
            Console.WriteLine("Old Method");
        }


        /// <summary>
        /// NewMethod. 이렇게 쓰기, 올드 메서드 지움
        /// </summary>
        public void NewMethod()  // 개선한 메써드
        { 
            Console.WriteLine("New Method");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("리플랙션!");
            Console.WriteLine(" ");


            int a = int.MaxValue;
            Type type = a.GetType();
            Console.WriteLine(type.FullName); //System.Int32
            Console.WriteLine(" ");

            float f = float.MaxValue;
            Console.WriteLine(f.GetType()); //System.Single
            Console.WriteLine(" ");

            double d = double.MaxValue;
            Console.WriteLine(d.GetType()); //System.Double
            Console.WriteLine(" ");

            FieldInfo[] fields = type.GetFields(); // 타입 객체에서 어떤 필드가 있는지 모두 확인
            foreach (var item in fields)
            {
                Console.WriteLine($"Type = {item.FieldType}, Name = {item.Name}");
            }
            Console.WriteLine(" ");

            MethodInfo[] events = type.GetMethods(); // 타입 객체에서 어떤 필드가 있는지 모두 확인
            foreach (var item in events)
            {
                Console.WriteLine($"Type = {item.DeclaringType}, Name = {item.Name}");
            }

            // 애트리뷰트
            Console.WriteLine("애트리뷰트!");

            MyClass myClass = new MyClass();
            myClass.OldMethod();
            myClass.NewMethod();

        }
    }
}
