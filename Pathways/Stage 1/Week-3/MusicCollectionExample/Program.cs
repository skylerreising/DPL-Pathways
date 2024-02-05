using System;

namespace musicCollectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare and instantiate a single Music object using the default constructor
            Music jingleBells = new Music();

            // Output to show the default constructor values
            Console.WriteLine(jingleBells);

            // Declare and instantiate a single Music object using the other constructor
            Music realJingleBells =  new Music("Jingle Bells", 
                                    "Tommie Frazier", 
                                    "8 track");

            // Output to show the default constructor values
            Console.WriteLine(realJingleBells);

            // Declare and instantiate the array of Music objects
            Music[] musicArray = new Music[3];

            // Now, loop through each array element and instantiate a Music object for each.
            // Note that the constructor with no parameters will be used.
            for(int i=0; i<musicArray.Length; i++)
            {
                musicArray[i] = new Music();
            }

            // Load in some test data to test both ways to assign values
            musicArray[0].SongTitle = "Stacey's Mom";
            musicArray[0].SongArtist = "Fountains of Wayne";
            musicArray[0].SongMedia = "CD";
            musicArray[2].SongTitle = "Down With OPP";
            musicArray[2].SongArtist = "Naughty By Nature";
            musicArray[2].SongMedia = "Spotify";
            musicArray[1] = realJingleBells;

            // print each Music to test the property gets and the toString
            for(int i=0; i<musicArray.Length; i++)
            {
                if(!(musicArray[i].SongTitle == null))
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(musicArray[i]);
                    Console.WriteLine(" ");
                }
            }
        }
    }
}