﻿using System;
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
            //Determines which array the user wants to sort + search
            Console.WriteLine("\n\nArrays:\n1:\tNet_1_256\n2:\tNet_2_256\n3:\tNet_3_256\n4:\tNet_1_2048\n5:\tNet_2_2048\n6:\tNet_3_2048");
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
            //Passes the selected array into the next function
            CheckSortingAlgorithm(Selected_Array, is_2048);
        }

        private static void CheckSortingAlgorithm(List<int> Selected_Array, bool is_2048)
        {
            bool Reverse = false;

            //Determines what sort the user wants to use on the array
            Console.WriteLine("1:\tBubble Sort\n2:\tMerge Sort\n3:\tInsertion Sort\n4:\tQuick Sort\n");
            Console.Write("Enter which sorting algorithm you want to use: ");
            string UserOption = Console.ReadLine();

            //Checks whether the user wants to sorted array to be reveresed
            Console.Write("\nWould you like to reverse the sorted array? (Y/N): ");
            string Check_Reverse = Console.ReadLine().ToLower();
            if (Check_Reverse == "y")
            {
                Reverse = true;
            }

            //Based on user input, the selected sort is called with the selected array passed in
            if (UserOption == "1")
            {
                List<int> Sorted = Bubble_Sort(Selected_Array, Selected_Array.Count);

                //If the user decided to reverse the sorted array, that is completed here
                if (Reverse == true)
                {
                    Sorted.Reverse();
                }

                //Every 10th or 50th value is then displayed to the user
                DisplayValues(Selected_Array, Sorted, is_2048);

                CheckSearchingAlgorithm(Sorted, Reverse);
            }
            else if (UserOption == "2")
            {
                List<int> Sorted = Merge_Sort(Selected_Array);

                if (Reverse == true)
                {
                    Sorted.Reverse();
                }

                DisplayValues(Selected_Array, Sorted, is_2048);

                CheckSearchingAlgorithm(Sorted, Reverse);
            }
            else if (UserOption == "3")
            {
                List<int> Sorted = Insertion_Sort(Selected_Array, Selected_Array.Count);

                if (Reverse == true)
                {
                    Sorted.Reverse();
                }

                DisplayValues(Selected_Array, Sorted, is_2048);

                CheckSearchingAlgorithm(Sorted, Reverse);
            }
            else if (UserOption == "4")
            {
                List<int> Sorted = Quick_Sort(Selected_Array, 0, Selected_Array.Count - 1);

                if (Reverse == true)
                {
                    Sorted.Reverse();
                }

                DisplayValues(Selected_Array, Sorted, is_2048);

                CheckSearchingAlgorithm(Sorted, Reverse);
            }
            else
            {
                Console.WriteLine("Please enter a valid option (1-4)\n");
                CheckSortingAlgorithm(Selected_Array, is_2048);
            }
        }

        private static void DisplayValues(List<int> Unsorted_Array, List<int> Sorted_Array, bool is_2048)
        {
            //This function displays every 10th or every 50th value of the unsorted and sorted array, based on whether it is of 256 length or 2048 length
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

        private static void CheckSearchingAlgorithm(List<int> Sorted_Array, bool Reveresed)
        {
            //User is asked which search they wish to use
            Console.WriteLine("\n\n1:\tLinear Search\n2:\tBinary Search\n");
            Console.Write("Enter which sorting algorithm you want to use: ");

            string userOption;
            userOption = Console.ReadLine();

            if (userOption == "1")
            {
                //Asks the user what to search for in the array
                Console.Write("Enter the value you wish to search for: ");
                string UserInput = Console.ReadLine();
                //Try and catch to ensure the user enters an integer to search for
                try
                {
                    int Value = Convert.ToInt32(UserInput);
                    Linear_Search(Sorted_Array, Value);
                }
                catch
                {
                    Console.WriteLine("Please enter a valid integer to search the array for.");
                    CheckSearchingAlgorithm(Sorted_Array, Reveresed);
                }
            }

            else if (userOption == "2")
            {
                Console.Write("Enter the value you wish to search for: ");
                string UserInput = Console.ReadLine();
                //Due to binary search requiring an ascending sorted array to work, if the array was previously reveresed, it is now reveresed back to being ascending rather than descending
                if (Reveresed == true)
                {
                    Sorted_Array.Reverse();
                }
                try
                {
                    int Value = Convert.ToInt32(UserInput);
                    Binary_Search(Sorted_Array, Value);

                    
                }
                catch
                {
                    Console.WriteLine("Please enter a valid integer to search the array for.");
                    CheckSearchingAlgorithm(Sorted_Array, Reveresed);
                }
            }

            else
            {
                Console.WriteLine("Please enter a valid option (1-2)\n");
                CheckSearchingAlgorithm(Sorted_Array, Reveresed);
            }

            Main();
        }

        //Bubble sort algorithm, (Lambrou, 2020)
        private static List<int> Bubble_Sort(List<int> Unsorted_Array, int Array_Length)
        {
            int Counter = 0;

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
                        Counter++;
                    }
                }
            }

            //Displays number of steps for the bubble sort to the user
            Console.Write("\nNumber of steps for the bubble sort: ");
            Console.Write(Counter);

            return Array;
        }

        //Merge sort algorithm - https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-7.php
        private static List<int> Merge_Sort(List<int> Unsorted_Array)
        {

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
            int Counter = 0;

            List<int> Sorted = new List<int>();

            while (Left.Count > 0 || Right.Count > 0)
            {
                if (Left.Count > 0 && Right.Count > 0)
                {
                    if (Left[0] <= Right[0])
                    {
                        Sorted.Add(Left[0]);
                        Left.Remove(Left[0]);
                        Counter++;
                    }
                    else
                    {
                        Sorted.Add(Right[0]);
                        Right.Remove(Right[0]);
                        Counter++;
                    }
                }
                else if (Left.Count > 0)
                {
                    Sorted.Add(Left[0]);
                    Left.Remove(Left[0]);
                    Counter++;
                }
                else if (Right.Count > 0)
                {
                    Sorted.Add(Right[0]);

                    Right.Remove(Right[0]);
                    Counter++;
                }
            }
            //I was unsure how to display the number of steps to the user without displaying it multiple times, as this function and the Merge_Sort function run parallel to each other and hence this function is called several times
            return Sorted;
        }

        //Insertion sort algorithm, (Lambrou, 2020)
        private static List<int> Insertion_Sort(List<int> Unsorted_Array, int Array_Length)
        {
            int Counter = 0;

            List<int> Array = new List<int>(Unsorted_Array);
            {
                int numSorted = 1; // number of values in place
                int index; // general index
                while (numSorted < Array_Length)
                {
                    // take the first unsorted value
                    int temp = Array[numSorted];
                    // … and insert it among the sorted
                    for (index = numSorted; index > 0; index--)
                    {
                        if (temp < Array[index - 1])
                        {
                            Array[index] = Array[index - 1];
                            Counter++;
                        }
                        else
                        {
                            break;
                        }
                        
                    }
                    // reinsert value
                    Array[index] = temp;
                    numSorted++;
                }
            }

            //Displays number of steps for the insertion sort to the user
            Console.Write("\nNumber of steps for the insertion sort: ");
            Console.Write(Counter);

            return Array;
        }

        //Quick sort algorithm, (Lambrou, 2020)
        private static List<int> Quick_Sort(List<int> Unsorted_Array, int Left, int Right)
        {
            List<int> Array = new List<int>(Unsorted_Array);

            int i, j;
            int Pivot, Temp;

            i = Left;
            j = Right;
            Pivot = Array[(Left + Right) / 2];

            do
            {
                while ((Array[i] < Pivot) && (i < Right)) i++;
                while ((Pivot < Array[j]) && (j > Left)) j--;

                if (i <= j)
                {
                    Temp = Array[i];
                    Array[i] = Array[j];
                    Array[j] = Temp;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (Left < j) Quick_Sort(Array, Left, j);
            if (i < Right) Quick_Sort(Array, i, Right);

            return Array;
        }

        //Binary search algorithm - https://www.c-sharpcorner.com/blogs/binary-search-implementation-using-c-sharp1
        private static void Binary_Search(List<int> Array, int Key)
        {
            int Counter = 0;

            int Min = 0;
            int Max = Array.Count - 1;

            int Instances = 0;
            List<int> Instance_Indexes = new List<int>();

            while (Min <= Max)
            {
                int Mid = (Min + Max) / 2;

                if (Key == Array[Mid])
                {
                    Instances++;
                    Instance_Indexes.Add(Mid);
                    break;
                }
                else if (Key < Array[Mid])
                {
                    Max = Mid - 1;
                }
                else
                {
                    Min = Mid + 1;
                }
                Counter++;
            }

            //Displays number of steps for the binary search to the user
            Console.Write("\nNumber of steps for the binary search: ");
            Console.Write(Counter);

            //If the search cannot find the specified value, the closest value is searched for using this called function
            if (Instances <= 0)
            {
                Closest_Linear_Search(Array, Key);
            }
            else if (Instances > 0)
            {
                //Displays the information about the instances to the user
                Console.Write("\nThe value: ");
                Console.Write(Key);
                Console.Write(" appears ");
                Console.Write(Instance_Indexes.Count);
                Console.Write(" times(s)");

                Console.Write(" and appears at the following indexes:\n");
                for (int i = 0; i < Instance_Indexes.Count; i++)
                {
                    Console.Write(Convert.ToString(Instance_Indexes[i]));
                    Console.Write(", ");
                }
            }
            
        }

        //Simple linear search algorithm which simply checks each item in the array one by one
        private static void Linear_Search(List<int> Sorted_Array, int Value)
        {
            int Counter = 0;

            int Instances = 0;
            List<int> Instance_Indexes = new List<int>();

            for (int i = 0; i < Sorted_Array.Count; i++)
            {
                if (Sorted_Array[i] == Value)
                {
                    Instances++;
                    Instance_Indexes.Add(i);
                    break;
                }
                Counter++;
            }

            //Displays number of steps for the linear search to the user
            Console.Write("\nNumber of steps for the linear search: ");
            Console.Write(Counter);

            //If the search cannot find the specified value, the closest value is searched for using this called function
            if (Instances <= 0)
            {
                Closest_Linear_Search(Sorted_Array, Value);
            }
            else if (Instances > 0)
            {
                //Displays the information about the instances to the user
                Console.Write("\nThe value: ");
                Console.Write(Value);
                Console.Write(" appears ");
                Console.Write(Instance_Indexes.Count);
                Console.Write(" times(s)");

                Console.Write(" and appears at the following indexes:\n");
                for (int i = 0; i < Instance_Indexes.Count; i++)
                {
                    Console.Write(Convert.ToString(Instance_Indexes[i]));
                    Console.Write(", ");
                }
            }
        }

        //A linear search algorithm which searches for the nearest value inboth directions and determines which is closer based on the difference
        private static void Closest_Linear_Search(List<int> Sorted_Array, int Value)
        {
            int Value_To_Lower = Value;
            int Value_To_Raise = Value;

            int Instances = 0;
            List<int> Instance_Indexes = new List<int>();

            int Found_Number_1 = 0;
            int Found_Number_2 = 0;
            int Difference1 = 0;
            int Difference2 = 0;

            //Raises the searched value until one in the array is found
            while (Instances <= 0)
            {
                for (int i = 0; i < Sorted_Array.Count; i++)
                {
                    if (Sorted_Array[i] == Value_To_Raise)
                    {
                        Instances++;
                        Instance_Indexes.Add(i);
                        Found_Number_1 = Sorted_Array[i];
                        Difference1 = Found_Number_1 - Value;
                    }
                }
                Value_To_Raise++;
            }
            
            //Lowers the searched value until one in the array is found
            int Instances2 = 0;
            while (Instances2 <= 0)
            {
                for (int i = 0; i < Sorted_Array.Count; i++)
                {
                    if (Sorted_Array[i] == Value_To_Lower)
                    {
                        Instances2++;
                        Instance_Indexes.Add(i);
                        Found_Number_2 = Sorted_Array[i];
                        Difference2 = Value - Found_Number_2;
                    }
                }
                Value_To_Lower--;
            }
            
            //Displays the nearest value to the user
            if (Difference1 < Difference2)
            {
                Console.Write("\nThe value: ");
                Console.Write(Value);
                Console.Write(" could not be found.");

                Console.Write("\n The nearest value to this is: ");
                Console.Write(Found_Number_1);
                Console.Write(", which is found at the following index of the array: ");
                Console.Write(Instance_Indexes[0]);
            }
            
            if (Difference1 > Difference2)
            {
                Console.Write("\nThe value ");
                Console.Write(Value);
                Console.Write(" could not be found.");

                Console.Write("\nThe nearest value to this is: ");
                Console.Write(Found_Number_2);
                Console.Write(", which is found at the following index of the array: ");
                Console.Write(Instance_Indexes[1]);
            }


        }

        //Function which parses through the given files and assigns the contents of them to arrays
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
