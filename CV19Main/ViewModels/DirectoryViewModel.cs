using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using CV19Main.ViewModels.Base;

namespace CV19Main.ViewModels
{
    internal class DirectoryViewModel : ViewModel
    {
        private readonly DirectoryInfo _DirectoryInfo;


        public IEnumerable<DirectoryViewModel> SubDirectories
        {
            get 
            {
                try
                {
                    var directories = _DirectoryInfo
                        .EnumerateDirectories()
                        .Select(dir_info => new DirectoryViewModel(dir_info.FullName));
                    return directories;
                }
                catch (UnauthorizedAccessException e)
                {
                    Debug.WriteLine(e);
                }
                return Enumerable.Empty<DirectoryViewModel>();
            }
        }
        public IEnumerable<FileViewModel> Files
        {
            get
            {
                try
                {
                    var files = _DirectoryInfo
                        .EnumerateFiles()
                        .Select(file => new FileViewModel(file.FullName));
                    return files;
                }
                catch(UnauthorizedAccessException e)
                {
                    Debug.WriteLine(e.ToString());
                }
                return Enumerable.Empty<FileViewModel>();
            }
        }
        


        public IEnumerable<object> DirectoryItems
        {
            get
            {
                try
                {
                   var subDire =  SubDirectories.Cast<object>()
                        .Concat(Files.Cast<object>());
                    return subDire;
                }
                catch (UnauthorizedAccessException e)
                {
                    Debug.WriteLine(e.ToString());
                }
                return Enumerable.Empty<FileViewModel>();
            }
        }

        public string Name => _DirectoryInfo.Name;

        public string Path => _DirectoryInfo.FullName;

        public DateTime CreationTime => _DirectoryInfo?.CreationTime ?? DateTime.MinValue;
        public DirectoryViewModel(string Path)
        {
               _DirectoryInfo = new DirectoryInfo(Path);
        }



    }
    class FileViewModel : ViewModel
    {
        private FileInfo _FileInfo;

        public string Name => _FileInfo.Name;

        public string Path => _FileInfo.FullName;

        public DateTime CreationTime => _FileInfo?.CreationTime ?? DateTime.MinValue;

        public FileViewModel(string Path)
        {
            _FileInfo = new FileInfo(Path);
        }

    }

}
