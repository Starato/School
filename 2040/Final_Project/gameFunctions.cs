using System;
using System.Collections.Generic;
using System.IO;

namespace Final_Project
{
    public class gameFunctions
    {
        public static List<playerData> parsePlayerData(){
            List<playerData> playerStats = new List<playerData>();

            string filePath = "player_log.csv";
            try{
                using(var fileReader = new StreamReader(filePath)){
                    while(!fileReader.EndOfStream){
                        string lineOfData = fileReader.ReadLine();
                        // Console.WriteLine(lineOfData);
                        var values = lineOfData.Split(',');
                        try{
                            string name = values[0];
                            int wins = parseStrToInt(values[1]);
                            int losses = parseStrToInt(values[2]);
                            int ties = parseStrToInt(values[3]);

                            playerData playerList = new playerData(name, wins, losses, ties);
                            playerStats.Add(playerList);
                        }catch(Exception e){
                            Console.WriteLine($"inner stream {e.Message}");
                        }
                    } 
                }
            }catch(Exception e){
                Console.WriteLine($"Exception Occurred {e.Message} gameFunctions");
            }            
            return playerStats;
        }
        public static int parseStrToInt(string value){return Int32.Parse(value);}
        public static string rpsLogic(string choice, string name, int rounds, int wins, int losses, int ties, string gamePath, int prevRounds){
            //1 = rock
            //2 = paper
            //3 = scissors
            try{
                Random rng = new Random();
                int playerChoice = parseStrToInt(choice);

                switch(playerChoice, rng.Next(1,4)){
                    case (1, 1):
                        Console.WriteLine("You chose Rock. The computer chose Rock. It's a tie!");
                        return "You chose Rock. The computer chose Rock. It's a tie!";
                    case (2, 2): 
                        Console.WriteLine("You chose Paper. The computer chose Paper. It's a tie!");
                        return "You chose Paper. The computer chose Paper. It's a tie!";
                    case (3, 3): 
                        Console.WriteLine("You chose Scissors. The computer chose Scissors. It's a tie!");
                        return "You chose Scissors. The computer chose Scissors. It's a tie!";
                    case (1, 2): 
                        Console.WriteLine("You chose Rock. The computer chose Paper. You lose!");
                        return "You chose Rock. The computer chose Paper. You lose!";
                    case (2, 3): 
                        Console.WriteLine("You chose Paper. The computer chose Scissors. You lose!");
                        return "You chose Paper. The computer chose Scissors. You lose!";
                    case (3, 1): 
                        Console.WriteLine("You chose Scissors. The computer chose Rock. You lose!");
                        return "You chose Scissors. The computer chose Rock. You lose!";
                    case (1, 3): 
                        Console.WriteLine("You chose Rock. The computer chose Scissors. You win!");
                        return "You chose Rock. The computer chose Scissors. You win!";
                    case (2, 1): 
                        Console.WriteLine("You chose Paper. The computer chose Rock. You win!");
                        return "You chose Paper. The computer chose Rock. You win!";
                    case (3, 2): 
                        Console.WriteLine("You chose Scissors. The computer chose Paper. You win!");
                        return "You chose Scissors. The computer chose Paper. You win!";
                    default: 
                        Console.WriteLine("A fatal error occurred. Please try again.");
                        Program.againGamePlay(name, rounds, wins, losses, ties, gamePath, prevRounds);
                        break;
                        
                }
            }catch(Exception e){
                Console.WriteLine("Exception occurred. Player input most likely not an integer. Please try again.");
                Console.WriteLine($"{e.Message}");
                Program.againGamePlay(name, rounds, wins, losses, ties, gamePath, prevRounds);
            }
            return "Error occurred. Please try again.";
        }
        public static void scoreBoard(int wins, int losses, int ties){
            Console.WriteLine($"wins: {wins}");
            Console.WriteLine($"losses: {losses}"); 
            Console.WriteLine($"ties: {ties}");
        }
        public static void saveGameLoad(string name, int wins, int losses, int ties, string gamePath){
            try{
                if(gamePath == "newGame"){
                    string newGameData = $"{name},{wins.ToString()},{losses.ToString()},{ties.ToString()}";
                    File.AppendAllText("player_log.csv", newGameData);
                    Console.WriteLine($"{name}, your game has been saved");
                }
                if(gamePath == "loadGame"){
                    using(var checkName = new StreamReader("player_log.csv")){
                        string updateData = "";
                        while(!checkName.EndOfStream){
                            string lineOfData = checkName.ReadLine();
                            if(lineOfData.StartsWith(name)){updateData+=lineOfData.Replace(lineOfData, $"{name},{wins},{losses},{ties}\n");}
                            if(!lineOfData.StartsWith(name)){updateData+=$"{lineOfData}\n";}
                        }
                        checkName.Close();
                        // Console.WriteLine(updateData); debug purposes
                        File.WriteAllText("player_log.csv", updateData);
                    }                    
                    Console.WriteLine($"{name}, your game has been saved");
                }
            }catch(Exception e){
                Console.WriteLine($"Sorry {name}, the game could not be saved.");
                Console.WriteLine(e.Message);
            }
        }



    }
}