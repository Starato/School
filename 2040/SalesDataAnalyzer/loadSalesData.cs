using System;
using System.IO;
using System.Collections.Generic;

namespace SalesDataAnalyzer
{
    public class loadSalesData
    {
        public static List<Sales> parseData(string filePath){
            List<Sales> salesData = new List<Sales>();

            try{
                using(var salesReader = new StreamReader(filePath)){
                    string lineOfData = salesReader.ReadLine();
                    int lineNumber = 1;
                    int piecesOfData = 11;

                    while(!salesReader.EndOfStream){
                        lineNumber++;
                        lineOfData = salesReader.ReadLine();
                        var values = lineOfData.Split(',');
                        if(values.Length != piecesOfData){throw new Exception($"Row {lineNumber} contains {values.Length} pieces of data. It should have {piecesOfData}");}
                        try{
                            string invoice = values[0];
                            string branch = values[1];
                            string city = values[2];
                            string customer = values[3];
                            string gender = values[4];
                            string product = values[5];
                            float unit = filterStringFloat(values[6]);
                            int quantity = filterStringInt(values[7]);
                            string date = values[8];
                            string payment = values[9];
                            float rating = filterStringFloat(values[10]);

                            Sales salesList = new Sales(invoice, branch, city, customer, gender, product, unit, quantity, date, payment, rating);
                            salesData.Add(salesList);
                        }catch(Exception e){
                            throw new Exception($"Row {lineNumber} contains invalid data. {e.Message}");
                        }
                    }
                }
            }catch(Exception e){
                throw new Exception($"There was an error reading the file: {e.Message}");
            }
            return salesData;
        }

        public static int filterStringInt(string value){return Int32.Parse(value);}

        public static float filterStringFloat(string value){return float.Parse(value);}
    }
    
}