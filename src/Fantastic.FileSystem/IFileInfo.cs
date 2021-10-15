namespace Fantastic.FileSystem
{
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IFileInfo : IFileSystemInfo
    {
        Task<IFileInfo> CopyTo(string destFileName, bool overwrite = false, CancellationToken cancellationToken = default);
        Task<Stream> Create(CancellationToken cancellationToken = default);
        Task<StreamWriter> CreateText(CancellationToken cancellationToken = default);
        Task MoveTo(string destFileName, CancellationToken cancellationToken = default);
        Task<Stream> Open(FileMode mode, FileAccess access, FileShare share, CancellationToken cancellationToken = default);
        Task<Stream> OpenRead(CancellationToken cancellationToken = default);
        Task<StreamReader> OpenText(CancellationToken cancellationToken = default);
        Task<Stream> OpenWrite(CancellationToken cancellationToken = default);
        Task<IFileInfo> Replace(string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors = true, CancellationToken cancellationToken = default);
        IDirectoryInfo Directory { get; }
        string DirectoryName { get; }
        bool IsReadOnly { get; set; }
        long Length { get; }
    }
}
