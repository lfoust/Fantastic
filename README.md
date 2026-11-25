# Fantastic

## Fantastic.TheMovieDb error handling

TMDB requests throw `HttpRequestException` for unsuccessful HTTP responses,
including 404, 429, and 5xx responses. The exception's `StatusCode` identifies the
HTTP failure; an unsuccessful response is not returned as a missing movie or series.
Callers should handle these exceptions and distinguish a missing item from a
temporary service failure. Cancellation is passed through to the HTTP request.

The in-memory cache stores successful, non-null results for 10 hours. Exceptions
and null results are not cached, so subsequent lookups can retry after a failure.