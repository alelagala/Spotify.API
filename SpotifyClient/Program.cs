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
        static void Main()
        {
            UserInterface.SourceSelectionInterface();            
            UserInterface.Router("h");
        }
    }
}
