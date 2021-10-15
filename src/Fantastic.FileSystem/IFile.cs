namespace Fantastic.FileSystem
{
    using System.Threading.Tasks;
    using System.Threading;
    using System.IO;
    using System.Collections.Generic;
    using System.Text;
    using System;

    public interface IFile
    {
        Task<bool> Exists(string path, CancellationToken cancellationToken = default);
        Task<FileStream> Create(string path, int bufferSize, FileOptions options, CancellationToken cancellationToken = default);
        
        Task AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default);
        
        Task AppendAllText(string path, string contents, Encoding encoding, CancellationToken cancellationToken = default);
        
        Task Copy(string sourceFileName, string destFileName, bool overwrite = false, CancellationToken cancellationToken = default);
        
        Task<StreamWriter> CreateText(string path, CancellationToken cancellationToken = default);
        Task Delete(string path, CancellationToken cancellationToken = default);
        Task Move(string sourceFileName, string destFileName, CancellationToken cancellationToken = default);
        Task<FileStream> Open(string path, FileMode mode, FileAccess access, FileShare share, CancellationToken cancellationToken = default);
        Task<FileStream> OpenRead(string path, CancellationToken cancellationToken = default);
        Task<StreamReader> OpenText(string path, CancellationToken cancellationToken = default);
        Task<FileStream> OpenWrite(string path, CancellationToken cancellationToken = default);
        Task<byte[]> ReadAllBytes(string path, CancellationToken cancellationToken = default);
        Task<string[]> ReadAllLines(string path, Encoding encoding, CancellationToken cancellationToken = default);
        Task<string> ReadAllText(string path, Encoding encoding, CancellationToken cancellationToken = default);
        IAsyncEnumerable<string> ReadLines(string path, Encoding encoding, CancellationToken cancellationToken = default);
        Task Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors = true, CancellationToken cancellationToken = default);
        Task WriteAllBytes(string path, byte[] bytes, CancellationToken cancellationToken = default);
        Task WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default);
        Task WriteAllLines(string path, string[] contents, Encoding encoding, CancellationToken cancellationToken = default);
        Task WriteAllText(string path, string contents, Encoding encoding, CancellationToken cancellationToken = default);

        Task<IFileInfo> GetFileInfo(string path, CancellationToken cancellationToken = default);
    }
}
