namespace QuickType
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Energy
    {
        [JsonProperty("data_year")]
        public string DataYear { get; set; }

        [JsonProperty("id")]

        public Int32 Id { get; set; }

        [JsonProperty("property_name")]
        public string PropertyName { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("zip_code")]
        
        public string ZipCode { get; set; }

        [JsonProperty("community_area")]
        public string CommunityArea { get; set; }

        [JsonProperty("primary_property_type")]
        public string PrimaryPropertyType { get; set; }

        [JsonProperty("gross_floor_area_buildings_sq_ft")]
        [JsonConverter(typeof(ParseStringConverter))]
        public decimal GrossFloorAreaBuildingsSqFt { get; set; }

        [JsonProperty("year_built")]
        public string YearBuilt { get; set; }

        [JsonProperty("of_buildings")]
        public string OfBuildings { get; set; }

        [JsonProperty("electricity_use_kbtu")]
        [JsonConverter(typeof(ParseStringConverter))]
        public decimal ElectricityUseKbtu { get; set; }

        [JsonProperty("natural_gas_use_kbtu", NullValueHandling = NullValueHandling.Ignore)]
        public string NaturalGasUseKbtu { get; set; }

        [JsonProperty("site_eui_kbtu_sq_ft")]
        public string SiteEuiKbtuSqFt { get; set; }

        [JsonProperty("source_eui_kbtu_sq_ft")]
        public string SourceEuiKbtuSqFt { get; set; }

        [JsonProperty("weather_normalized_site_eui_kbtu_sq_ft")]
        public string WeatherNormalizedSiteEuiKbtuSqFt { get; set; }

        [JsonProperty("weather_normalized_source_eui_kbtu_sq_ft")]
        public string WeatherNormalizedSourceEuiKbtuSqFt { get; set; }

        [JsonProperty("total_ghg_emissions_metric_tons_co2e")]
        public string TotalGhgEmissionsMetricTonsCo2E { get; set; }

        [JsonProperty("ghg_intensity_kg_co2e_sq_ft")]
        public string GhgIntensityKgCo2ESqFt { get; set; }

        [JsonProperty("latitude")]
        [JsonConverter(typeof(ParseStringConverter))]
        public decimal Latitude { get; set; }

        [JsonProperty("longitude")]
        [JsonConverter(typeof(ParseStringConverter))]
        public decimal Longitude { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

    }

    public partial class Location
    {
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }

    public partial class Energy
    {
        public static Energy[] FromJson(string json) => JsonConvert.DeserializeObject<Energy[]>(json, QuickType.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Energy[] self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            decimal l;
            if (decimal.TryParse(value, out l))
            {
                return l;
            }

            return 0;
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
