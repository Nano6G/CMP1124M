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
            bool is_2048 = false;

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
                is_2048 = true;
            }
            else if (userOption == "5")
            {
                Selected_Array = Arrays[4];
                is_2048 = true;
            }
            else if (userOption == "6")
            {
                Selected_Array = Arrays[5];
                is_2048 = true;
            }
            else
            {
                Console.WriteLine("Please enter a valid option (1-6)\n");
                Main();
            }

            CheckSortingAlgorithm(Selected_Array, is_2048);
        }

        private static void CheckSortingAlgorithm(List<int> Selected_Array, bool is_2048)
        {

            Console.WriteLine("1:\tBubble Sort\n2:\tMerge Sort\n3:\tInsertion Sort\n4:\tQuick Sort\n");
            Console.Write("Enter which sorting algorithm you want to use: ");

            string UserOption = Console.ReadLine();

            if (UserOption == "1")
            {
                List<int> Sorted = Bubble_Sort(Selected_Array, Selected_Array.Count);

                //List<int> Reverse_Sorted = Bubble_Sort(Selected_Array, Selected_Array.Count);
                //Reverse_Sorted.Reverse();

                DisplayValues(Selected_Array, Sorted, is_2048);

                CheckSearchingAlgorithm(Sorted);
            }
            else if (UserOption == "2")
            {
                List<int> Sorted = Merge_Sort(Selected_Array);


                List<int> Reverse_Sorted = Merge_Sort(Selected_Array);
                Reverse_Sorted.Reverse();

                DisplayValues(Selected_Array, Sorted, is_2048);

                CheckSearchingAlgorithm(Sorted);
            }
            else if (UserOption == "3")
            {
                
            }
            else if (UserOption == "4")
            {
                
            }
            else
            {
                Console.WriteLine("Please enter a valid option (1-4)\n");
                CheckSortingAlgorithm(Selected_Array, is_2048);
            }
        }

        private static void DisplayValues(List<int> Unsorted_Array, List<int> Sorted_Array, bool is_2048)
        {
            if (is_2048)
            {
                Console.WriteLine("\n\nEvery 50th value before sorting:");
                for (int i = 49; i < Unsorted_Array.Count; i += 50)
                {
                    Console.Write(Unsorted_Array[i] + ", ");
                }

                Console.WriteLine("\n\nEvery 50th value after sorting:");
                for (int i = 49; i < Sorted_Array.Count; i += 50)
                {
                    Console.Write(Sorted_Array[i] + ", ");
                }
            }
            else
            {
                Console.WriteLine("\n\nEvery 10th value before sorting:");
                for (int i = 9; i < Unsorted_Array.Count; i += 10)
                {
                    Console.Write(Unsorted_Array[i] + ", ");
                }

                Console.WriteLine("\n\nEvery 10th value after sorting:");
                for (int i = 9; i < Sorted_Array.Count; i += 10)
                {
                    Console.Write(Sorted_Array[i] + ", ");
                }
            }
            
        }

        private static void CheckSearchingAlgorithm(List<int> Sorted_Array)
        {
            Console.WriteLine("\n\n1:\tLinear Search\n2:\tBinary Search\n");
            Console.Write("Enter which sorting algorithm you want to use: ");

            string userOption;
            userOption = Console.ReadLine();

            if (userOption == "1")
            {
                Console.Write("Enter the value you wish to search for: ");
                string UserInput = Console.ReadLine();
                try
                {
                    int Value = Convert.ToInt32(UserInput);
                    List<int> Instances = Linear_Search(Sorted_Array, Value);

                    Console.Write("\nThe value you searched for appears ");
                    Console.Write(Instances.Count);
                    Console.Write(" times(s)");
                    if (Instances.Count > 0)
                    {
                        Console.WriteLine("\nThe value you searched for appears at the following indexes:");
                        for (int i = 0; i < Instances.Count; i++)
                        {
                            Console.Write(Convert.ToString(Instances[i]));
                            Console.Write(", ");
                        }
                    }
                    
                }
                catch
                {
                    Console.WriteLine("Please enter a valid integer to search the array for.");
                    CheckSearchingAlgorithm(Sorted_Array);
                }
            }
            else if (userOption == "2")
            {
                
            }
            else
            {
                Console.WriteLine("Please enter a valid option (1-2)\n");
                CheckSearchingAlgorithm(Sorted_Array);
            }
        }

        //Bubble sort algorithm - Lecture 5 slides
        private static List<int> Bubble_Sort(List<int> Unsorted_Array, int Array_Length)
        {
            List<int> Array = new List<int>(Unsorted_Array);
            for (int i = 0; i < Array_Length-1; i++)
            {
                for (int j = 0; j < Array_Length-1-i; j++)
                {
                    if (Array[j + 1] < Array[j])
                    {
                        int Temp = Array[j];
                        Array[j] = Array[j + 1];
                        Array[j + 1] = Temp;
                    }
                }
            }

            return Array;
        }

        //Merge sort algorithm - https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-7.php
        private static List<int> Merge_Sort(List<int> Unsorted_Array)
        {
            int Counter = 0;

            if (Unsorted_Array.Count <= 1)
            {
                return Unsorted_Array;
            }

            List<int> Left = new List<int>();
            List<int> Right = new List<int>();

            int Middle = Unsorted_Array.Count / 2;

            for (int i = 0; i < Middle;i++)
            {
                Left.Add(Unsorted_Array[i]);
            }
            for (int i = Middle; i < Unsorted_Array.Count; i++)
            {
                Right.Add(Unsorted_Array[i]);
            }

            Left = Merge_Sort(Left);
            Right = Merge_Sort(Right);

            return Merge(Left, Right);
        }

        private static List<int> Merge(List<int> Left, List<int> Right)
        {
            List<int> Sorted = new List<int>();

            while (Left.Count > 0 || Right.Count > 0)
            {
                if (Left.Count > 0 && Right.Count > 0)
                {
                    if (Left[0] <= Right[0])
                    {
                        Sorted.Add(Left[0]);
                        Left.Remove(Left[0]);
                    }
                    else
                    {
                        Sorted.Add(Right[0]);
                        Right.Remove(Right[0]);
                    }
                }
                else if (Left.Count > 0)
                {
                    Sorted.Add(Left[0]);
                    Left.Remove(Left[0]);
                }
                else if (Right.Count > 0)
                {
                    Sorted.Add(Right[0]);

                    Right.Remove(Right[0]);
                }
            }
            return Sorted;
        }

        private static List<int> Linear_Search(List<int> Sorted_Array, int Value)
        {
            int Instances = 0;
            List<int> Instance_Indexes = new List<int>();

            for (int i = 0; i < Sorted_Array.Count; i++)
            {
                if (Sorted_Array[i] == Value)
                {
                    Instances++;
                    Instance_Indexes.Add(i);
                }
            }
            
            return Instance_Indexes;
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
