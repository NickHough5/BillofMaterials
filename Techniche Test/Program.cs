using System;
using System.Collections.Generic;
using Techniche_Test.Shapes;
using Techniche_Test.Interfaces;
using Techniche_Test.Factories;
using System.IO;
using System.Text;

namespace Techniche_Test
{
    class Program
    {
        private static StreamWriter ErrorFile = null;
        private static string ErrorFileName = $@".\Log-{System.DateTime.Now.ToString("yyyy-mm-dd hhmmss")}.txt";
        const string header = "----------------------------------------------------------------"
                       + "\nBill of Materials"
                       + "\n----------------------------------------------------------------";
        const string footer = "----------------------------------------------------------------";
        const string abort = "+++++Abort+++++";
        static void Main(string[] args)
        {
            if(ValidateInput(args) == false)
            {
                ErrorFile.Flush();
                ErrorFile.Close();
                return;
            }

            Queue<IShape> shapes = new Queue<IShape>();
            for (int i = 1; i < args.Length; i++)
            {
                LoadData(args[i], shapes);
            }
            GenerateOutput(shapes, args[0]);

            if (ErrorFile != null)
            {
                ErrorFile.Flush();
                ErrorFile.Close();
            }
        }

        private static bool ValidateInput(string[] args)
        {
            if (args.Length < 2)
            {
                if (ErrorFile == null)
                {
                    ErrorFile = new StreamWriter(ErrorFileName, false, Encoding.UTF8);
                }
                string error = "Please specify at least 2 parameters, Output File and Input File";
                Console.WriteLine(error);
                ErrorFile.WriteLine(error);
                return false;
            }
            return true;
        }

        private static Queue<IShape> LoadData(string inputFileName, Queue<IShape> shapes)
        {
            string input;
            bool hasErrored = false;
            StreamReader inputFile = new StreamReader(inputFileName);
            while (!string.IsNullOrWhiteSpace(input = inputFile.ReadLine()))
            {
                try
                {
                    IShape shape = ShapeFactory.Create(input);
                    if (shape != null)
                    {
                        shapes.Enqueue(shape);
                    }
                }
                catch (Exception e)
                {
                    if (ErrorFile == null)
                    {
                        ErrorFile = new StreamWriter(ErrorFileName, false, Encoding.UTF8);
                    }
                    ErrorFile.WriteLine(e.Message);
                    hasErrored = true;
                }
            }
            inputFile.Close();

            if(hasErrored)
            {
                return new Queue<IShape>();
            }

            return shapes;
        }

        private static void GenerateOutput(Queue<IShape> shapes, string outputFileName)
        {
            StreamWriter outputFile = new StreamWriter(outputFileName, false, Encoding.UTF8);

            if (shapes.Count == 0)
            {
                Console.WriteLine(abort);
                outputFile.WriteLine(abort);
            }
            else
            {
                Console.WriteLine(header);
                outputFile.WriteLine(header);
                while (shapes.TryDequeue(out IShape shape))
                {
                    string line = shape.GenerateOutput();
                    Console.WriteLine(line);
                    outputFile.WriteLine(line);
                }
                Console.WriteLine(footer);
                outputFile.WriteLine(footer);
            }
            outputFile.Flush();
            outputFile.Close();
        }
    }
}
