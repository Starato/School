using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Please enter filepath: ");
            string filePath = Console.ReadLine();
            //Data
            List<Music> musicList = musicDataLoader.parseData(fileFilter(filePath));

            Console.WriteLine("Music Playlist Report");

            //How many songs received 200 or more plays?
            var moreThan200Plays = from music in musicList where music.getPlays() >= 200 select music;
            Console.WriteLine(" \nSongs that received 200 or more plays:");
            foreach(var more200 in moreThan200Plays){
                Console.WriteLine($"Name: {more200.getName()}, Artist: {more200.getArtist()}, Album: {more200.getAlbum()}, Genre: {more200.getGenre()}, Size: {more200.getSize()}, Time: {more200.getTime()}, Year: {more200.getYear()}, Plays: {more200.getPlays()}");
            }

            //How many songs are in the playlist with the Genre of "Alternative"?
            var alternative = from music in musicList where music.getGenre() == "Alternative" select music;
            int nAlternative = 0;
            foreach(var alt in alternative){nAlternative+=1;}
            Console.WriteLine($" \nNumber of Alternative songs: {nAlternative}");

            //How many songs are in the playlist with the genre of hiphop
            var hiphop = from music in musicList where music.getGenre() == "Hip-Hop/Rap" select music;
            int hiphoprap = 0;
            foreach(var hhr in hiphop){hiphoprap+=1;}
            Console.WriteLine($" \nNumber of Hip-Hop/Rap songs: {hiphoprap+=1}");

            //What songs are in the playlist from the album "Welcome to the longSongbowl?"
            Console.WriteLine(" \nWhat songs are in the playlist from the album 'Welcome to the Fishbowl?'");
            var fishbowl = from music in musicList where music.getAlbum() == "Welcome to the Fishbowl" select music;
            foreach(var fish in fishbowl){Console.WriteLine($"Name: {fish.getName()}, Artist: {fish.getArtist()}, Album: {fish.getAlbum()}, Genre: {fish.getGenre()}, Size: {fish.getSize()}, Time: {fish.getTime()}, Year: {fish.getYear()}, Plays: {fish.getPlays()}");}

            //What are the songs in the playlist from before 1970?
            Console.WriteLine(" \nWhat are the songs in the playlist from before 1970?");
            var before1970 = from music in musicList where music.getYear() < 1970 select music;
            foreach(var before in before1970){Console.WriteLine($"Name: {before.getName()}, Artist: {before.getArtist()}, Album: {before.getAlbum()}, Genre: {before.getGenre()}, Size: {before.getSize()}, Time: {before.getTime()}, Year: {before.getYear()}, Plays: {before.getPlays()}");}

            //Songs names longer than 85 characters
            Console.WriteLine(" \nSongs names longer than 85 characters");
            var greater85char = from music in musicList where music.getName().Length > 85 select music.getName();
            foreach(var chars in greater85char){Console.WriteLine($"{chars}");}

            //Longest song in time
            Console.WriteLine(" \nLongest song (in time)");
            var longestSong = (from music in musicList select music.getTime()).Max();
            var getLongSongName = from music in musicList where music.getTime() == longestSong select music;
            foreach(var longSong in getLongSongName){Console.WriteLine($"Name: {longSong.getName()}, Artist: {longSong.getArtist()}, Album: {longSong.getAlbum()}, Genre: {longSong.getGenre()}, Size: {longSong.getSize()}, Time: {longSong.getTime()}, Year: {longSong.getYear()}, Plays: {longSong.getPlays()}");}

            //What are the uniue Genre in the playlist
            Console.WriteLine(" \n*\\*/*\\*/*\\*/*\\*/*\\*");
            Console.WriteLine("Unique Genres:");
            var uniqueGenre = (from music in musicList select music.getGenre()).Distinct();
            foreach(var unique in uniqueGenre){Console.WriteLine(unique);}

            //How many songs were produced each year in the playlist?
            Console.WriteLine(" \nHow many songs were produced each year in the playlist?");
            var songsProducedEachYear = (from music in musicList orderby music.getYear() descending select music.getYear()).Distinct();
            foreach(var songsEachYear in songsProducedEachYear){
                var searchEachYear = (from music in musicList where music.getYear() == songsEachYear select music).Count();
                Console.WriteLine($"{songsEachYear}: {searchEachYear}");
            }

            //What are the total plays per year in the playlist?
            Console.WriteLine(" \nWhat are the total plays per year in the playlist?");
            foreach(var yearPlays in songsProducedEachYear){
                var playsPerYear = (from music in musicList where music.getYear() == yearPlays select music.getPlays()).Sum();
                Console.WriteLine($"{yearPlays}: {playsPerYear}");
            }

            //Print a list of the unique artists in the playlist?
            Console.WriteLine(" \nUnique Artists:");
            var uniqueArtists = (from music in musicList select music.getArtist()).Distinct();
            foreach(var uniqueArti in uniqueArtists){Console.WriteLine($"{uniqueArti}");}
        }

        static string fileFilter(string filePath){
            if(!filePath.EndsWith(".txt")){return filePath+".txt";}
            return filePath;
        }
    }
}
