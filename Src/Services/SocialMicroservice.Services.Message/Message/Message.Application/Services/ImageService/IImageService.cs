using Microsoft.AspNetCore.Http;
using Social.Shared.FileShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Application.Services.ImageService
{
    public interface IImageService : IStorageService
    {
        //string Upload(IFormFile formFile);
        //string Update(IFormFile formFile, string imageUrl);
        //void Delete(string imageUrl);
    }
}