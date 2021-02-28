using RailwayPortalClassLibrary;
using TCH2_WestSiberianRailway.Modules.Interfaces;

namespace TCH2_WestSiberianRailway.Modules.Implementation
{
    public class TCH2_WSR_WebClient : AppWebClient, ITCH2_WSR_WebClient
    {
        public TCH2_WSR_WebClient() : base("https://localhost:44312")
        { }
    }
}
