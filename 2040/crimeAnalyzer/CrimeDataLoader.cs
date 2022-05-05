using System;
using System.Collections.Generic;
using System.IO;

namespace crimeAnalyzer
{
    public class crimeDataLoader
    {
        public static List<Crime> loadCrimeData(string fileName){

            List<Crime> crimeData = new List<Crime>();
            try{
               using(var crimeReader = new StreamReader(fileName)){
                    int lineNumber = 1;
                    int piecesOfData = 11;
                    string lineOfData = crimeReader.ReadLine();

                    while(!crimeReader.EndOfStream){
                        lineNumber++;
                        lineOfData = crimeReader.ReadLine();

                        var values = lineOfData.Split(',');
                        if(values.Length != piecesOfData){throw new Exception($"Row {lineNumber} contains {values.Length} pieces of data. It should have {piecesOfData}");}

                        try{
                            int year = stringToInt(values[0]);
                            int pop = stringToInt(values[1]);
                            int violentCrime = stringToInt(values[2]);
                            int murder = stringToInt(values[3]);
                            int rape = stringToInt(values[4]);
                            int robbery = stringToInt(values[5]);
                            int aggrAssault = stringToInt(values[6]);
                            int prptyCrime = stringToInt(values[7]);
                            int burglary = stringToInt(values[8]);
                            int theft = stringToInt(values[9]);
                            int motorTheft = stringToInt(values[10]);

                            Crime crimes = new Crime(year, pop, violentCrime, murder, rape, robbery, aggrAssault, prptyCrime, burglary, theft, motorTheft);
                            crimeData.Add(crimes);
                        }catch(Exception e){throw new Exception($"Row {lineNumber} contains invalid data. {e.Message}");}
                    }
               }
            }catch(Exception e){
                throw new Exception($"There was an error reading the file: {e.Message}");
            }

            return crimeData;
        }

        private static int stringToInt(string value){
            int convertedValue = Int32.Parse(value);
            return convertedValue;
        }
    }


}