using System.Collections;

namespace ex07_collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5]; // 1. 초기화
            // Console.WriteLine(int.MaxValue); // C#에 각 타입의 최대값, 최솟값
            array[0] = 80;
            array[1] = 82;
            array[2] = 84;
            array[3] = 86;
            array[4] = 88;

            

            // 2. 초기화 방법 -> 초기화 선언하면서 값을 바로 지정
            int[] score = new int[5] { 50, 60, 70, 80, 90 };

            // 3. 초기화 배열의 크기를 생략
            string[] names = new string[] { "Hello", "World", "C#" };

            // 4. 초기화 그냥 다 생략
            float[] points = { 3.14f, 5.5f, 4.4f, 10.8f};

            // 타입확인
            Console.WriteLine($"배열타입 : {score.GetType()}");
            Console.WriteLine($"배열 기본타입 : {score.GetType().BaseType}");

            foreach (var item in names)
            {
                Console.WriteLine($"문자열은, {item}");
            }

            Console.WriteLine(score.Length);

            Array.Sort(score);
            foreach (var item in names)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine("");

            Console.WriteLine(Array.BinarySearch(score,90)); // 4 인덱스 4에 있는 존재 한다

            char[] array2 = new char['Z' - 'A'+1] ;
            for (int i = 0; i < array2.Length; i++)
                array2[i] = (char)('A' + i);

            foreach (var item in array2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(); //굳이 이렇게 복잡하게 출력할 필요 없음

            // 배열 분할
            Console.WriteLine(array2);

            // 배열분할 시작 인덱스... 종료인덱스 + 1
            Console.WriteLine(array2[..]); //System.Range
            Console.WriteLine(array2[5..]); //System.Range
            Console.WriteLine(array2[5..11]); //system.Range
            
            // 2차원 배열, 3차원 배열, 가변배열  등 C ++ 과 동일
            /*
             * 컬렉션
             */
            //ArrayList
            ArrayList arrayList = new ArrayList();
            arrayList.Add(10);
            arrayList.Add(array2);
            arrayList.Add(true);
            arrayList.Add("Hello");

            Console.WriteLine(arrayList);

            foreach(var item in arrayList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(arrayList.Count); // ArrayList 길이
            arrayList.RemoveAt(1); //ArrayList에 인덱스 1번의 값을 삭제
            arrayList.Insert(2,25); // 2번 인덱스 25를 추가

            // STACK, QUEUE
            // STACK =>
            Stack stack= new Stack();
            stack.Push(1);
            stack.Pop();
            
            Queue que = new Queue();
            que.Enqueue(1);
            que.Dequeue();

            // Hashtable == dictionary
            Hashtable ht = new Hashtable();
            ht["book"] = "책";
            ht["cook"] = "요리사";
            ht["programer"] = "programer";

            Console.WriteLine(ht["programer"]);

            // foreach 가 가능한 객체를 만들기

            var obj = new CustomEnumerator();
            foreach (var item in obj)
            {
                Console.WriteLine(item);
            }
        }
    }

    class CustomEnumerator // foreach로 사용할 수 없는 객체를 반복문을 쓸 수 있도록 만들어 주는 것
    {
        int[] numbers = { 1, 2, 3, 4 }; // 임의로 마치는 반복문(foreach)를 못쓴다고 가정
        public IEnumerator GetEnumerator()
        {
            // 일반 return은 return문을 만나면 메서드를 빠져나감
            // yield return은 return문을 실행한 뒤 멈춰 있음.
            // 다음 yield return문을 실행하기 전까지
            yield return numbers[0];
            yield return numbers[1];
            yield return numbers[2];
            // yield break; // 모든 로직을 빠져나감
            yield return numbers[3];

        }
    }
}
