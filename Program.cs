using System;
using System.Collections.Generic;

namespace MidtermPythagorean {
    class Program {

        public static double distanceIterative(int[] p1, int[] p2) {
            int p1Len = p1.GetLength(0);
            double sum = 0;

            if (p1Len != p2.GetLength(0))
                throw new ArgumentException("The points must have the same number of dimensions");
            if (p1Len == 0)
                return 0.0;

            for (int i = 0; i < p1Len; i++) {
                sum += Math.Pow((double)(p2[i] - p1[i]), 2.0);
            }
            return Math.Sqrt(sum);
        }
        public static double distanceRecursive(int[] p1, int[] p2) {
            int p1Len = p1.GetLength(0);
            
            if (p1Len != p2.GetLength(0))
                throw new ArgumentException("p1 and p2 must have the same dimensions");
            if (p1Len == 0)
                return 0.0;

            return Math.Sqrt(distanceRecursiveHelper(p1, p2, 0));
        }
        public static double distanceRecursiveHelper(int[] p1, int[] p2, int i) {
            if (i == p1.GetLength(0) - 1)
                return Math.Pow(p2[i] - p1[i], 2);
            else
                return Math.Pow(p2[i] - p1[i], 2) + distanceRecursiveHelper(p1, p2, i + 1);

        }
        public static string printArray(int[] arr) {
            if (arr.GetLength(0) == 0)
                return "[]";
            
            string str = "";

            for (int i = 0; i < arr.GetLength(0); i++) {
                str += arr[i] + ", ";
            }
            return "[" + str.Substring(0, str.Length - 2) + "]";
        }

        static void Main(string[] args) {
            List<int[]> listArray = new List<int[]>();
            listArray.Add(new int[] { });
            listArray.Add(new int[] { });

            listArray.Add(new int[] { 6 });
            listArray.Add(new int[] { 2 });

            listArray.Add(new int[] { 6, 7 });
            listArray.Add(new int[] { 1, -1 });

            listArray.Add(new int[] { 6, 7, 8, 9, 10 });
            listArray.Add(new int[] { 16, 17, 18, 19, 110 });
            
            for (int i = 0; i < listArray.Capacity; i += 2) {
                Console.WriteLine("input1: " + printArray(listArray[i]));
                Console.WriteLine("input2: " + printArray(listArray[i+1]));
                Console.WriteLine($"distance: {Math.Round(distanceIterative(listArray[i], listArray[i+1]), 3)}");
                Console.WriteLine($"distance: {Math.Round(distanceRecursive(listArray[i], listArray[i+1]), 3)}");
                Console.WriteLine("--------------------");
            }
        }
    }
}
