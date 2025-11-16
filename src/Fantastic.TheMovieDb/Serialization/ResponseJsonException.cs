using System;
using System.Text.Json;

namespace Fantastic.TheMovieDb;

public class ResponseJsonException : Exception
{
    public JsonException JsonException { get; }
    public string Url { get; }

    public ResponseJsonException(JsonException jsonException, string url)
        : base($"The response from TMDB could not be parsed. URL: {url}", jsonException)
    {
        JsonException = jsonException;
        Url = url;
    }
}
