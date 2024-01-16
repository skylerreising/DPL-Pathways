using System;

namespace musicCollectionApp
{

    class Music
    {
        //Properties with get/set methods
        public string SongTitle { get; set; }
        public string SongArtist { get; set; }
        public string SongMedia { get; set; }

        //Default constructor
        public Music()
        {
            SongTitle = null;
            SongArtist = null;
            SongMedia = null;
        }

        //Constructor when ingredients and directions are passed in
        public Music (string songTitle, string songArtist, string songMedia)
        {
            SongTitle = songTitle;
            SongArtist = songArtist;
            SongMedia = songMedia;
        }

        //ToString method for this class
        public override string ToString()
        {
            return $"Artist: {SongArtist}\nTitle: {SongTitle}\nFormat: {SongMedia}";
        }
    }//end of class
}//end of namespace