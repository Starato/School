using System;
using System.Collections.Generic;
using System.Linq;

namespace Final_Project
{
    public class Program
    {
        static void Main(string[] args)
        {
            mainMenu();   
        }
        public static void mainMenu(){

            Console.WriteLine("Welcome to Rock, Paper, Scissors!");
            Console.WriteLine(" \n\t1. Start New Game");
            Console.WriteLine("\t2. Load Game");
            Console.WriteLine("\t3. Quit");
            Console.WriteLine("Enter choice:");//separate this to function
            string choice = Console.ReadLine();
            switch(choice){
                case "1":
                    newGame();
                    break;
                case "2":
                    loadGame();
                    break;
                case "3":
                    Console.WriteLine("Good bye!");
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Did not pick 1-3. Try again.");
                    mainMenu();
                    break;
            }
        }
        static void newGame(){
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();

            //check if name exists
            List<playerData> playerStats = gameFunctions.parsePlayerData();
            var checkName = from player in playerStats where player.getName() == name select player;
            if(checkName.Any()){Console.WriteLine($"Sorry, {name} is taken, please try again"); mainMenu();}

            Console.WriteLine($" \nHello {name}. Let's play!");
            //start other functions and send relevant data
            string gamePath = "newGame";
            gamePlay(name, 1, 0, 0, 0, gamePath, 0);
            gameFunctions.scoreBoard(0, 0, 0);
        }
        static void loadGame(){
            string gamePath = "loadGame";
            //ask name
            Console.WriteLine("What is your name? ");
            string loadName = Console.ReadLine();
            List<playerData> playerStats = gameFunctions.parsePlayerData();
            var checkName = from player in playerStats where player.getName() == loadName select player;
            //checks if query returns any results
            if(checkName.Any()){
                Console.WriteLine($"Welcome back {loadName}, Let's play!");//noun = class, adjective = method | generally
                foreach(var player in checkName){
                    int prevRounds = 0 + player.getWins() + player.getLosses() + player.getTies();
                    gamePlay(loadName, 1, player.getWins(), player.getLosses(), player.getTies(), gamePath, prevRounds);
                }
            }
            if(!checkName.Any()){
                Console.WriteLine("Name not found. Please start a new game.");
                mainMenu();
            }
        }
        static void gamePlay(string name, int rounds, int wins, int losses, int ties, string gamePath, int prevRounds){
            Console.WriteLine($" \nRound {rounds+prevRounds}");
            Console.WriteLine($" \n\t1. Rock");
            Console.WriteLine($" \t2. Paper");
            Console.WriteLine($" \t3. Scissors");
            Console.WriteLine($" \nWhat will it be?");
            string choice = Console.ReadLine();
            //sends user choice to game logic
            string response = gameFunctions.rpsLogic(choice, name, rounds, wins, losses, ties, gamePath, prevRounds);
            //Scoreboard and passing relevant data and add one to each scenario
            if(response.EndsWith("tie!")){
                gameFunctions.scoreBoard(wins, losses, ties+1); 
                againGamePlay(name, rounds+1, wins, losses, ties+1, gamePath, prevRounds);
            }
            if(response.EndsWith("lose!")){
                gameFunctions.scoreBoard(wins, losses+1, ties); 
                againGamePlay(name, rounds+1, wins, losses+1, ties, gamePath, prevRounds);
            }
            if(response.EndsWith("win!")){
                gameFunctions.scoreBoard(wins+1, losses, ties); 
                againGamePlay(name, rounds+1, wins+1, losses, ties, gamePath, prevRounds);
            }
        }
        public static void againGamePlay(string name, int rounds, int wins, int losses, int ties, string gamePath, int prevRounds){
            Console.WriteLine(" \nWhat would you like to do?");
            Console.WriteLine(" \n\t1. Play Again");
            Console.WriteLine(" \t2. View Player Statistics");
            Console.WriteLine(" \t3. View Leaderboard");
            Console.WriteLine(" \t4. Quit");
            try{
                int chooseAgainGamePlay = gameFunctions.parseStrToInt(Console.ReadLine());
                switch(chooseAgainGamePlay){
                    case 1:
                        gamePlay(name, rounds, wins, losses, ties, gamePath, prevRounds); 
                        break;
                    case 2:
                        viewStatistics(name, rounds, wins, losses, ties, gamePath, prevRounds);
                        break;
                    case 3:
                        viewLeaderboard(name, rounds, wins, losses, ties, gamePath, prevRounds);
                        break;
                    case 4:
                        gameFunctions.saveGameLoad(name, wins, losses, ties, gamePath);
                        Console.WriteLine("Good bye!");
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("You didn't press 1-4, try again.");
                        againGamePlay(name, rounds, wins, losses, ties, gamePath, prevRounds);
                        break;
                }
            }catch(Exception e){
                Console.WriteLine($"Exception occurred in Again Game Play menu. Input most likely not an integer. Please try again");
                Console.WriteLine($"{e.Message}");
            }
        }
        static void viewLeaderboard(string name, int rounds, int wins, int losses, int ties, string gamePath, int prevRounds){
            List<playerData> playerStats = gameFunctions.parsePlayerData();

            Console.WriteLine("Global Game Statistics");
            Console.WriteLine("-----------------------");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Top 10 Winning Players");
            Console.WriteLine("-----------------------");
            //get top ten wins and corresponding player name
            var top10Players = (from player in playerStats orderby player.getWins() descending select player).Take(10);
            foreach(var top in top10Players){Console.WriteLine($"{top.getName()}: {top.getWins()}");}

            //Look through query and get top 5 total games. getTotalGames = class property
            Console.WriteLine(" \n-----------------------");
            Console.WriteLine("Most Games Played");
            Console.WriteLine("-----------------------");
            var getPlayers = (from player in playerStats orderby player.getTotalGames() descending select player).Take(5);
            foreach(var players in getPlayers){
                Console.WriteLine($"{players.getName()}: {players.getTotalGames()} games played");
            }

            //Look for total wins and losses and get kda
            Console.WriteLine(" \n-----------------------");
            double totalWins = (from player in playerStats select player.getWins()).Sum();
            double totalLoss = (from player in playerStats select player.getLosses()).Sum();
            double wlRatio = (totalWins+wins)/(totalLoss+losses);
            Console.WriteLine($"Win/Loss Ratio: {Math.Round(wlRatio, 2)}");
            Console.WriteLine("-----------------------");

            //get total games played
            Console.WriteLine(" \n-----------------------");
            var totalGamesPlayed = from player in playerStats select player.getTotalGames();
            int totalGames = 0;
            foreach(var games in totalGamesPlayed){totalGames += games;}
            Console.WriteLine($"Total Games Played: {totalGames+rounds-1}");
            Console.WriteLine("-----------------------");
            //give the option to play game again while keeping relevant data
            againGamePlay(name, rounds, wins, losses, ties, gamePath, prevRounds);

        }
        static void viewStatistics(string name, int rounds, int wins, int losses, int ties, string gamePath, int prevRounds){
            List<playerData> playerStats = gameFunctions.parsePlayerData();
            Console.WriteLine($"{name}, here are your game play statistics...");
            var personalStats = from player in playerStats where player.getName() == name select player;
            gameFunctions.scoreBoard(wins, losses, ties);
            againGamePlay(name, rounds, wins, losses, ties, gamePath, prevRounds);
        }
    }   
}
