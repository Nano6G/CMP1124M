using System;
using System.IO;

namespace CMP1124M
{
    class MainClass
    {
        private static void Main()
        {
            ReadFiles()

            string userOption;

            Console.WriteLine("Arrays:\n1:\tNet_1_256\n2:\tNet_1_2048\n3:\tNet_2_256\n4:\tNet_2_2048\n5:\tNet_3_256\n6:\tNet_3_2048");
            Console.WriteLine("\nEnter which array you wish to search/sort:");

            userOption = Console.ReadLine();
            if (userOption == "1")
            {
                Console.WriteLine("1");
            }
            else if (userOption == "2")
            {
                Console.WriteLine("2");
            }
            else if (userOption == "3")
            {
                Console.WriteLine("3");
            }
            else if (userOption == "4")
            {
                Console.WriteLine("4");
            }
            else if (userOption == "5")
            {
                Console.WriteLine("5");
            }
            else if (userOption == "6")
            {
                Console.WriteLine("6");
            }

        }

        private static void ReadFiles()
        {
            string directory = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string path = Path.GetFullPath(Path.Combine(directory, @"..\"));

            System.IO.StreamReader Net_1_256 = new System.IO.StreamReader(path + @"/Net_1_256.txt");
            System.IO.StreamReader Net_2_256 = new System.IO.StreamReader(path + @"/Net_2_256.txt");
        }
    }
}
