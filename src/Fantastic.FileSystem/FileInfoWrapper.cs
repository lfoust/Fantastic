namespace Fantastic.FileSystem
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public class FileInfoWrapper : FileInfoBase
    {
        private readonly FileInfo instance;

        public FileInfoWrapper(FileInfo instance)
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

        public override Task<IFileInfo> CopyTo(string destFileName, bool overwrite = false, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            IFileInfo info = new FileInfoWrapper(this.instance.CopyTo(destFileName));
            return Task.FromResult(info);
        }

        public override Task<Stream> Create(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            Stream stream = this.instance.Create();
            return Task.FromResult(stream);
        }

        public override Task<StreamWriter> CreateText(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var stream = this.instance.CreateText();
            return Task.FromResult(stream);
        }

        public override Task MoveTo(string destFileName, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            this.instance.MoveTo(destFileName);
            return Task.CompletedTask;
        }

        public override Task<Stream> Open(FileMode mode, FileAccess access, FileShare share, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            Stream stream = this.instance.Open(mode, access, share);
            return Task.FromResult(stream);
        }

        public override Task<Stream> OpenRead(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            Stream stream = this.instance.OpenRead();
            return Task.FromResult(stream);
        }

        public override Task<StreamReader> OpenText(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var stream = this.instance.OpenText();
            return Task.FromResult(stream);
        }

        public override Task<Stream> OpenWrite(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            Stream stream = this.instance.OpenWrite();
            return Task.FromResult(stream);
        }

        public override Task<IFileInfo> Replace(string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors = true, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            IFileInfo info = new FileInfoWrapper(this.instance.Replace(destinationFileName, destinationBackupFileName, ignoreMetadataErrors));
            return Task.FromResult(info);
        }

        public override IDirectoryInfo Directory
        {
            get { return new DirectoryInfoWrapper(this.instance.Directory); }
        }

        public override string DirectoryName
        {
            get { return this.instance.DirectoryName; }
        }

        public override bool IsReadOnly
        {
            get { return this.instance.IsReadOnly; }
            set { this.instance.IsReadOnly = value; }
        }

        public override long Length
        {
            get { return this.instance.Length; }
        }

        public override string ToString()
        {
            return this.instance.ToString();
        }
    }
}
