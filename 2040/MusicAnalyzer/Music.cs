using System;

namespace MusicAnalyzer
{
    public class Music
    {
        private string name, artist, album, genre;
        private int size, time, year, plays;

        public Music(string name, string artist, string album, string genre, int size, int time, int year, int plays){
            this.name = name;
            this.artist = artist;
            this.album = album;
            this.genre = genre;
            this.size = size;
            this.time = time;
            this.year = year;
            this.plays = plays;
        }

        public string getName(){return this.name;}
        public string getArtist(){return this.artist;}
        public string getAlbum(){return this.album;}
        public string getGenre(){return this.genre;}
        public int getSize(){return this.size;}
        public int getTime(){return this.time;}
        public int getYear(){return this.year;}
        public int getPlays(){return this.plays;}
    }
    
}