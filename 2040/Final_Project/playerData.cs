namespace Final_Project
{
    public class playerData
    {
        private string name;
        private int wins, losses, ties;

        public playerData(string name, int wins, int losses, int ties){
            this.name = name;
            this.wins = wins;
            this.losses = losses;
            this.ties = ties;
        }

        public string getName(){return this.name;}
        public int getWins(){return this.wins;}
        public int getLosses(){return this.losses;}
        public int getTies(){return this.ties;}
        public int getTotalGames(){return this.wins + this.losses + this.ties;}
    }
}