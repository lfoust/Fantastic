namespace Fantastic.FileSystem
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IFileSystemInfo
    {
        Task Delete(CancellationToken cancellationToken = default);
        Task Refresh(CancellationToken cancellationToken = default);
        FileAttributes Attributes { get; set; }
        DateTime CreationTime { get; set; }
        DateTime CreationTimeUtc { get; set; }
        bool Exists { get; }
        string Extension { get; }
        string FullName { get; }
        DateTime LastAccessTime { get; set; }
        DateTime LastAccessTimeUtc { get; set; }
        DateTime LastWriteTime { get; set; }
        DateTime LastWriteTimeUtc { get; set; }
        string Name { get; }
    }
}
