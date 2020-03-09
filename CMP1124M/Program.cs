using System;
using System.Collections.Generic;
using System.IO;

namespace CMP1124M
{
    class MainClass
    {
        private static void Main()
        {
            List<List<int>> Arrays = ReadFiles();
            List<int> Selected_Array = new List<int>();

            string userOption;

            Console.WriteLine("Arrays:\n1:\tNet_1_256\n2:\tNet_2_256\n3:\tNet_3_256\n4:\tNet_1_2048\n5:\tNet_2_2048\n6:\tNet_3_2048");
            Console.Write("\nEnter which array you wish to search/sort: ");

            userOption = Console.ReadLine();

            if (userOption == "1")
            {
                Selected_Array = Arrays[0];
            }
            else if (userOption == "2")
            {
                Selected_Array = Arrays[1];
            }
            else if (userOption == "3")
            {
                Selected_Array = Arrays[2];
            }
            else if (userOption == "4")
            {
                Selected_Array = Arrays[3];
            }
            else if (userOption == "5")
            {
                Selected_Array = Arrays[4];
            }
            else if (userOption == "6")
            {
                Selected_Array = Arrays[5];
            }
            else
            {
                Console.WriteLine("Please enter a valid option (1-6)\n");
                Main();
            }

            CheckSortingAlgorithm(Selected_Array);
        }

        private static void CheckSortingAlgorithm(List<int> Selected_Array)
        {
            Console.WriteLine("1:\tBubble Sort\n2:\tMerge Sort\n3:\tInsertion Sort\n4:\tQuick Sort\n");
            Console.Write("Enter which sorting algorithm you want to use: ");

            string userOption;
            userOption = Console.ReadLine();

            if (userOption == "1")
            {
                List<int> Sorted = MergeSort(Selected_Array);
                foreach (int x in Sorted)
                {
                    Console.WriteLine(x);
                }
            }
            else if (userOption == "2")
            {
                
            }
            else if (userOption == "3")
            {
                
            }
            else if (userOption == "4")
            {
                
            }
            else
            {
                Console.WriteLine("Please enter a valid option (1-4)\n");
                CheckSortingAlgorithm(Selected_Array);
            }
        }

        private static void CheckSearchingAlgorithm(List<int> Selected_Array)
        {
            Console.WriteLine("1:\tLinear Search\n2:\tBinary Search\n");
            Console.Write("Enter which sorting algorithm you want to use: ");

            string userOption;
            userOption = Console.ReadLine();

            if (userOption == "1")
            {

            }
            else if (userOption == "2")
            {
                
            }
            else
            {
                Console.WriteLine("Please enter a valid option (1-2)\n");
                CheckSearchingAlgorithm(Selected_Array);
            }
        }

        private static List<int> MergeSort(List<int> Unsorted_Array)
        {
            //List<int> Sorted_Array;

            if (Unsorted_Array.Count <= 1)
            {
                return Unsorted_Array;
            }

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = Unsorted_Array.Count / 2;

            for (int i = 0; i < middle;i++)
            {
                left.Add(Unsorted_Array[i]);
            }
            for (int i = middle; i < Unsorted_Array.Count; i++)
            {
                right.Add(Unsorted_Array[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left[0] <= right[0])  //Comparing First two elements to see which is smaller
                    {
                        result.Add(left[0]);
                        left.Remove(left[0]);      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right[0]);
                        right.Remove(right[0]);
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left[0]);
                    left.Remove(left[0]);
                }
                else if (right.Count > 0)
                {
                    result.Add(right[0]);

                    right.Remove(right[0]);
                }
            }
            return result;
        }

        private static List<List<int>> ReadFiles()
        {

            string directory = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string path = Path.GetFullPath(Path.Combine(directory, @"..\"));

            System.IO.StreamReader F1_256 = new System.IO.StreamReader(path + @"/Net_1_256.txt");
            System.IO.StreamReader F2_256 = new System.IO.StreamReader(path + @"/Net_2_256.txt");
            System.IO.StreamReader F3_256 = new System.IO.StreamReader(path + @"/Net_3_256.txt");
            System.IO.StreamReader F1_2048 = new System.IO.StreamReader(path + @"/Net_1_2048.txt");
            System.IO.StreamReader F2_2048 = new System.IO.StreamReader(path + @"/Net_2_2048.txt");
            System.IO.StreamReader F3_2048 = new System.IO.StreamReader(path + @"/Net_3_2048.txt");

            List<int> A1_256 = new List<int>();
            List<int> A2_256 = new List<int>();
            List<int> A3_256 = new List<int>();
            List<int> A1_2048 = new List<int>();
            List<int> A2_2048 = new List<int>();
            List<int> A3_2048 = new List<int>();

            List<List<int>> Arrays = new List<List<int>>();


            string Line;

            while ((Line = F1_256.ReadLine()) != null)
            {
                string[] CurrentLine = Line.Split(",");
                A1_256.Add(Convert.ToInt32(CurrentLine[0]));
            }

            while ((Line = F2_256.ReadLine()) != null)
            {
                string[] CurrentLine = Line.Split(",");
                A2_256.Add(Convert.ToInt32(CurrentLine[0]));
            }

            while ((Line = F3_256.ReadLine()) != null)
            {
                string[] CurrentLine = Line.Split(",");
                A3_256.Add(Convert.ToInt32(CurrentLine[0]));
            }

            while ((Line = F1_2048.ReadLine()) != null)
            {
                string[] CurrentLine = Line.Split(",");
                A1_2048.Add(Convert.ToInt32(CurrentLine[0]));
            }

            while ((Line = F2_2048.ReadLine()) != null)
            {
                string[] CurrentLine = Line.Split(",");
                A2_2048.Add(Convert.ToInt32(CurrentLine[0]));
            }

            while ((Line = F3_2048.ReadLine()) != null)
            {
                string[] CurrentLine = Line.Split(",");
                A3_2048.Add(Convert.ToInt32(CurrentLine[0]));
            }

            Arrays.Add(A1_256);
            Arrays.Add(A2_256);
            Arrays.Add(A3_256);
            Arrays.Add(A1_2048);
            Arrays.Add(A2_2048);
            Arrays.Add(A3_2048);

            return Arrays;
        }
    }
}
