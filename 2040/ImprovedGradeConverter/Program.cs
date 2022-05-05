using System;
using System.Collections.Generic;

namespace gradeConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Introduction
            Console.WriteLine("What's your first and last name?: ");
            string flName = Console.ReadLine();
            Console.WriteLine($"Hello {flName}! Welcome to the Grade Converter.");
            
            //Program loop bool
            bool again = true;
            while(again){
                //Grade variables
                var gradeInfo = getGrades();
                var grades = gradeInfo.Item1;
                var nGrades = gradeInfo.Item2;
                float high = getHiGrade(grades);
                float low = getLoGrade(grades);
                double avg = getAvg(grades, nGrades);

                //Loop to convert grade to letter grade
                foreach(float g in grades){
                    Console.WriteLine($"A score of {g}, would be a {getLtrGrade(g)}");
                }
                
                //grade stats: # of grades, average, hi, lo
                Console.WriteLine("\nGrade Statistics");
                Console.WriteLine("-----------------");
                Console.WriteLine($"Number of grades: {nGrades}");
                Console.WriteLine($"Average Grade:{avg}, which is an {getLtrGrade((float)avg)}");
                Console.WriteLine($"Highest grade is {high}, which is a {getLtrGrade(high)}");
                Console.WriteLine($"Lowest grade is {low}, which is a {getLtrGrade(low)}");
            
                //ask user if they want to loop
                Console.WriteLine("\nDo you have more grades to convert?(y/n): ");
                string more = Console.ReadLine();
                if(more[0].Equals('y') || more[0].Equals('Y')){
                    again = true;
                }else{
                    again = false;
                }   
            }
        }
        static int getnGrades(){
            int nGrades = -1;
            bool again = true;
            while(again){
                try{
                    Console.WriteLine("Enter the number of grades you need to convert: ");
                    nGrades = int.Parse(Console.ReadLine());
                    if(nGrades <= 0){
                        Console.WriteLine("Please enter a positive integer.");
                        again = true;
                    }else{
                        again = false;
                        return nGrades;
                    }
                }catch(Exception){
                    nGrades = -1;
                    Console.WriteLine($"There was an error, Value stored as {nGrades}");
                    again = true;
                }
            }
            return nGrades;
        }

        static (List<float>, int) getGrades(){
            List<float> grades = new List<float>();

            int nGrades = getnGrades();
            int userValue;
            bool again = true;
            while(again){
                try{
                    for(int i=0; i<nGrades; i++){
                        Console.WriteLine($"\nPlease enter grade # {i+1}");
                        float gradeInput = float.Parse(Console.ReadLine());
                        grades.Add(gradeInput);
                    }
                    foreach(float grade in grades){
                        if(grade < 0 || grade > 100){
                            grades.Clear();
                        }else{
                            again = false;
                        }
                    }
                }catch(Exception){
                    userValue = -1;
                    Console.WriteLine($"There's an error, value a negative, or too high. Value stored as {userValue}");
                    again = true;
                }
            }
            return (grades, nGrades);
        }

        static char getLtrGrade(float grade){
            if(grade>=90 && grade<=100){
                return 'A';
            }else if(grade>=80 && grade<=90){
                return 'B';
            }else if(grade>=70 && grade<=80){
                return 'C';
            }else if(grade>=60 && grade<=70){
                return 'D';
            }else{
                return 'F';
            }
        }
    
        static double getAvg(List<float> grades, int nGrades){
            float sum = 0;

            foreach(float grade in grades){
                float total = sum+=grade;
            }

            return Math.Round(sum/nGrades,2);
            
        }

        static float getHiGrade(List<float> grades){
            float high = float.NegativeInfinity;

            foreach(float grade in grades){
                if(grade > high){
                    high = grade;
                }
            }
            return high;
        }

        static float getLoGrade(List<float> grades){
            float low = float.PositiveInfinity;

            foreach(float grade in grades){
                if(grade < low){
                    low = grade;
                }
            }
            return low;
        }


    }   

}
