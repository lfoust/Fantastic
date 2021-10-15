namespace Fantastic.FileSystem
{
    using System.Threading;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public static class DirectoryExtensions
    {
        public static IAsyncEnumerable<string> EnumerateDirectories(this IDirectory directory, string path, CancellationToken cancellationToken = default)
        {
            return directory.EnumerateDirectories(path, "*", cancellationToken);
        }

        public static IAsyncEnumerable<string> EnumerateFiles(this IDirectory directory, string path, CancellationToken cancellationToken = default)
        {
            return directory.EnumerateFiles(path, "*", cancellationToken);
        }

        public static Task<IEnumerable<string>> GetDirectories(this IDirectory directory, string path, CancellationToken cancellationToken = default)
        {
            return directory.GetDirectories(path, "*");
        }

        public static Task<IEnumerable<string>> GetFiles(this IDirectory directory, string path, CancellationToken cancellationToken = default)
        {
            return directory.GetFiles(path, "*");
        }

    }
}
