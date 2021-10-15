namespace Fantastic.FileSystem
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;

    public static class DirectoryInfoExtensions
    {
        public static IAsyncEnumerable<IDirectoryInfo> EnumerateDirectories(this IDirectoryInfo info, CancellationToken cancellationToken = default)
        {
            return info.EnumerateDirectories("*", cancellationToken);
        }

        public static IAsyncEnumerable<IDirectoryInfo> EnumerateDirectories(this IDirectoryInfo info, string searchPattern, CancellationToken cancellationToken = default)
        {
            return info.EnumerateDirectories(searchPattern, SearchOption.AllDirectories, cancellationToken);
        }

        public static IAsyncEnumerable<IFileInfo> EnumerateFiles(this IDirectoryInfo info, CancellationToken cancellationToken = default)
        {
            return info.EnumerateFiles("*", cancellationToken);
        }

        public static IAsyncEnumerable<IFileInfo> EnumerateFiles(this IDirectoryInfo info, string searchPattern, CancellationToken cancellationToken = default)
        {
            return info.EnumerateFiles(searchPattern, SearchOption.AllDirectories, cancellationToken);
        }

        public static IAsyncEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(this IDirectoryInfo info, CancellationToken cancellationToken = default)
        {
            return info.EnumerateFileSystemInfos("*", cancellationToken);
        }

        public static IAsyncEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(this IDirectoryInfo info, string searchPattern, CancellationToken cancellationToken = default)
        {
            return info.EnumerateFileSystemInfos(searchPattern, SearchOption.AllDirectories, cancellationToken);
        }
    }
}
