namespace Fantastic.FileSystem
{
    using System.Threading.Tasks;
    using System.Threading;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;

    public class PhysicalDirectory : IDirectory
    {
        public Task<IDirectoryInfo> CreateDirectory(string path, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var directoryInfo = Directory.CreateDirectory(path);

            return Task.FromResult<IDirectoryInfo>(new DirectoryInfoWrapper(directoryInfo));
        }

        public async IAsyncEnumerable<string> EnumerateDirectories(string path, string searchPattern, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            foreach (var item in Directory.EnumerateDirectories(path, searchPattern))
            {
                cancellationToken.ThrowIfCancellationRequested();
                yield return await Task.FromResult(item);
            }
        }

        public async IAsyncEnumerable<string> EnumerateFiles(string path, string searchPattern, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            foreach (var item in Directory.EnumerateFiles(path, searchPattern))
            {
                cancellationToken.ThrowIfCancellationRequested();
                yield return await Task.FromResult(item);
            }
        }

        public Task<bool> Exists(string path, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult(Directory.Exists(path));
        }

        public Task Delete(string path, bool recursive = false, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            Directory.Delete(path, recursive);
            return Task.CompletedTask;
        }

        public Task Move(string source, string destination, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            Directory.Move(source, destination);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<string>> GetDirectories(string path, string searchPattern, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            IEnumerable<string> items = Directory.GetDirectories(path, searchPattern);
            return Task.FromResult(items);
        }

        public Task<IEnumerable<string>> GetFiles(string path, string searchPattern, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            IEnumerable<string> items = Directory.GetFiles(path, searchPattern);
            return Task.FromResult(items);
        }

        public Task<IDirectoryInfo> GetDirectoryInfo(string path, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            DirectoryInfo info = new DirectoryInfo(path);
            return Task.FromResult<IDirectoryInfo>(new DirectoryInfoWrapper(info));
        }
    }
}
