using BYTEBaba.Model.FileSystem;
using System.Security.AccessControl;
namespace BYTEBaba.Services.FileSystem
{
    public class FileSystemService
    {
        private readonly string _basePath;
        public FileSystemService(string basepath)
        {
            _basePath = basepath;
        }
        public async Task<List<FileSystemItem>> GetBookSelfItem()
        {
            return await GetFileSystemItemsAsync(_basePath);
        }
        public async Task<List<FileSystemItem>> GetFileSystemItemsAsync(String path)
        {
            var items = new List<FileSystemItem>();

            foreach (var file in Directory.GetFiles(path))
            {
                items.Add(new FileSystemItem
                {
                    Name = Path.GetFileName(file),
                    Path = file
                });
            }
            foreach (var directory in Directory.GetDirectories(path))
            {
                var item = new FileSystemItem
                {
                    Name = Path.GetFileName(directory),
                    Path = directory,
                    Children = await GetFileSystemItemsAsync(directory)
                };
                items.Add(item);
            }

            return items;
        }
    }
}
