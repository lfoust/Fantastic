namespace Fantastic.FileSystem
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IDirectoryInfo : IFileSystemInfo
    {
        Task Create(CancellationToken cancellationToken = default);
        Task<IDirectoryInfo> CreateSubdirectory(string path, CancellationToken cancellationToken = default);
        Task Delete(bool recursive = false, CancellationToken cancellationToken = default);
        IAsyncEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern, SearchOption searchOption, CancellationToken cancellationToken = default);
        IAsyncEnumerable<IFileInfo> EnumerateFiles(string searchPattern, SearchOption searchOption, CancellationToken cancellationToken = default);
        IAsyncEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption, CancellationToken cancellationToken = default);
        Task MoveTo(string destDirName, CancellationToken cancellationToken = default);
    }
}
