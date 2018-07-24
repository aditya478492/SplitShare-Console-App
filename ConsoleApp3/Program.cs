using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp3
{
    class Program
    {
        static int count = 0;
        public static double Iterate(string filePath) {
            count += 2;
            List<string> lst = new List<string>();
            string text = File.ReadAllText(filePath, Encoding.UTF8);
            byte[] byteArray = Encoding.UTF8.GetBytes(text);
            MemoryStream myStream = new MemoryStream(byteArray);
            StreamReader reader = new StreamReader(myStream);
            string line = "";
            int counter = 0;
            while ((line = reader.ReadLine()) != null)
            {
                lst.Add(line);
            }
            for (int i = 0; i < lst.Count; i += 2)
            {
                if (count-2==i) {
                    return Convert.ToDouble(lst[i]);
                }
            }
            return 0;
        }
        static void method()
        {
            Console.WriteLine("Please enter path of the Input File like (C:\\Users\\Aditya\\Desktop\\Android\\file.txt):");
            string filePath = Convert.ToString(Console.ReadLine());
            int partc = (int)Iterate(filePath);
            while (partc!=0) {
                double[] arr = new double[partc];
                string[] strarr = new string[partc];
                double total = 0;
                for (int i = 0; i < partc; i++)
                {
                    int bills = (int)Iterate(filePath);
                    double sum = 0;
                    for (int j = 0; j < bills; j++)
                    {
                        sum += Iterate(filePath);
                    }
                    total += sum;
                    arr[i] = sum;
                }
                double each = total / partc;
                for (int k = 0; k < arr.Length; k++)
                {
                    double value = (arr[k] - each);
                    double v = Math.Round(value, 2);
                    arr[k] = v;
                }

                //Console.WriteLine("Output: ");
                for (int j = 0; j < arr.Length; j++)
                {
                    strarr[j] = "$ " + Convert.ToString(arr[j]);
                }
                System.IO.File.AppendAllLines(filePath+".out", strarr);
                partc = (int)Iterate(filePath);
            }
            Console.WriteLine("Output is Printed to Input file folder !!");
        }

        static void Main(String[] args) {
            method();

        }
    }
}