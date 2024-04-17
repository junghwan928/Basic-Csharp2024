namespace ex08_generics1
{
    internal class Program
    {
        // 배열 복사 기능 -> 일반화 프로그래밍
        // 매세드 뒤에 <T> , 매게변수의 타입 대신 T로 변경
        static void copyArray<T>(T[] src, T[] dest)
        {
            for (int i = 0; i < src.Length; i++)
            {
                dest[i] = src[i];
            }
        }

        static void CopyArray(float[] src, float[] dest) {
            for (int i = 0; i < src.Length; i++)
            {
                dest[i] = src[i];
            }
        }
        static void Main(string[] args)
        {
            int[] array1 = { 10, 20, 30, 50, 70 };
            int[] array2 = new int[array1.Length];

            copyArray(array1, array2);
            Console.WriteLine(array2[4]);

            float[] array3 = { 3.4f, 5.5f, 7.7f };
            float[] array4 = new float[array3.Length];

            CopyArray(array3, array4);
            Console.WriteLine(array4[0]);

            string[] array5 = { "a", "b", "c", "d" };
            string[] array6 = new string[array5.Length];



            
        }
    }
}
