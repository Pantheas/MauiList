using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiList.Infrastructure.Interfaces.Services
{
    public interface IFileSystemService
    {
        string DatabaseFilePath { get; }
    }
}
