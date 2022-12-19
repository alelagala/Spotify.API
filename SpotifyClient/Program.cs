using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Linq;
using Utility.Read;



namespace SpotifyClient
{
    class Program
    {
        //static HttpClient client = new HttpClient();




        static void Main()
        {
            UserInterface.SourceSelectionInterface();
            var data = DataStore.GetInstance();
            Console.WriteLine();
            UserInterface.Router("h");
        }



    }
}
