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

		private string MapNameNow;
		public AutoAggro()
		{
			InitializeComponent();
			//cbAutoRefreshMap.Checked = true;
			cbAutoAggro.Enabled = false;
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
                
                if (jsonMessage != null)
				{

                    if (jsonMessage.DataObject?["areaName"] != null)
					{
						string areaName = (string)jsonMessage.DataObject["areaName"];
						areaName = areaName.Split('-')[0];
                        txtMapName.Text = areaName;
                        if (MapNameNow.ToLower() != areaName.ToLower())
						{
							cbAutoAggro.Enabled = false;
							cbAutoAggro.Checked = false;
						}
					}
				}
			}
			catch (Exception e)
			{
				debug($"e: {e}");
			}
		}

		private void debug(string text)
		{
			LogForm.Instance.AppendDebug($"[auto aggro] {text}");
		}

		private string monsterInfo;
        private async void btnGetMonsterInfo_Click(object sender, EventArgs e)
        {
            btnGetMonsterInfo.Enabled = false;
            txtMapName.Text = Player.Map;
			MapNameNow = Player.Map.ToLower();
            Dictionary<string, List<Monster>> cellMonster = new Dictionary<string, List<Monster>>();

            foreach (string cl in World.Cells)
            {
				if (cl.ToLower().Contains("cut") || cl.ToLower() == "wait" || cl.ToLower() == "blank")
                    continue;
                CmdMoveToCell playerMove = new CmdMoveToCell
                {
                    Cell = cl,
                    Pad = "Spawn"
                };
				
                await playerMove.Execute(Grimoire.Botting.Bot.Instance);
                cellMonster[cl] = World.AvailableMonsters;
            }
            monsterInfo = JsonConvert.SerializeObject(cellMonster);
            //string returnMonster = JsonConvert.SerializeObject(cellMonster);


            //CmdSetVar setVar = new CmdSetVar
            //{
            //    Value1 = "CmdSetMonstersCells",
            //    Value2 = returnMonster
            //};
            //await setVar.Execute(Grimoire.Botting.Bot.Instance);
            cbAutoAggro.Enabled = true;
            btnGetMonsterInfo.Enabled = true;
        }

        private async void cbAutoAggro_CheckedChanged(object sender, EventArgs e)
        {
			int checkAggroEvery = 3;
			int aggroCount = 0;
            if (cbAutoAggro.Checked)
			{
				btnGetMonsterInfo.Enabled = false;
				numAggroDelay.Enabled = false;
                while (cbAutoAggro.Checked)
                {
					aggroCount = 0;
					// JObject monsInfo = JObject.Parse(Configuration.Tempvariable["CmdSetMonstersCells"]);
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
									foreach (var mon in property.Value)
									{
										monIdSet.Add($"{mon["MonMapID"]}");
									}
									break;
								}
							}

						}
					}
					string packet = $"{baseAggro}{String.Join("%", monIdSet)}%";
					txtTest.Text = packet;
					while(aggroCount <= checkAggroEvery && packet != "%xt%zm%aggroMon%0%%")
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
				btnGetMonsterInfo.Enabled = true;
            }
        }

    }
}
