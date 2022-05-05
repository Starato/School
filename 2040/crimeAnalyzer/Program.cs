using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace crimeAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Number of arguments. {args.Length}\n\n");
            string fileName = fileFilter(args[0]);
            string reportName = reportFilter(args[1]);
            Console.WriteLine($"File Name: {fileName}");
            Console.WriteLine($"Report Name: {reportName}");
            
            //data
            List<Crime> crimeList = crimeDataLoader.loadCrimeData(fileName);

            //report file
            string reportText = "Crime Analyzer Report\n\n";

            //period of data colelcted
            var minPeriod = (from crime in crimeList select crime.getYear()).Min();
            var maxPeriod = (from crime in crimeList select crime.getYear()).Max();
            reportText += $"Period: {minPeriod}-{maxPeriod}({maxPeriod - minPeriod + 1} years)\n\n";
            
            //years that murders less than 15,000
            reportText += $"Years murders per year < 15,000:\n";
            var murderLess_15000 = from crime in crimeList where crime.getMurder() < 15000 select crime;
            foreach(var crime in murderLess_15000){reportText += $"{crime.getYear()}\n";}

            //years that robberies greater than 500,000
            reportText += $" \nRobberies per year > 500,000:\n";
            var robGreater_500000 = from crime in crimeList where crime.getRobbery() > 500000 select crime;
            foreach(var rob in robGreater_500000){reportText += $"{rob.getYear()} = {rob.getRobbery()}\n";}

            //violent crime per capita rate in 2010
            reportText += $" \nViolent crime per capita rate (2010):\n";
            var popIn_2010 = from crime in crimeList where crime.getYear() == 2010 select crime;
            foreach(var vCrime in popIn_2010){
                float pop = (float)vCrime.getPop();
                float violentCrimes = (float)vCrime.getViolentCrime();
                reportText += $"{(violentCrimes/pop)}\n";
            }

            //Average murder per year (all years)
            reportText += $" \nAverage murder per year (all years):\n";
            var avgMurderPerYear = from crime in crimeList select crime;
            float years = (float)maxPeriod - (float)minPeriod + (float)1;
            float murders = 0;
            foreach(var avgAllYear in avgMurderPerYear){
                murders += avgAllYear.getMurder();
            }
            reportText += $"{murders/years}\n";
            Console.WriteLine(reportText);

            //Average murder per year 1994 - 1997
            reportText += $" \nAverage murder per year (1994-1997):\n";
            var avgMurder_9497 = from crime in crimeList where crime.getYear() >=1994 && crime.getYear() <= 1997 select crime;
            var avgMurder_1994 = (from crime in crimeList where crime.getYear() >=1994 && crime.getYear() <= 1997 select crime.getYear()).Min();
            var avgMurder_1997 = (from crime in crimeList where crime.getYear() >=1994 && crime.getYear() <= 1997 select crime.getYear()).Max();

            float year_9497 = avgMurder_1997 - avgMurder_1994 + 1;
            float murders9497 = 0;            
            foreach(var avg1994 in avgMurder_9497){
                murders9497 += avg1994.getMurder();
            }
            reportText += $"{murders9497/year_9497}\n";

            //2010 - 2014
            reportText += $" \nAverage murder per year (2010-2014):\n";
            var avgMurder_1014 = from crime in crimeList where crime.getYear() >=2010 && crime.getYear() <= 2014 select crime;
            var avgMurder_2010 = (from crime in crimeList where crime.getYear() >=2010 && crime.getYear() <= 2014 select crime.getYear()).Min();
            var avgMurder_2014 = (from crime in crimeList where crime.getYear() >=2010 && crime.getYear() <= 2014 select crime.getYear()).Max();

            float year_1014 = avgMurder_2014 - avgMurder_2010 + 1;
            float murders1014 = 0;            
            foreach(var avg2010 in avgMurder_1014){
                murders1014 += avg2010.getMurder();
            }
            reportText += $"{murders1014/year_1014}\n";

            //Min thefts per year 1999 - 2004
            reportText += $" \nMinimum thefts per year (1999-2004):\n";
            var minTheft = (from crime in crimeList where crime.getYear() >=1999 && crime.getYear() <= 2004 select crime.getTheft()).Min();
            reportText += $"{minTheft}\n";

            //Max thefts per year 1999 - 2004
            reportText += $" \nMaximum thefts per year (1999-2004):\n";
            var maxTheft = (from crime in crimeList where crime.getYear() >=1999 && crime.getYear() <= 2004 select crime.getTheft()).Max();
            reportText += $"{maxTheft}\n";

            //Year of highest number of motor vehicle thefts
            reportText += $" \nYear of highest number of motor vehicle thefts:\n";
            var highMotorTheft = (from crime in crimeList select crime.getMotorTheft()).Max();
            var highYear = from crime in crimeList where crime.getMotorTheft() == highMotorTheft select crime;
            foreach(var theftYear in highYear){
                reportText += $"{theftYear.getYear()}\n";
            }
            
            try{

                using(var reportWriter = new StreamWriter(reportName)){
                    reportWriter.Write(reportText);
                }
            }catch(Exception e){
                Console.WriteLine($"Exception Occured {e.Message}");
            }
        }

        static string fileFilter(string fileName){

            string newFileName;

            if(!fileName.EndsWith(".csv")){return newFileName = fileName+".csv";}else{return fileName;}
        }
        static string reportFilter(string reportName){

            string newReportName;

            if(!reportName.EndsWith(".txt")){return newReportName = reportName+".txt";}else{return reportName;}
        }
    }
}
