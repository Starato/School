using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace SalesDataAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            string filterFilePath = filterCSVExt(args[0]);
            string filterReportPath = filterTXTExt(args[1]);

            welcome(args, filterFilePath, filterReportPath);

            Console.WriteLine($"File path: {filterFilePath}");
            Console.WriteLine($"Report path: {filterReportPath}");

            report(filterFilePath, filterReportPath);
        }

        static string[] welcome(string[] args, string filterFilePath, string filterReportPath){
            string illegalChars = "<>:\"\\/|?*";
            Console.WriteLine("Welcome to Sales Data Analyzer");
            if(args.Length < 2){
                Console.WriteLine("Please try again, must have 2 arguements, separated by a space");
                System.Environment.Exit(1);
            }
            if(!File.Exists(filterFilePath)){
                Console.WriteLine("Please try again, DATA file does not exist");
                System.Environment.Exit(1);
            }
            if(File.Exists(filterReportPath)){
                Console.WriteLine("Please choose a different REPORT name, file already exists");
                System.Environment.Exit(1);
            }
            if(illegalChars.Any(filterReportPath.Contains)){
                Console.WriteLine("REPORT name contains illegal characters, please try again");
                System.Environment.Exit(1);
            }
            return args;
        }

        static void report(string filePath, string reportPath){
            List<Sales> salesData = loadSalesData.parseData(filePath);

            string reportText = ("*************************");
            reportText += (" \nTotal Sales in Dataset");
            reportText += (" \n*************************");
            
            var totalSales = (from sales in salesData select sales.getUnit()).Sum();
            reportText += ($" \nTotal sales: {totalSales}");

            reportText += (" \n\n*************************");
            reportText += (" \nUnique Produclines");
            reportText += (" \n*************************");

            var uniqueProductlines = (from sales in salesData orderby sales.getProduct() ascending select sales.getProduct()).Distinct();
            foreach(var productLines in uniqueProductlines){reportText += ($" \n{productLines}");}

            reportText += (" \n\n*************************");
            reportText += (" \nTotal Sales per Product Line");
            reportText += (" \n*************************");

            foreach(var productLine in uniqueProductlines){
                var salesPerProductLine = (from sales in salesData where sales.getProduct() == productLine select sales.getUnit()).Sum();
                reportText += ($" \n{productLine}: {salesPerProductLine}");
            }

            reportText += (" \n\n*************************");
            reportText += (" \nTotal Sales per City");
            reportText += (" \n*************************");

            var uniqueCities = (from sales in salesData orderby sales.getCity() ascending select sales.getCity()).Distinct();
            foreach(var cities in uniqueCities){
                var salesPerCity = (from sales in salesData where sales.getCity() == cities orderby sales.getCity() ascending select sales.getUnit()).Sum();
                reportText += ($" \n{cities}: {salesPerCity}");
            }

            reportText += (" \n\n*************************");
            reportText += (" \nProduct lines with Highest Unit Price");
            reportText += (" \n*************************");

            var findHighestPrice = (from sales in salesData select sales.getUnit()).Max();
            var highestPriceInProductLine = from sales in salesData where sales.getUnit() == findHighestPrice select sales;
            foreach(var high in highestPriceInProductLine){reportText += ($" \n{high.getProduct()}: {high.getUnit()}");}

            reportText += (" \n\n*************************");
            reportText += (" \nTotal Sales per Month");
            reportText += (" \n*************************");

            var findUniqueMonths =  (from sales in salesData orderby sales.getDate().Substring(0, 1) ascending select sales.getDate().Substring(0,1)).Distinct();
            foreach(var month in findUniqueMonths){
                var totalSalesPerMonth = (from sales in salesData where sales.getDate().Substring(0,1) == month select sales.getUnit()).Sum();
                reportText += ($" \n{month}: {totalSalesPerMonth}");
            }

            reportText += (" \n\n*************************");
            reportText += (" \nTotal Sales by Payment Type");
            reportText += (" \n*************************");
            
            var findUniquePaymentType = (from sales in salesData orderby sales.getPayment() ascending select sales.getPayment()).Distinct();
            foreach(var uniquePayment in findUniquePaymentType){
                var totalSalesPaymentType = (from sales in salesData where sales.getPayment() == uniquePayment orderby sales.getPayment() descending select sales.getUnit()).Sum();
                reportText += ($" \n{uniquePayment}: {totalSalesPaymentType}");
            }

            reportText += (" \n\n*************************");
            reportText += (" \nTotal Transactions by Member Type");
            reportText += (" \n*************************");

            var getUniqueMember = (from sales in salesData select sales.getCustomer()).Distinct();
            foreach(var member in getUniqueMember){
                var nTransaction = (from sales in salesData where sales.getCustomer() == member select sales).Count();
                reportText += ($" \n{member}: {nTransaction}");
            }

            reportText += (" \n\n*************************");
            reportText += (" \nAverage Rating per Product Line");
            reportText += (" \n*************************");

            //using previous unique product line query
            foreach(var product in uniqueProductlines){
                var nRatingsPerProductLine = (from sales in salesData where sales.getProduct() == product select sales).Count();
                var totalRatingsPerProductLine = (from sales in salesData where sales.getProduct() == product select sales.getRating()).Sum();
                reportText += ($" \n{product}: {totalRatingsPerProductLine / nRatingsPerProductLine} ");
            }

            reportText += (" \n\n*************************");
            reportText += (" \nTotal Transaction by Payment Type");
            reportText += (" \n*************************");

            //using previous unique payment type
            foreach(var paymentType in findUniquePaymentType){
                var nTransaction = (from sales in salesData where sales.getPayment() == paymentType select sales).Count();
                reportText += ($" \n{paymentType}: {nTransaction}");
            }

            reportText += (" \n\n*************************");
            reportText += (" \nNumber of Products Sold per City");
            reportText += (" \n*************************");
            
            //using preivous unique cities query
            foreach(var cities in uniqueCities){
                var nProducts = (from sales in salesData where sales.getCity() == cities select sales.getQuantity()).Sum();
                reportText += ($" \n{cities}: {nProducts}");
            }

            reportText += (" \n\n*************************");
            reportText += (" \nTax per Sale per Product Line");
            reportText += (" \n*************************");

            float taxRate = .05f;
            var all = from sales in salesData orderby sales.getProduct() select sales;
            foreach(var data in all){reportText += ($" \nInvoice: {data.getInvoice()} - Total: {data.getUnit()} - Tax: {data.getUnit() * taxRate}");}

            //Write report
            try{
                using(var reportWriter = new StreamWriter(reportPath)){
                    reportWriter.Write(reportText);
                }
            }catch(Exception e){Console.WriteLine($"Exception Occurred: {e.Message}");}
        }

        static string filterCSVExt(string filePath){
            string newFilePath;
            if(filePath.EndsWith(".csv")){return filePath;}
            if(!filePath.EndsWith(".csv")){return newFilePath = filePath + ".csv";}
            return filePath;
        }

        static string filterTXTExt(string filePath){
            string newFilePath;
            if(filePath.EndsWith(".txt")){return filePath;}
            if(!filePath.EndsWith(".txt")){return newFilePath = filePath + ".txt";}
            return filePath;
        }
    }
}
