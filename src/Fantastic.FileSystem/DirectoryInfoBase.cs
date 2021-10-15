namespace Fantastic.FileSystem
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class DirectoryInfoBase : FileSystemInfoBase, IDirectoryInfo
    {
        public abstract Task Create(CancellationToken cancellationToken = default);
        public abstract Task<IDirectoryInfo> CreateSubdirectory(string path, CancellationToken cancellationToken = default);
        public abstract Task Delete(bool recursive = false, CancellationToken cancellationToken = default);
        public abstract IAsyncEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern, SearchOption searchOption, CancellationToken cancellationToken = default);
        public abstract IAsyncEnumerable<IFileInfo> EnumerateFiles(string searchPattern, SearchOption searchOption, CancellationToken cancellationToken = default);
        public abstract IAsyncEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption, CancellationToken cancellationToken = default);
        public abstract Task MoveTo(string destDirName, CancellationToken cancellationToken = default);

        public static implicit operator DirectoryInfoBase(DirectoryInfo directoryInfo)
        {
            if (directoryInfo == null)
            {
                return null!;
            }

            return new DirectoryInfoWrapper(directoryInfo);
        }
    }
}
