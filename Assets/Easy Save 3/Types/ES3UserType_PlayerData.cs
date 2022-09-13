using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3UserType_PlayerData : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_PlayerData() : base(typeof(PlayerData)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (PlayerData)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (PlayerData)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
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