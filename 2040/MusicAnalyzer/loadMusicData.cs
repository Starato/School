using System;
using System.IO;
using System.Collections.Generic;

namespace MusicAnalyzer
{
    public class musicDataLoader
    {
        public static List<Music> parseData(string filePath)
        {
            List<Music> musicData = new List<Music>();
            try{
                using (var musicReader = new StreamReader(filePath)){
                    string lineOfData = musicReader.ReadLine();
                    

                    while(!musicReader.EndOfStream){
                        lineOfData = musicReader.ReadLine();
                        var values = lineOfData.Split('\t');

                        try{
                            string name = values[0];
                            string artist = values[1];
                            string album = values[2];
                            string genre = values[3];
                            int size = stringToInt(values[4]);
                            int time = stringToInt(values[5]);
                            int year = stringToInt(values[6]);
                            int plays = stringToInt(values[7]);

                            Music musicList = new Music(name, artist, album, genre, size, time, year, plays);
                            musicData.Add(musicList);
                        }catch(Exception e){throw new Exception($"Exception Occurred: please try again {e.Message}");}
                    }
                }
            }catch(Exception e){
                throw new Exception($"There was an error reading the file: {e.Message}");
            }
            return musicData;
        }
    private static int stringToInt(string values){return Int32.Parse(values);}

    }
}