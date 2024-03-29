﻿using System.Xml;
using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System.Windows.Forms;
using System;
using LiveSplit.ResetAllStats.UI;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading.Tasks;

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

        private async void _state_OnStart(object sender, EventArgs e)
        {
            //Run the .exe async so that it does not block livesplit
            await Task.Run(() =>
            {
                uint appId = this._settings.AppId;

                if (appId == 0)
                {
                    return;
                }

                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Components\\ResetAllStats.exe");

                try
                {
                    if (!File.Exists(path))
                    {
                        object ob = Properties.Resources.ResourceManager.GetObject("ResetAllStats");
                        byte[] myResBytes = (byte[])ob;

                        using (FileStream fsDst = new FileStream(path, FileMode.CreateNew, FileAccess.Write))
                        {
                            byte[] bytes = myResBytes;
                            fsDst.Write(bytes, 0, bytes.Length);
                            fsDst.Close();
                            fsDst.Dispose();
                        }
                    }

                    /**
                     * Starts process without stealing focus
                     */
                    Process p = new Process();
                    p.StartInfo = new ProcessStartInfo(path, appId.ToString());
                    p.StartInfo.WorkingDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Components");
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.UseShellExecute = false;
                    p.Start();

                    //Deleting the file further ahead is not possible when the .exe is still running. this will actually prevent timers from starting.
                    //thats why we must wait for the process to exit
                    p.WaitForExit(10000);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Failed to start ResetAllStats.exe. {ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    File.Delete(path);
                }
            });
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
