using RailwayPortalClassLibrary;
using System.Collections;
using System.Net.Http;

namespace TCH2_WestSiberianRailway.Modules.Interfaces
{
    public interface ITCH2_WSR_WebClient
    {
        User Send<T>(HttpMethod method, string path, params object[] args);
        SessionModel Get<T>(string path);
        string Send(string path);
    }
}
