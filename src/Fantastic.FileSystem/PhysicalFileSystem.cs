namespace Fantastic.FileSystem
{
    public class PhysicalFileSystem : IFileSystem
    {
        public IDirectory Directory { get; } = new PhysicalDirectory();
        public IFile File { get; } = new PhysicalFile();
        public IPath Path { get; } = new PhysicalPath();
    }
}
