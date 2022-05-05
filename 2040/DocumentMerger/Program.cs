using System;
using System.IO;
using System.Collections.Generic;

namespace DocumentMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            bool again = true;
            while(again){

                Console.WriteLine("Document Merger");
                List<string> fileNames = getFileName();
                string mergedDocName = newFileName(fileNames);
                string mergedContent = mergeContent(fileNames);
                int charCount = getWordCount(fileNames);
                writeFileData(mergedDocName, charCount, mergedContent);
                

                Console.WriteLine($"Would you like to merge another file?(y/n): ");
                string repeat = Console.ReadLine();
                again = true ? repeat.Equals("y") : again = false;
            }
        }
        
        static string extFilter(string fileName){

            if(fileName.EndsWith(".txt")){
                return fileName;
            }else{
                return fileName + ".txt";
            }
        }

        static List<string> getFileName(){

            List<string> fileNames = new List<string>();
            bool again = true;
            while(again){

                Console.WriteLine($"Please enter the name of the file: ");
                string firstFile = Console.ReadLine();
                Console.WriteLine($"Please enter the name of the second file: ");
                string secondFile = Console.ReadLine();
                if(firstFile == "" || secondFile == ""){
                    Console.WriteLine("File name is empty, please try again.");
                    again = true;
                }else if(File.Exists(extFilter(firstFile)) && File.Exists(extFilter(secondFile))){
                    fileNames.Add(firstFile);
                    fileNames.Add(secondFile);
                    again = false;
                }else{
                    Console.WriteLine($"File does not exist, please try again");
                    again = true;
                }

            }

            return fileNames;
        }

        static string newFileName(List<string> fileNames){
            
            Console.WriteLine($"Please enter MERGED file name(if empty, name will default): ");
            string newName = Console.ReadLine();
            string extName;
            if(newName == ""){
                newName = fileNames[0]+fileNames[1];
                extName = extFilter(newName);
                return extName;
            }else{
                extName = extFilter(newName);
                return extName;
            }
        }

        static void writeFileData(string mergedDocName, int charCount, string mergedContent){
            StreamWriter sw = new StreamWriter(mergedDocName);
            try{
                sw.WriteLine(mergedContent);
                sw.Close();
            }catch(Exception err){
                Console.WriteLine($"Exception: {err.Message}");
            }finally{
                if(sw != null){
                    sw.Close();
                }
                Console.WriteLine($"{mergedDocName} was successfully saved. The document contains {charCount} characters.");
            }
        }

        static string mergeContent(List<string> fileNames){
            
            List<string> allContents = new List<string>();
            foreach(var file in fileNames){
                StreamReader files = new StreamReader(extFilter(file));
                string docContent;
                try{
                    docContent = files.ReadLine();
                    files.Close();
                    allContents.Add(docContent);
                }catch(Exception err){
                    Console.WriteLine($"Exception Occurred: {err.Message}");
                }
            }            

            string merged = $"{allContents[0]} {allContents[1]}";

            return merged;
        }

        static int getWordCount(List<string> fileNames){
            
            List<string> allContents = new List<string>();
            string docContent;
            foreach(var files in fileNames){
                StreamReader file = new StreamReader(extFilter(files));
                try{
                    docContent = file.ReadLine();
                    file.Close();
                    allContents.Add(docContent);
                }catch(Exception err){
                    Console.WriteLine($"Exception Occurred: {err.Message}");
                }
            }

            int words = allContents[0].Length + allContents[1].Length + 1; // extra 1 = extra space when merging doc
            
            return words;
        }
        
        

        

    }

}
