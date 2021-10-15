namespace Fantastic.TheMovieDb
{
    public class TheMovieDbOptions
    {
        public string? ApiKey { get; set; }

        /// <summary>ISO 639-1 code. Example: 'en'</summary>
        public string? DefaultLanguage { get; set; }
    }
}
