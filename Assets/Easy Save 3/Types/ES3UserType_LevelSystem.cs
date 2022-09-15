using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("level", "currentXp", "EXPpoints", "additionMultiplier", "powerMultiplier", "divisionMultiplier")]
	public class ES3UserType_LevelSystem : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_LevelSystem() : base(typeof(LevelSystem)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (LevelSystem)obj;
			
			writer.WriteProperty("level", instance.level, ES3Type_int.Instance);
			writer.WriteProperty("currentXp", instance.currentXp, ES3Type_float.Instance);
			writer.WriteProperty("EXPpoints", instance.EXPpoints, ES3Type_float.Instance);
			writer.WriteProperty("additionMultiplier", instance.additionMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("powerMultiplier", instance.powerMultiplier, ES3Type_float.Instance);
			writer.WriteProperty("divisionMultiplier", instance.divisionMultiplier, ES3Type_float.Instance);
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
					case "currentXp":
						instance.currentXp = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "EXPpoints":
						instance.EXPpoints = reader.Read<System.Single>(ES3Type_float.Instance);
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