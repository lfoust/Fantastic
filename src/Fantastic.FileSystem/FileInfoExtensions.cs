namespace Fantastic.FileSystem
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public static class FileInfoExtensions
    {
        public static Task<Stream> Open(this IFileInfo info, FileMode mode, CancellationToken cancellationToken = default)
        {
            return info.Open(mode, (mode == FileMode.Append ? FileAccess.Write : FileAccess.ReadWrite), cancellationToken);
        }

        public static Task<Stream> Open(this IFileInfo info, FileMode mode, FileAccess access, CancellationToken cancellationToken = default)
        {
            return info.Open(mode, access, FileShare.None, cancellationToken);
        }

        public static Task<IFileInfo> Replace(this IFileInfo info, string destinationFileName, string destinationBackupFileName, CancellationToken cancellationToken = default)
        {
            return info.Replace(destinationFileName, destinationBackupFileName, true, cancellationToken);
        }
    }
}
