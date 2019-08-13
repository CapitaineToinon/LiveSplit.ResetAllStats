using System.Xml;
using Steamworks;
using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System.Windows.Forms;
using System;
using LiveSplit.ResetAllStats.UI;
using System.IO;

namespace LiveSplit.ResetAllStats
{
    public class RASComponent : LogicComponent
    {
        private LiveSplitState _state;
        private RASSettings _settings;

        public override string ComponentName => "Reset All Stats for a specific steam game";

        public RASComponent(LiveSplitState state)
        {
            this._settings = new RASSettings();
            this._state = state;
            this._state.OnStart += _state_OnStart;
        }

        private void _state_OnStart(object sender, EventArgs e)
        {
            uint appId = this._settings.AppId;

            if (appId == 0)
            {
                return;
            }

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "steam_appid.txt");

            if (!File.Exists(path))
            {
                File.Create(path);
                TextWriter tw = new StreamWriter(path);
                tw.WriteLine(appId.ToString());
                tw.Close();
            }
            else
            {
                using (var tw = new StreamWriter(path, false))
                {
                    tw.WriteLine(appId.ToString());
                }
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
                MessageBox.Show(
                    "[Steamworks.NET] SteamAPI_Init() failed. Refer to Valve's documentation or the comment above this line for more information.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (!SteamUserStats.ResetAllStats(true))
            {
                /**
                 * Please refer to the comment below this line for more information.
                 */ 
                MessageBox.Show(
                    "[Steamworks.NET] SteamUserStats.ResetAllStats(true) failed. Refer to Valve's documentation or the comment above this line for more information.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            SteamAPI.Shutdown();
        }

        public override void Dispose()
        {
            // Empty
        }

        public override XmlNode GetSettings(XmlDocument document)
        {
            return this._settings.GetSettings(document);
        }

        public override System.Windows.Forms.Control GetSettingsControl(LayoutMode mode)
        {
            return this._settings;
        }

        public override void SetSettings(XmlNode settings)
        {
            this._settings.SetSettings(settings);
        }

        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            // Empty
        }
    }
}
