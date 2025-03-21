using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cinema.Application.DTOs;


public class MovieDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; }
    public string Director { get; set; }
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly ReleaseDate { get; set; }
    public string PosterImageUrl { get; set; }

}

public class DateOnlyJsonConverter : JsonConverter<DateOnly>
{
    private const string Format = "yyyy-MM-dd";

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateOnly.ParseExact(reader.GetString(), Format);
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(Format));
    }
}