namespace QuickTypeVehicle
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Vehicle
    {
        [JsonProperty("vehicle_type")]
        public string VehicleType { get; set; }

        [JsonProperty("public_vehicle_number")]
        public string PublicVehicleNumber { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("vehicle_fuel_source")]
        public string VehicleFuelSource { get; set; }

        [JsonProperty("wheelchair_accessible")]
        public string WheelchairAccessible { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }

        [JsonProperty("record_id")]
        public string RecordId { get; set; }

        [JsonProperty("vehicle_make", NullValueHandling = NullValueHandling.Ignore)]
        public string VehicleMake { get; set; }

        [JsonProperty("vehicle_model", NullValueHandling = NullValueHandling.Ignore)]
        public string VehicleModel { get; set; }

        [JsonProperty("vehicle_model_year", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? VehicleModelYear { get; set; }

        [JsonProperty("vehicle_color", NullValueHandling = NullValueHandling.Ignore)]
        public string VehicleColor { get; set; }

        [JsonProperty("taxi_affiliation", NullValueHandling = NullValueHandling.Ignore)]
        public string TaxiAffiliation { get; set; }
    }

    public partial class Vehicle
    {
        public static Vehicle[] FromJson(string json) => JsonConvert.DeserializeObject<Vehicle[]>(json, QuickType.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Vehicle[] self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
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
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
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

