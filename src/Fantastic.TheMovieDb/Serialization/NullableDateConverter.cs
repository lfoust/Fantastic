namespace Fantastic.TheMovieDb.Serialization;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class NullableDateConverter : JsonConverter<DateTimeOffset?>
{
    public override DateTimeOffset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? val = reader.GetString();
        if (string.IsNullOrEmpty(val))
        {
            return null;
        }

        return reader.GetDateTimeOffset();
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            writer.WriteStringValue(value.Value);
        }
    }
}

public class NullableDateTimeConverter : JsonConverter<DateTime?>
{
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var @string = reader.GetString();
        if (string.IsNullOrWhiteSpace(@string))
        {
            return null;
        }

        return reader.GetDateTime();
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            writer.WriteStringValue(value.Value);
        }
    }
}
