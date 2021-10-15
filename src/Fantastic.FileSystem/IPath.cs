using System;

namespace Fantastic.FileSystem
{
    public interface IPath
    {
        string GetExtension(string path);
        string Combine(params string[] paths);
        string GetFileName(string path);
        char PathSeparator { get; }
        char DirectorySeparatorChar { get; }
        char VolumeSeparatorChar { get; }
        string ChangeExtension(string path, string extension);
        string Combine(string path1, string path2);
        string Combine(string path1, string path2, string path3);
        string Combine(string path1, string path2, string path3, string path4);
        string GetDirectoryName(string path);
        string GetFileNameWithoutExtension(string path);
        string GetFullPath(string path);
        char[] GetInvalidFileNameChars();
        char[] GetInvalidPathChars();
        string GetPathRoot(string path);
        string GetRandomFileName();
        string GetTempFileName();
        string GetTempPath();
        bool HasExtension(string path);
        bool IsPathRooted(string path);

        string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2);
        string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3);
        bool TryJoin(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3, Span<char> destination, out int charsWritten);
        bool TryJoin(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, Span<char> destination, out int charsWritten);
    }

    public abstract class PathBase : IPath
    {
        public abstract char AltDirectorySeparatorChar { get; }
        public abstract char DirectorySeparatorChar { get; }
        public abstract char PathSeparator { get; }
        public abstract char VolumeSeparatorChar { get; }
        public abstract string ChangeExtension(string path, string extension);
        public abstract string Combine(params string[] paths);
        public abstract string Combine(string path1, string path2);
        public abstract string Combine(string path1, string path2, string path3);
        public abstract string Combine(string path1, string path2, string path3, string path4);
        public abstract string GetDirectoryName(string path);
        public abstract string GetExtension(string path);
        public abstract string GetFileName(string path);
        public abstract string GetFileNameWithoutExtension(string path);
        public abstract string GetFullPath(string path);

        public abstract char[] GetInvalidFileNameChars();

        public abstract char[] GetInvalidPathChars();

        public abstract string GetPathRoot(string path);

        public abstract string GetRandomFileName();

        public abstract string GetTempFileName();

        public abstract string GetTempPath();

        public abstract bool HasExtension(string path);

        public abstract bool IsPathRooted(string path);

        public abstract string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2);

        public abstract string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3);
        
        public abstract bool TryJoin(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3, Span<char> destination, out int charsWritten);
        
        public abstract bool TryJoin(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, Span<char> destination, out int charsWritten);
    }
}
