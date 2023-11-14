namespace ShopTARge22.Models.AccuWeather
{
    public class OpenAccuWeatherViewModel
    {
		public string ID { get; set; }
		public string LocalizedName { get; set; }
		public string EnglishName { get; set; }
		public int Level { get; set; }
		public string LocalizedType { get; set; }
		public string EnglishType { get; set; }
		public string CountryID { get; set; }
		public string Metric { get; set; }
		public string Imperial { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string Elevation { get; set; }
		public int Value { get; set; }
		public string Unit { get; set; }
		public int UnitType { get; set; }
		public int Version { get; set; }
		public string Key { get; set; }
		public string Type { get; set; }
		public int Rank { get; set; }
		public string PrimaryPostalCode { get; set; }
		public string Region { get; set; }
		public string Country { get; set; }
		public string AdministrativeArea { get; set; }
		public TimeZone TimeZone { get; set; }
		public string GeoPosition { get; set; }
		public bool IsAlias { get; set; }
		public List<string> SupplementalAdminAreas { get; set; }
		public List<string> DataSets { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public int GmtOffset { get; set; }
		public bool IsDaylightSaving { get; set; }
		public DateTime NextOffsetChange { get; set; }
	}
}

