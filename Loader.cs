using System;
using System.Windows.Forms;
using Grimoire.Networking;
using Grimoire.Tools;
using Grimoire.Tools.Plugins;

namespace AutoAggro
{
    [GrimoirePluginEntry]
    public class Loader : IGrimoirePlugin
    {
        public static string Version => "1.0.0";
        public string Author => "dnlkus";

        public string Description => "Auto aggro monster if any player in it's cell";

        private ToolStripItem menuItem;

        public void Load()
        {
            // Add an item to the main menu in Grimoire.
            menuItem = Grimoire.UI.Root.Instance.MenuMain.Items.Add("Auto Aggro");
            menuItem.Click += MenuStripItem_Click;
        }

        public void Unload() // In this method you need to clean everything up
        {
            menuItem.Click -= MenuStripItem_Click;
            Grimoire.UI.Root.Instance.MenuMain.Items.Remove(menuItem);
            AutoAggro.Instance.Dispose();
        }

        private void MenuStripItem_Click(object sender, EventArgs e)
        {
            if (AutoAggro.Instance.Visible)
            {
                if (AutoAggro.Instance.WindowState == FormWindowState.Minimized)
                    AutoAggro.Instance.WindowState = FormWindowState.Normal;
                AutoAggro.Instance.Hide();
            }
            else
            {
                AutoAggro.Instance.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                AutoAggro.Instance.Location = new System.Drawing.Point((Grimoire.UI.Root.Instance.Location.X + Grimoire.UI.Root.Instance.Width / 2) - 
                    (AutoAggro.Instance.Width / 2), (Grimoire.UI.Root.Instance.Location.Y + Grimoire.UI.Root.Instance.Height / 2) - (AutoAggro.Instance.Height / 2));
                AutoAggro.Instance.Show(Grimoire.UI.Root.Instance);
                AutoAggro.Instance.BringToFront();
            }
        }
    }
}
