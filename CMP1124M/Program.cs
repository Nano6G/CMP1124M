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

            string userOption;

            Console.WriteLine("Arrays:\n1:\tNet_1_256\n2:\tNet_2_256\n3:\tNet_3_256\n4:\tNet_1_2048\n5:\tNet_2_2048\n6:\tNet_3_2048");
            Console.WriteLine("\nEnter which array you wish to search/sort:");

            userOption = Console.ReadLine();
            if (userOption == "1")
            {
                List<int> CurrentArray = Arrays[0];
            }
            else if (userOption == "2")
            {
                List<int> CurrentArray = Arrays[1];
                Console.WriteLine("2");
            }
            else if (userOption == "3")
            {
                List<int> CurrentArray = Arrays[2];
                Console.WriteLine("3");
            }
            else if (userOption == "4")
            {
                List<int> CurrentArray = Arrays[3];
                Console.WriteLine("4");
            }
            else if (userOption == "5")
            {
                List<int> CurrentArray = Arrays[4];
                Console.WriteLine("5");
            }
            else if (userOption == "6")
            {
                List<int> CurrentArray = Arrays[5];
                Console.WriteLine("6");
            }
            else
            {
                Console.WriteLine("Please enter a valid option\n");
                Main();
            }

        }

        private static void CheckSortingAlgorithm()
        {
            Console.WriteLine("1:\tBubble Sort\n2:\tMerge Sort\n3:\tInsertion Sort\n4:\tQuick Sort\n");
            Console.WriteLine("Enter which sorting algorithm you want to use:\n");

            string userOption;
            userOption = Console.ReadLine();
        }

        private static void CheckSearchingAlgorithm()
        {

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
