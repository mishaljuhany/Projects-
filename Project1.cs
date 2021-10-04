using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RainbowSchool
{
    class Program
    {


        static void ColorText(string Message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(Message);
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            Console.Title = "Create a Text-file Based System For Storing and Updating Teacher Records";
            string filePath = "/Users/mish/Desktop/rai.txt";

            List<string> lines = File.ReadAllLines(filePath).ToList();

            
            Console.WriteLine("\n Available operations:");
            Console.WriteLine("\n >>>>>>>>>");
            Console.WriteLine("\n\n1- Store Teacher Data  \n2- Retrieve Data \n3- Update Teacher Data \n4- Display");

            string Choice = Console.ReadLine();

            //Store Teacher Data

            if (Choice == "1")
            {
                Console.WriteLine("Enter How many user you want ? :");
                int InpuCont = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < InpuCont; i++)
                {
                    Console.WriteLine("Enter Teacher ID :");
                    int UserID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Teacher Name :");
                    string UserName = Console.ReadLine();
                    Console.WriteLine("Enter Teacher Class :");
                    string UserClass = Console.ReadLine();
                    Console.WriteLine("Enter Teacher Section :");
                    string Usersection = Console.ReadLine();
                    string x = UserID.ToString() + ',' + UserName + ',' + UserClass + ',' + Usersection;
                    lines.Add(x);
                    File.WriteAllLines(filePath, lines);
                }
            }


            //Retrieve Data

            else if (Choice == "2")
            {
                Console.WriteLine("Enter Teacher ID To find it :");
                string ScanID = Console.ReadLine();


                foreach (var line in lines)
                {
                    string[] arry = line.Split(',');
                    if (arry[0] == ScanID)
                    {

                        Console.WriteLine("ID is :" + arry[0] + "\t \tNAME is : " + arry[1] + "\t \tCLASS is : " + arry[2] + "\t\t SECTION is : " + arry[3]);

                    }

                }
            }

            //Update Teacher Data

            else if (Choice == "3")
            {
                Console.WriteLine("Enter Teacher ID for Update  :");
                string ScanID = Console.ReadLine();

                foreach (var line in lines)
                {

                    string[] arry = line.Split(',');
                    if (arry[0] == ScanID)
                    {
                        lines.Remove(arry[0] + ',' + arry[1] + ',' + arry[2] + ',' + arry[3]);
                        Console.WriteLine("Enter Teacher Name :");
                        string UserName = Console.ReadLine();
                        Console.WriteLine("Enter Teacher Class :");
                        string UserClass = Console.ReadLine();
                        Console.WriteLine("Enter Teacher Section :");
                        string Usersection = Console.ReadLine();
                        arry[1] = UserName;
                        arry[2] = UserClass;
                        arry[3] = Usersection;
                        string x = ScanID + ',' + arry[1] + ',' + arry[2] + ',' + arry[3];

                        lines.Add(x);
                        File.WriteAllLines(filePath, lines);
                        ColorText(" File is Updated");
                        Console.WriteLine("ID is :" + arry[0] + "\t \tNAME is : " + arry[1] + "\t \tCLASS is : " + arry[2] + "\t\t SECTION is : " + arry[3]);
                        break;

                    }

                }
            }

            //Display

            else if (Choice == "4")
            {
                foreach (string line in lines)
                {

                    string[] arry = line.Split(',');
                    Console.WriteLine("ID is :" + arry[0] + "\t \tNAME is : " + arry[1] + "\t \tCLASS is : " + arry[2] + "\t\t SECTION is : " + arry[3]);
                }

            }





        }
    }


}