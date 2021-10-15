namespace Fantastic.FileSystem
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class FileSystemInfoBase : IFileSystemInfo
    {
        public abstract Task Delete(CancellationToken cancellationToken = default);

        public abstract Task Refresh(CancellationToken cancellationToken = default);

        public abstract FileAttributes Attributes { get; set; }

        public abstract DateTime CreationTime { get; set; }

        public abstract DateTime CreationTimeUtc { get; set; }

        public abstract bool Exists { get; }

        public abstract string Extension { get; }

        public abstract string FullName { get; }

        public abstract DateTime LastAccessTime { get; set; }

        public abstract DateTime LastAccessTimeUtc { get; set; }

        public abstract DateTime LastWriteTime { get; set; }

        public abstract DateTime LastWriteTimeUtc { get; set; }

        public abstract string Name { get; }
    }
}
