using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks.Sources;
using ConsoleApp;

var person = new Person
{
    Name = "Mykola",
    Email = "oleksiyovich.mykolafrfr@gmail.com",
    Age = 7,
    Time = 30,
    Date = new DateTime(2024, 11, 10, 15, 30, 0)
};

var options = new JsonSerializerOptions
{
    WriteIndented = true,
    Converters = { new DateTimeConverter() }
};

var jsonString = JsonSerializer.Serialize(person);
File.WriteAllText("person.json", jsonString);
Console.WriteLine($"Person: {jsonString}");

var deserializedPerson = JsonSerializer.Deserialize<Person>(jsonString);
if (deserializedPerson == null)
    throw new NullReferenceException("Person could not be deserialized");

Console.WriteLine($"Name: {deserializedPerson.Name}, " +
                  $"Age: {deserializedPerson.Age}, " +
                  $"Email: {deserializedPerson.Email}, " +
                  $"Time: {deserializedPerson.Time * 60}, " +
                  $"Date: {deserializedPerson.Date.ToString("MM-dd-yy")}");

public class DateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.Parse(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("MM-dd-yy"));
    }
}


namespace ConsoleApp
{
    internal class Person
    {
        public string Name { get; init; } = null!;
        public string Email { get; init; } = null!;
        public int Age { get; init; }
        public int Time { get; init; }
        public DateTime Date { get; init; }
    }
}