using System;
using System.IO;
using System.Collections.Generic;

namespace Payroll
{
    class Program
    {
        static void Main(string[] args)
        {
            bool again = true;
            while(again){
                Console.WriteLine($"Please enter your name: ");
                string name = Console.ReadLine();

                List<string> rowData = readFile();
                List<payData> prData = parseFile(rowData);
                getPayPerEmp(prData, name);
                decimal payTotal = getPayTotal(prData);
                decimal maxPay = getMaxPay(prData);
                decimal minPay = getMinPay(prData);
                writePayrollSummary(prData, payTotal, maxPay, minPay);

                Console.WriteLine("Run another file?(y/n); ");
                string reply = Console.ReadLine();
                if(reply != "y"){
                    again = false;
                }else{
                    again = true;
                }
            }
        }
        static string fileExtFilter(string fileName){
            
            if(fileName.EndsWith(".csv")){
                return fileName;
            }else{
                string extFileName = fileName + ".csv";
                return extFileName;
            }
        }
        static List<string> readFile(){

            List<string> rowData = new List<string>();
            bool again = true;
            while(again){
                Console.WriteLine($" \nPlease enter filename: ");
                string fileName = Console.ReadLine();
                try{
                    StreamReader csvfile = new StreamReader(fileExtFilter(fileName));
                    while(!csvfile.EndOfStream){
                        string fileData = csvfile.ReadLine();
                        rowData.Add(fileData);
                    }
                    csvfile.Close();
                    again = false;
                }catch(Exception e){
                    Console.WriteLine($"Exception Occurred: {e.Message}");
                    again = true;
                }
            }
            return rowData;
        } 
        static List<payData> parseFile(List<string> rowData){

            List<payData> prData = new List<payData>();
            foreach(var row in rowData){
                prData.Add(new payData{
                    fName = row.Split(',')[0],
                    lName = row.Split(',')[1],
                    hours = row.Split(',')[2],
                    pay = row.Split(',')[3]
                });
            }
            return prData;
        }
        class payData{
            public string fName{get; set;}
            public string lName{get; set;}
            public string hours{get;set;}
            public string pay{get;set;}
        }
        static void writePayrollSummary(List<payData> prData, decimal payTotal, decimal maxPay, decimal minPay){
            
            StreamWriter payrollSummary = new StreamWriter("salarySummary.txt");
            try{
                payrollSummary.WriteLine($"Payroll Summary");
                payrollSummary.WriteLine($"\n------------------\n");
                payrollSummary.WriteLine($"Number of Employees: {prData.Count}");
                payrollSummary.WriteLine($"Total Payroll: {string.Format("{0:C}", payTotal)}");
                payrollSummary.WriteLine($"Average Salary: {string.Format("{0:C}", payTotal/prData.Count)}");
                payrollSummary.WriteLine($"Maximum Salary: {string.Format("{0:C}", maxPay)}");
                payrollSummary.WriteLine($"Minimum Salary: {string.Format("{0:C}", minPay)}");
                payrollSummary.Close();
            }catch(Exception e){
                Console.WriteLine($"Exception Occurred: {e.Message}");
            }
        }
        static void getPayPerEmp(List<payData> prData, string name){

            Console.WriteLine($" \nHello {name}");
            Console.WriteLine($"Welcome to the Payroll Processing Application");
            Console.WriteLine($"--------------------------------");
            foreach(var d in prData){
                Console.WriteLine($"{d.fName} {d.lName}: {string.Format("{0:C}",decimal.Parse(d.hours)*decimal.Parse(d.pay),2)}");
            }
        }
        static decimal getPayTotal(List<payData> prData){

            decimal sum = 0;
            foreach(var pay in prData){
                sum+=decimal.Parse(pay.pay)*decimal.Parse(pay.hours);
            }

            return sum;
        }
        static decimal getMaxPay(List<payData> prData){

            List<decimal> totalPay = new List<decimal>();
            foreach(var pay in prData){
                totalPay.Add(decimal.Parse(pay.hours)*decimal.Parse(pay.pay));
            }
            decimal neg = -1;
            foreach(var tp in totalPay){
                if(tp > neg){
                    neg = tp;
                }
            }
            return neg;
        }
        static decimal getMinPay(List<payData> prData){

            List<decimal> totalPay = new List<decimal>();
            foreach(var pay in prData){
                totalPay.Add(decimal.Parse(pay.hours)*decimal.Parse(pay.pay));
            }
            decimal pos = 9999999999999999;
            foreach(var tp in totalPay){
                if(tp < pos){
                    pos = tp;
                }
            }

            return pos;
        }
    }
}
