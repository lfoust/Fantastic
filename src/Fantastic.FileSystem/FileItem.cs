namespace Fantastic.FileSystem
{
    public struct FileItem
    {
        public string Path { get; set; }

        public FileItemType Type { get; set; }

        public int Depth { get; set; }
    }
}
