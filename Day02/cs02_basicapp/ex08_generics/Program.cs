namespace ex08_generics
{
    internal class Program
    {
        static void copyArray(int[] src, int[] dest)
        {
            for (int i = 0; i < src.Length; i++) {
                dest[i] = src[i];
            }
        }
        static void Main(string[] args)
        {
            int[] array1 = { 10, 20, 30, 50, 70 };
            int[] array2 = new int[array1.Length];

            copyArray(array1, array2);
            Console.WriteLine(array2);
        }
    }
}
