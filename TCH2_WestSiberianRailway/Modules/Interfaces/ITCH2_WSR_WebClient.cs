using RailwayPortalClassLibrary;
using System.Net.Http;

namespace TCH2_WestSiberianRailway.Modules.Interfaces
{
    public interface ITCH2_WSR_WebClient
    {
        User Send<T>(HttpMethod method, string path, params object[] args);
        SessionModel Get<T>(string path);
    }
}
