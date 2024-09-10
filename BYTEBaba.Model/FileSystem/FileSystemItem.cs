namespace BYTEBaba.Model.FileSystem
{

    public class FileSystemItem
    {
        public string Name { get; set; }
        public string Path { get; set; }        
        public List<FileSystemItem> Children { get; set; } = new List<FileSystemItem>();
        public bool IsDirectory => Children.Count > 0;
    }
}
