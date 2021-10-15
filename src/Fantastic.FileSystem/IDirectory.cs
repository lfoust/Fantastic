namespace Fantastic.FileSystem
{
    using System.Threading.Tasks;
    using System.Threading;
    using System.Collections.Generic;

    public interface IDirectory
    {
        IAsyncEnumerable<string> EnumerateDirectories(string path, string searchPattern, CancellationToken cancellationToken = default);
        Task<IEnumerable<string>> GetDirectories(string path, string searchPattern, CancellationToken cancellationToken = default);
        IAsyncEnumerable<string> EnumerateFiles(string path, string searchPattern, CancellationToken cancellationToken = default);
        Task<IEnumerable<string>> GetFiles(string path, string searchPattern, CancellationToken cancellationToken = default);
        Task<bool> Exists(string path, CancellationToken cancellationToken = default);
        Task<IDirectoryInfo> CreateDirectory(string path, CancellationToken cancellationToken = default);
        Task Delete(string path, bool recursive = false, CancellationToken cancellationToken = default);
        Task Move(string source, string destination, CancellationToken cancellationToken = default);
        Task<IDirectoryInfo> GetDirectoryInfo(string path, CancellationToken cancellationToken = default);
    }
}
