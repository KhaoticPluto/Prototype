using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("_levelSystem", "_upgradeables", "TutorialComplete")]
	public class ES3UserType_PlayerData : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_PlayerData() : base(typeof(PlayerData)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (PlayerData)obj;
			
			writer.WritePropertyByRef("_levelSystem", instance._levelSystem);
			writer.WritePropertyByRef("_upgradeables", instance._upgradeables);
			writer.WriteProperty("TutorialComplete", PlayerData.TutorialComplete, ES3Type_int.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (PlayerData)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "_levelSystem":
						instance._levelSystem = reader.Read<LevelSystem>(ES3UserType_LevelSystem.Instance);
						break;
					case "_upgradeables":
						instance._upgradeables = reader.Read<Upgradeables>();
						break;
					case "TutorialComplete":
						PlayerData.TutorialComplete = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_PlayerDataArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_PlayerDataArray() : base(typeof(PlayerData[]), ES3UserType_PlayerData.Instance)
		{
			Instance = this;
		}
	}
}