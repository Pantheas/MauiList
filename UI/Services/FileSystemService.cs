using MauiList.Infrastructure.Interfaces.Services;

namespace MauiList.UI.Services
{
    public class FileSystemService :
        IFileSystemService
    {
        public string DatabaseFilePath =>
            GetDatabaseFilePath();

        private string GetDatabaseFilePath()
        {
            string folder = Environment.GetFolderPath(
                System.Environment.SpecialFolder.LocalApplicationData);

            return Path.Combine(
                folder,
                Infrastructure.Constants.DatabaseFileName);
        }
    }
}
