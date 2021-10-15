namespace Fantastic.FileSystem
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public static class FileExtensions
    {
        internal const int DefaultBufferSize = 4096;
        private static Encoding UTF8NoBOM = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);

        public static Task<FileStream> Create(this IFile file, string path, CancellationToken cancellationToken = default)
        {
            return file.Create(path, DefaultBufferSize, FileOptions.None, cancellationToken);
        }

        public static Task<FileStream> Create(this IFile file, string path, int bufferSize, CancellationToken cancellationToken = default)
        {
            return file.Create(path, bufferSize, FileOptions.None, cancellationToken);
        }

        public static Task AppendAllLines(this IFile file, string path, IEnumerable<string> contents, CancellationToken cancellationToken = default)
        {
            return file.AppendAllLines(path, contents, UTF8NoBOM, cancellationToken);
        }

        public static Task AppendAllText(this IFile file, string path, string contents, CancellationToken cancellationToken = default)
        {
            return file.AppendAllText(path, contents, UTF8NoBOM, cancellationToken);
        }

        public static Task<FileStream> Open(this IFile file, string path, FileMode mode, CancellationToken cancellationToken = default)
        {
            return file.Open(path, mode, (mode == FileMode.Append ? FileAccess.Write : FileAccess.ReadWrite), FileShare.None, cancellationToken);
        }

        public static Task<FileStream> Open(this IFile file, string path, FileMode mode, FileAccess access, CancellationToken cancellationToken = default)
        {
            return file.Open(path, mode, access, FileShare.None, cancellationToken);
        }

        public static Task<string[]> ReadAllLines(this IFile file, string path, CancellationToken cancellationToken = default)
        {
            return file.ReadAllLines(path, UTF8NoBOM, cancellationToken);
        }

        public static Task<string> ReadAllText(this IFile file, string path, CancellationToken cancellationToken = default)
        {
            return file.ReadAllText(path, UTF8NoBOM, cancellationToken);
        }

        public static IAsyncEnumerable<string> ReadLines(this IFile file, string path, CancellationToken cancellationToken = default)
        {
            return file.ReadLines(path, UTF8NoBOM, cancellationToken);
        }

        public static Task WriteAllLines(this IFile file, string path, IEnumerable<string> contents, CancellationToken cancellationToken = default)
        {
            return file.WriteAllLines(path, contents, UTF8NoBOM, cancellationToken);
        }

        public static Task WriteAllLines(this IFile file, string path, string[] contents, CancellationToken cancellationToken = default)
        {
            return file.WriteAllLines(path, contents, UTF8NoBOM, cancellationToken);
        }

        public static Task WriteAllText(this IFile file, string path, string contents, CancellationToken cancellationToken = default)
        {
            return file.WriteAllText(path, contents, UTF8NoBOM, cancellationToken);
        }
    }
}
