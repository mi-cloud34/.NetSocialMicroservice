using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Shared.FileShared;

public interface IStorageService : IStorage
{
    public string StorageName { get; }
}