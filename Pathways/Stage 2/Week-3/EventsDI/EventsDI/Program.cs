using System;

namespace EventsDI
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger loggerFileDatabase = new DataBaseLogger();
            ILogger loggerFilePapyrus = new PapyrusLogger();

            string smithWedding = "Smith Wedding 2/22/24";
            string johnsonWedding = "Johnson Wedding 2/23/24";
            string mohammedWedding = "Mohammed Wedding 2/24/24";
            string tranWedding = "Tran Wedding 2/25/24";
            string garciaWedding = "Garcia Wedding 2/26/24";

            EventService DatabaseService = new EventService(loggerFileDatabase);
            DatabaseService.Log(smithWedding);
            DatabaseService.Log(johnsonWedding);
            DatabaseService.Log(mohammedWedding);
            DatabaseService.Log(tranWedding);
            DatabaseService.Log(garciaWedding);


            EventService PapyrusService = new EventService(loggerFilePapyrus);
            PapyrusService.Log(smithWedding);
            PapyrusService.Log(johnsonWedding);
            PapyrusService.Log(mohammedWedding);
            PapyrusService.Log(tranWedding);
            PapyrusService.Log(garciaWedding);

        }
    }
}