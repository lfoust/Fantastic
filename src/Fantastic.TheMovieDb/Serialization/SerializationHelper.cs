using System.Text.Json;

namespace Fantastic.TheMovieDb.Serialization;

internal static class SerializationHelper
{
    internal static JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions
    {
        WriteIndented = true,
        TypeInfoResolver = TheMovieDbSourceGenerationContext.Default
    };
}
