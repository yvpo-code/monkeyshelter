 using System;
 using System.Text.Json;
 using System.Text.Json.Serialization;
 using System.Globalization;

 class JsonDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
       => DateTime.ParseExact(reader.GetString(),
                    "ddd MMM dd yyyy HH:mm:ss \"GMT\"+ffff", CultureInfo.InvariantCulture);

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
       => writer.WriteStringValue(value.ToString(
                    "ddd MMM dd yyyy hh:mm:ss \"GMT\"+ffff", CultureInfo.InvariantCulture));
    }