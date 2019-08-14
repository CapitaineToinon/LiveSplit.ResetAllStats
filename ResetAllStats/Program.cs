using Steamworks;
using System;
using System.IO;

namespace ResetAllStats
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            args = new string[] { "211420" }; // Dark Souls Prepare To Die Edition
#endif
            if (args.Length == 0)
            {
                return;
            }

            uint appId = Convert.ToUInt32(args[0]);

            if (appId == 0)
            {
                return;
            }

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "steam_appid.txt");

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            using (var tw = new StreamWriter(path, false))
            {
                tw.WriteLine(appId.ToString());
            }


            if (!SteamAPI.IsSteamRunning())
            {
                // steam isn't running so we don't do anything
                return;
            }

            if (!SteamAPI.Init())
            {
                /**
                 * This could happen for a number of reason but probably 
                 * steam_appid.txt not being present or appid being invalid.
                 */
                Console.WriteLine(
                    "[Steamworks.NET] SteamAPI_Init() failed. Refer to Valve's documentation or the comment above this line for more information.");
            }

            if (!SteamUserStats.ResetAllStats(true))
            {
                /**
                 * Please refer to the comment below this line for more information.
                 */
                Console.WriteLine(
                    "[Steamworks.NET] SteamUserStats.ResetAllStats(true) failed. Refer to Valve's documentation or the comment above this line for more information.");
            }

            File.Delete(path);
            SteamAPI.Shutdown();
            Environment.Exit(0);
        }
    }
}
