namespace Fantastic.FileSystem
{
    public interface IFileSystem
    {
        IDirectory Directory { get; }
        IFile File { get; }
        IPath Path { get; }
    }
}
