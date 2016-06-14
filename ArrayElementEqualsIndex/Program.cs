using System;
using System.Linq;

/*
 * Input: 
 * Array of distinct integers
 * 
 * Problem: 
 * Find index of element which equals its index in array, if it exists.
 * 
 * Solution using binary search of zero difference 
 * between the element and its index in array
 */

namespace ArrayElementEqualsIndex
{
    class Program
    {
        static void Main(string[] args) {
            if (args.Length == 0) {
                Console.WriteLine("No input data");
                ShowUsage();
                return;
            }

            int[] arr = Array.Empty<int>();
            try {
                arr = args.Select(int.Parse).ToArray();
            }
            catch (Exception) {
                Console.WriteLine("Incorrect input data");
                ShowUsage();
                return;
            }

            int resultIndex = -1;

            // Binary search of zero diff
            int low = 0;
            int high = args.Length-1;
            while (low <= high) {
                int index = low + ((high - low) >> 1);
                if (arr[index] - index > 0) {
                    high = index - 1;
                }
                else if (arr[index] - index < 0) {
                    low = index + 1;
                }
                else {
                    resultIndex = index;
                    break;
                }
            }

            if (resultIndex >= 0) {
                Console.WriteLine("Element equals index at index: " + resultIndex);
            }
            else {
                Console.WriteLine("Element not found");
            }
        }

        private static void ShowUsage() {
            Console.WriteLine("Usage: [int] [int] ... [int]");
        }
    }
}
