using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonSerializerConvertors;

var myEvent = new Event
{
    Title = "Conference",
    EventDate = new DateTime(2024, 11, 10, 15, 30, 0)
};

var options = new JsonSerializerOptions { WriteIndented = true };
var jsonString = JsonSerializer.Serialize(myEvent, options);
Console.WriteLine($"Serialize {jsonString}");

var deserializedEvent = JsonSerializer.Deserialize<Event>(jsonString, options);
if (deserializedEvent == null)
    throw new NullReferenceException("Person could not be deserialized");

Console.WriteLine($"Title: {deserializedEvent.Title}, EventDate: {deserializedEvent.EventDate:dd-MM-yyyy HH:mm:ss}");

namespace JsonSerializerConvertors
{
    internal class Event
    {
        [JsonPropertyName("TitleName")]
        public string Title { get; set; } = null!;

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime EventDate { get; set; }
    }


    internal class CustomDateTimeConverter : JsonConverter<DateTime>
    {
        private const string Format = "MM-dd-yy";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dateString = reader.GetString();
            return DateTime.ParseExact(dateString!, Format, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
        }
    }
}