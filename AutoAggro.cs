using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using Grimoire.Game;
using Grimoire.Networking;
using DarkUI.Forms;
using Grimoire.Tools;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Grimoire.UI;
using Grimoire.Game.Data;
using System.Linq;
using System.Collections.Generic;
using Grimoire.Botting.Commands.Map;
using Grimoire.Botting.Commands.Misc.Statements;
using Grimoire.Botting;
using DarkUI.Controls;

namespace AutoAggro
{
	public partial class AutoAggro : DarkForm
	{
		public static AutoAggro Instance { get; } = new AutoAggro();

        private string monsterInfo;
        public AutoAggro()
		{
			InitializeComponent();
            Flash.FlashCall += new FlashCallHandler(this.MapChangeHandler);
            if (Player.IsLoggedIn) txtMapName.Text = Player.Map;

			this.Text = $"Auto Aggro {Loader.Version}";
		}

		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				Hide();
			}
		}

        private Grimoire.Networking.Message CreateMessage(string raw)
		{
			if (raw != null && raw.Length > 0)
			{
				switch (raw[0])
				{
					case '%':
						return new XtMessage(raw);
					case '<':
						return new XmlMessage(raw);
					case '{':
						return new JsonMessage(raw);
				}
			}

			return null;
		}

		private void MapChangeHandler(AxShockwaveFlashObjects.AxShockwaveFlash flash, string function, params object[] args)
		{
			if (function != "packetFromServer") return;
			try
			{
				Grimoire.Networking.Message message = CreateMessage((string)args[0]);
				JsonMessage jsonMessage = message as JsonMessage;
				string s = jsonMessage?.ToString();
                dynamic jsonObject = JsonConvert.DeserializeObject(s);
                Dictionary<string, List<string>> groupedMonmap = new Dictionary<string, List<string>>();
                foreach (var monmapItem in jsonObject.b.o.monmap)
                {
                    string MonMapID = monmapItem.MonMapID;
                    string strFrame = monmapItem.strFrame;

					debug($"MonMapID: {MonMapID}, strFrame: {strFrame}");
                    if (!groupedMonmap.ContainsKey(strFrame))
                    {
                        groupedMonmap[strFrame] = new List<string>();
                    }

                    groupedMonmap[strFrame].Add(MonMapID);
                }
                monsterInfo = JsonConvert.SerializeObject(groupedMonmap);
				debug(monsterInfo);
                if (jsonMessage != null)
				{
                    if (jsonMessage.DataObject?["strMapName"] != null)
					{
						string areaName = (string)jsonMessage.DataObject["strMapName"];
                        txtMapName.Text = areaName;
					}
                }
				
            }
			catch (Exception e)
			{
				//debug($"e: {e}");
			}
		}

		private void debug(string text)
		{
			LogForm.Instance.AppendDebug($"[auto aggro] {text}");
		}

		

        private async void cbAutoAggro_CheckedChanged(object sender, EventArgs e)
        {
			int checkAggroEvery = 3;
			int aggroCount = 0;
			try
			{
                if (cbAutoAggro.Checked)
                {
                    numAggroDelay.Enabled = false;
                    while (cbAutoAggro.Checked)
                    {
                        aggroCount = 0;
                        JObject monsInfo = JObject.Parse(monsterInfo);
                        List<string> playerInMap = World.PlayersInMap;
                        HashSet<string> monIdSet = new HashSet<string>();
                        string baseAggro = "%xt%zm%aggroMon%0%";
                        foreach (var property in monsInfo.Properties())
                        {
                            if (property.Value is JArray)
                            {
                                foreach (string pl in playerInMap)
                                {
                                    string reqs = Flash.Call<string>("CheckCellPlayer", new string[] {
                                        pl,
                                        property.Name
                                    });
                                    if (bool.Parse(reqs))
                                    {
                                        foreach (var monmapid in property.Value)
                                        {
                                            monIdSet.Add($"{monmapid}");
                                        }
                                        break;
                                    }
                                }

                            }
                        }
                        string packet = $"{baseAggro}{String.Join("%", monIdSet)}%";
                        txtAggroText.Text = packet;
                        while (aggroCount <= checkAggroEvery && packet != "%xt%zm%aggroMon%0%%")
                        {
                            await Proxy.Instance.SendToServer(packet);
                            await Task.Delay(500);
                            aggroCount++;
                        }

                    }
                }
                else
                {
                    numAggroDelay.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                cbAutoAggro.Checked = false;
                txtAggroText.Text = "Please rejoin";
            }
            
        }

    }
}
