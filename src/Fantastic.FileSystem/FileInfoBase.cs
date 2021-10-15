namespace Fantastic.FileSystem
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class FileInfoBase : FileSystemInfoBase, IFileInfo
    {
        public abstract Task<IFileInfo> CopyTo(string destFileName, bool overwrite = false, CancellationToken cancellationToken = default);

        public abstract Task<Stream> Create(CancellationToken cancellationToken = default);

        public abstract Task<StreamWriter> CreateText(CancellationToken cancellationToken = default);

        public abstract Task MoveTo(string destFileName, CancellationToken cancellationToken = default);

        public abstract Task<Stream> Open(FileMode mode, FileAccess access, FileShare share, CancellationToken cancellationToken = default);

        public abstract Task<Stream> OpenRead(CancellationToken cancellationToken = default);

        public abstract Task<StreamReader> OpenText(CancellationToken cancellationToken = default);

        public abstract Task<Stream> OpenWrite(CancellationToken cancellationToken = default);

        public abstract Task<IFileInfo> Replace(string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors = true, CancellationToken cancellationToken = default);

        public abstract IDirectoryInfo Directory { get; }

        public abstract string DirectoryName { get; }

        public abstract bool IsReadOnly { get; set; }

        public abstract long Length { get; }

        public static implicit operator FileInfoBase(FileInfo fileInfo)
        {
            if (fileInfo == null)
            {
                return null!;
            }

            return new FileInfoWrapper(fileInfo);
        }
    }
}
