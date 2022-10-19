using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_MUSIC.Models
{
    public class MusicModel
    {
        

    public MusicModel(Music music)
    {
         
        ID_Music = music.ID_Music;
        Name = music.Name;
        Executor = music.Executor;
        Genre = music.Genre;
        Duration = music.Duration;
        Image = music.Image;

    }

   
    
        public int ID_Music { get; set; }
        public string Name { get; set; }
        public string Executor { get; set; }
        public string Genre { get; set; }
        public string Duration { get; set; }
        public string Image { get; set; }
    
}
}