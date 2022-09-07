using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("level", "maxLevel", "currentXp", "nextLevelXp", "additionMultiplier", "powerMultiplier", "divisionMultiplier", "levelUpEffect", "frontXpBar", "backXpBar", "levelText", "XpText")]
	public class ES3UserType_LevelSystem : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_LevelSystem() : base(typeof(LevelSystem)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (LevelSystem)obj;
			
			writer.WriteProperty("level", instance.level, ES3Type_int.Instance);
			writer.WriteProperty("maxLevel", instance.maxLevel, ES3Type_float.Instance);
			writer.WriteProperty("currentXp", instance.currentXp, ES3Type_float.Instance);
			writer.WriteProperty("nextLevelXp", instance.nextLevelXp, ES3Type_int.Instance);
			writer.WriteProperty("additionMultiplier", instance.additionMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("powerMultiplier", instance.powerMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("divisionMultiplier", instance.divisionMultiplier, ES3Type_float.Instance);
			writer.WritePropertyByRef("levelUpEffect", instance.levelUpEffect);
			writer.WritePropertyByRef("frontXpBar", instance.frontXpBar);
			writer.WritePropertyByRef("backXpBar", instance.backXpBar);
			writer.WritePropertyByRef("levelText", instance.levelText);
			writer.WritePropertyByRef("XpText", instance.XpText);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (LevelSystem)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "level":
						instance.level = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "maxLevel":
						instance.maxLevel = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "currentXp":
						instance.currentXp = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "nextLevelXp":
						instance.nextLevelXp = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "additionMultiplier":
						instance.additionMultiplier = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "powerMultiplier":
						instance.powerMultiplier = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "divisionMultiplier":
						instance.divisionMultiplier = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "levelUpEffect":
						instance.levelUpEffect = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "frontXpBar":
						instance.frontXpBar = reader.Read<UnityEngine.UI.Image>(ES3Type_Image.Instance);
						break;
					case "backXpBar":
						instance.backXpBar = reader.Read<UnityEngine.UI.Image>(ES3Type_Image.Instance);
						break;
					case "levelText":
						instance.levelText = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					case "XpText":
						instance.XpText = reader.Read<TMPro.TextMeshProUGUI>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_LevelSystemArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_LevelSystemArray() : base(typeof(LevelSystem[]), ES3UserType_LevelSystem.Instance)
		{
			Instance = this;
		}
	}
}