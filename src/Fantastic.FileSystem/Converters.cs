namespace Fantastic.FileSystem
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    internal static class Converters
    {
        internal static async IAsyncEnumerable<FileSystemInfoBase> WrapFileSystemInfos(this IEnumerable<FileSystemInfo> input, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            foreach (var info in input)
            {
                yield return await WrapFileSystemInfo(info);
            }
        }

        internal static async IAsyncEnumerable<DirectoryInfoBase> WrapDirectories(this IEnumerable<DirectoryInfo> input, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            foreach (var info in input)
            {
                yield return await Task.FromResult(WrapDirectoryInfo(info));
            }
        }

        internal static async IAsyncEnumerable<FileInfoBase> WrapFiles(this IEnumerable<FileInfo> input, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            foreach (var info in input)
            {
                yield return await Task.FromResult(WrapFileInfo(info));
            }
        }

        private static Task<FileSystemInfoBase> WrapFileSystemInfo(FileSystemInfo item, CancellationToken cancellation = default)
        {
            cancellation.ThrowIfCancellationRequested();
            FileSystemInfoBase result = null!;

            if (item is FileInfo fileInfo)
            {
                result = WrapFileInfo(fileInfo);
            }
            else if (item is DirectoryInfo directoryInfo)
            {
                result = WrapDirectoryInfo(directoryInfo);
            }
            else
            {
                throw new NotImplementedException(string.Format(
                    CultureInfo.InvariantCulture,
                    "The type {0} is not recognized by the System.IO.Abstractions library.",
                    item.GetType().AssemblyQualifiedName
                ));
            }

            return Task.FromResult(result);
        }

        private static FileInfoBase WrapFileInfo(FileInfo f) => new FileInfoWrapper(f);

        private static DirectoryInfoBase WrapDirectoryInfo(DirectoryInfo d) => new DirectoryInfoWrapper(d);
    }
}
