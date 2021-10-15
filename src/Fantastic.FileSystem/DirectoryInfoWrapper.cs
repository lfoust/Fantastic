namespace Fantastic.FileSystem
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    public class DirectoryInfoWrapper : DirectoryInfoBase
    {
        private readonly DirectoryInfo instance;

        public DirectoryInfoWrapper(DirectoryInfo instance)
        {
            this.instance = instance ?? throw new ArgumentNullException(nameof(instance));
        }

        public override Task Delete(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            this.instance.Delete();
            return Task.CompletedTask;
        }

        public override Task Refresh(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            this.instance.Refresh();
            return Task.CompletedTask;
        }

        public override FileAttributes Attributes
        {
            get { return this.instance.Attributes; }
            set { this.instance.Attributes = value; }
        }

        public override DateTime CreationTime
        {
            get { return this.instance.CreationTime; }
            set { this.instance.CreationTime = value; }
        }

        public override DateTime CreationTimeUtc
        {
            get { return this.instance.CreationTimeUtc; }
            set { this.instance.CreationTimeUtc = value; }
        }

        public override bool Exists
        {
            get { return this.instance.Exists; }
        }

        public override string Extension
        {
            get { return this.instance.Extension; }
        }

        public override string FullName
        {
            get { return this.instance.FullName; }
        }

        public override DateTime LastAccessTime
        {
            get { return this.instance.LastAccessTime; }
            set { this.instance.LastAccessTime = value; }
        }

        public override DateTime LastAccessTimeUtc
        {
            get { return this.instance.LastAccessTimeUtc; }
            set { this.instance.LastAccessTimeUtc = value; }
        }

        public override DateTime LastWriteTime
        {
            get { return this.instance.LastWriteTime; }
            set { this.instance.LastWriteTime = value; }
        }

        public override DateTime LastWriteTimeUtc
        {
            get { return this.instance.LastWriteTimeUtc; }
            set { this.instance.LastWriteTimeUtc = value; }
        }

        public override string Name
        {
            get { return this.instance.Name; }
        }

        public override Task Create(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            this.instance.Create();
            return Task.CompletedTask;
        }

        public override Task<IDirectoryInfo> CreateSubdirectory(string path, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            IDirectoryInfo info = new DirectoryInfoWrapper(this.instance.CreateSubdirectory(path));
            return Task.FromResult(info);
        }

        public override Task Delete(bool recursive = false, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            this.instance.Delete(recursive);
            return Task.CompletedTask;
        }

        public override async IAsyncEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern, SearchOption searchOption, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            foreach (var item in this.instance.EnumerateDirectories(searchPattern, searchOption))
            {
                yield return await Task.FromResult<IDirectoryInfo>(new DirectoryInfoWrapper(item));
            }
        }

        public override async IAsyncEnumerable<IFileInfo> EnumerateFiles(string searchPattern, SearchOption searchOption, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            foreach (var item in this.instance.EnumerateFiles(searchPattern, searchOption))
            {
                yield return await Task.FromResult<IFileInfo>(new FileInfoWrapper(item));
            }
        }

        public override IAsyncEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption, CancellationToken cancellationToken = default)
        {
            return this.instance.EnumerateFileSystemInfos(searchPattern, searchOption).WrapFileSystemInfos(cancellationToken);
        }

        public override Task MoveTo(string destDirName, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            this.instance.MoveTo(destDirName);
            return Task.CompletedTask;
        }

        public override string ToString()
        {
            return this.instance.ToString();
        }
    }
}
