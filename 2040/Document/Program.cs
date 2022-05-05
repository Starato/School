using System;
using System.IO;

namespace Document
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Document\n");

            string file = getFileName();
            file = checkUserFileName(file);
            writeDataToFile(file);
            readFiledata(file);
        }

        static void writeDataToFile(string fileName){
            StreamWriter fileWriter = File.AppendText(fileName);
            bool again = true;
            while(again){
                try{
                    Console.WriteLine("\nPlease enter file content");
                    string studentData = Console.ReadLine();
                    if(studentData == ""){
                        Console.WriteLine("Please try again, line is empty");
                        again = true;
                    }else{
                        fileWriter.WriteLine(studentData);
                        fileWriter.Close();
                        again = false;
                    }
                }catch(Exception err){
                    Console.WriteLine($"Error has occurred: {err.Message}");
                }
            }
        }
        static void readFiledata(string fileName){
            StreamReader fileReader = new StreamReader(fileName);
            try{
                int wordCount = 0;
                while(!fileReader.EndOfStream){
                    string lineOfData = fileReader.ReadLine();
                    string[] words = lineOfData.Split(' ');
                    wordCount+=words.Length;
                }
                fileReader.Close();
                Console.WriteLine($"\n{fileName} was succesfully saved. The document contains {wordCount} words.");

            }catch(Exception err){

                Console.WriteLine($"Exception Occured: {err.Message}");
            }
        }
        static string getFileName(){

            bool again = true;
            while(again){
                Console.WriteLine("Please enter the name of the file to be written: ");
                string fileName = Console.ReadLine();
                if(fileName == ""){
                    Console.WriteLine("File name is empty, please try again");
                    again = true;
                }else{
                    try{

                        fileName = checkUserFileName(fileName);
                    }catch(Exception err){
                        Console.WriteLine($"Error has occured: {err.Message}");
                    }
                    return fileName;
                }
            }
            return null;
        }

        static string checkUserFileName(string fileName){

            if(fileName.EndsWith(".txt")){
                return fileName;
            }else{
                return fileName + ".txt";
            }
        }
    }
}
