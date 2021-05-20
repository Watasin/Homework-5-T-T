using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Address of the imported image data file. : ");
            string InputFile = Console.ReadLine(); //D:\Guide\02\InputImage.txt
            Console.Write("Address of the Convolution Kernel data file. : ");
            string DataFileConvolutionKernel = Console.ReadLine(); //‪D:\Guide\02\ConvolutionKernel.txt
            Console.Write("Address of the output image data file. : ");
            string DataFileOutput = Console.ReadLine(); //D:\Guide\02\OutputImage.txt
            //InputFile
            Console.WriteLine("InputFile");
            double[,] imageDataInputFile = ReadImageDataFromFile(InputFile);
            Console.WriteLine("DataFileConvolutionKernel");
            //InputConvolutionKernel
            double[,] imageDataConvolution = ReadImageDataFromFile(DataFileConvolutionKernel);
            double[,] imageDataArray = new double[5, 5];
            //Output
            WriteImageDataToFile(DataFileOutput, imageDataArray);
            //forloopimageDataInputFile
            Console.WriteLine("Convolve");
            for (int i = -1; i <= 5; i++)
            {
                int newi = (i + 5) % 5;
                for (int j = -1; j <= 5; j++)
                {
                    int newj = (j + 5) % 5;
                    Console.Write("{0}   ", imageDataInputFile[newi, newj]);
                }
                Console.WriteLine();
            }

        }
        static double[,] ReadImageDataFromFile(string imageDataFilePath)
{
    string[] lines = System.IO.File.ReadAllLines(imageDataFilePath);
    int imageHeight = lines.Length;
    int imageWidth = lines[0].Split(',').Length;
    double[,] imageDataArray = new double[imageHeight, imageWidth];
    for(int i=0; i<imageHeight; i++)
    {
        string[] items = lines[i].Split(',');
        for(int j=0; j<imageWidth; j++)
        {
            imageDataArray[i, j] = double.Parse(items[j]);
        }
    }
    return imageDataArray;
}
        static void WriteImageDataToFile(string imageDataFilePath,
                                         double[,] imageDataArray)
        {
            string imageDataString = "";
            for (int i = 0; i < imageDataArray.GetLength(0); i++)
            {
                for (int j = 0; j < imageDataArray.GetLength(1) - 1; j++)
                {
                    imageDataString += imageDataArray[i, j] + ", ";
                }
                imageDataString += imageDataArray[i,
                                                imageDataArray.GetLength(1) - 1];
                imageDataString += "\n";
            }

            System.IO.File.WriteAllText(imageDataFilePath, imageDataString);
        }
    }
}
