namespace Fantastic.FileSystem
{
    using System.Threading.Tasks;
    using System.Threading;
    using System.IO;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.CompilerServices;

    public class PhysicalFile : IFile
    {
        public Task AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default)
        {
#if NETSTANDARD2_0
            return Task.Run(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                using (var writer = new StreamWriter(path, append: true, encoding))
                {
                    foreach (var line in contents)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        writer.WriteLine(line);
                    }
                }
            }, cancellationToken);
#else
    return File.AppendAllLinesAsync(path, contents, encoding, cancellationToken);
#endif
        }

        public Task AppendAllText(string path, string contents, Encoding encoding, CancellationToken cancellationToken = default)
        {
#if NETSTANDARD2_0
            return Task.Run(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                using (var writer = new StreamWriter(path, append: true, encoding))
                {
                    writer.Write(contents);
                }
            }, cancellationToken);
#else
    return File.AppendAllTextAsync(path, contents, encoding, cancellationToken);
#endif
        }

        public Task Copy(string sourceFileName, string destFileName, bool overwrite = false, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            File.Copy(sourceFileName, destFileName, overwrite);
            return Task.CompletedTask;
        }

        public Task<FileStream> Create(string path, int bufferSize, FileOptions options, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var stream = File.Create(path, bufferSize, options);
            return Task.FromResult(stream);
        }

        public Task<StreamWriter> CreateText(string path, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var stream = File.CreateText(path);
            return Task.FromResult(stream);
        }

        public Task Delete(string path, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            File.Delete(path);
            return Task.CompletedTask;
        }

        public Task<bool> Exists(string path, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return Task.FromResult(File.Exists(path));
        }

        public Task<IFileInfo> GetFileInfo(string path, CancellationToken cancellationToken = default)
        {
            var info = new FileInfo(path);
            return Task.FromResult<IFileInfo>(new FileInfoWrapper(info));
        }

        public Task Move(string sourceFileName, string destFileName, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            File.Move(sourceFileName, destFileName);
            return Task.CompletedTask;
        }

        public Task<FileStream> Open(string path, FileMode mode, FileAccess access, FileShare share, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var stream = File.Open(path, mode, access, share);
            return Task.FromResult(stream);
        }

        public Task<FileStream> OpenRead(string path, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var stream = File.OpenRead(path);
            return Task.FromResult(stream);
        }

        public Task<StreamReader> OpenText(string path, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var stream = File.OpenText(path);
            return Task.FromResult(stream);
        }

        public Task<FileStream> OpenWrite(string path, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var stream = File.OpenWrite(path);
            return Task.FromResult(stream);
        }

        public Task<byte[]> ReadAllBytes(string path, CancellationToken cancellationToken = default)
        {
#if NETSTANDARD2_0
            return Task.Run(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                return File.ReadAllBytes(path);
            }, cancellationToken);
#else
            return File.ReadAllBytesAsync(path, cancellationToken);
#endif
        }

        public Task<string[]> ReadAllLines(string path, Encoding encoding, CancellationToken cancellationToken = default)
        {
#if NETSTANDARD2_0
            return Task.Run(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                return File.ReadAllLines(path, encoding);
            }, cancellationToken);
#else
            return File.ReadAllLinesAsync(path, encoding, cancellationToken);
#endif
        }

        public Task<string> ReadAllText(string path, Encoding encoding, CancellationToken cancellationToken = default)
        {
#if NETSTANDARD2_0
            return Task.Run(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                return File.ReadAllText(path, encoding);
            }, cancellationToken);
#else
            return File.ReadAllTextAsync(path, encoding, cancellationToken);
#endif
        }

        public async IAsyncEnumerable<string> ReadLines(string path, Encoding encoding, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            foreach (var item in File.ReadLines(path, encoding))
            {
                cancellationToken.ThrowIfCancellationRequested();
                yield return await Task.FromResult(item);
            }
        }

        public Task Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors = true, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            File.Replace(sourceFileName, destinationFileName, destinationBackupFileName, ignoreMetadataErrors);
            return Task.CompletedTask;        
        }

        public Task WriteAllBytes(string path, byte[] bytes, CancellationToken cancellationToken = default)
        {
#if NETSTANDARD2_0
            return Task.Run(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                File.WriteAllBytes(path, bytes);
            }, cancellationToken);
#else
            return File.WriteAllBytesAsync(path, bytes, cancellationToken);
#endif
        }

        public Task WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default)
        {
#if NETSTANDARD2_0
            return Task.Run(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                File.WriteAllLines(path, contents, encoding);
            }, cancellationToken);
#else
            return File.WriteAllLinesAsync(path, contents, encoding, cancellationToken);
#endif
        }

        public Task WriteAllLines(string path, string[] contents, Encoding encoding, CancellationToken cancellationToken = default)
        {
#if NETSTANDARD2_0
            return Task.Run(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                File.WriteAllLines(path, contents, encoding);
            }, cancellationToken);
#else
            return File.WriteAllLinesAsync(path, contents, encoding, cancellationToken);
#endif
        }

        public Task WriteAllText(string path, string contents, Encoding encoding, CancellationToken cancellationToken = default)
        {
#if NETSTANDARD2_0
            return Task.Run(() =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                File.WriteAllText(path, contents, encoding);
            }, cancellationToken);
#else
            return File.WriteAllTextAsync(path, contents, encoding, cancellationToken);
#endif
        }
    }
}
