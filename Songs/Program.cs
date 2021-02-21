using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();
            for(int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split("_");
                string typeList = input[0];
                string name = input[1];
                string time = input[2];

                Song song = new Song();
                song.TypeList = typeList;
                song.Name = name;
                song.Time = time;
                songs.Add(song);
            }

            string targetListType = Console.ReadLine();
            
            //1st example
            foreach(Song currentSong in songs)
            {
                if(currentSong.TypeList == targetListType)
                {
                    Console.WriteLine(currentSong.Name);
                }
            }

            //2nd example
            songs = songs.FindAll(x => x.TypeList == targetListType);
            foreach (Song currentSong in songs)
            {
                Console.WriteLine(currentSong.Name); 
            }

            //3rd example
            songs.Where(x => x.TypeList == targetListType).ToList().ForEach(x => Console.WriteLine(x.Name));


        }
    }

    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}
