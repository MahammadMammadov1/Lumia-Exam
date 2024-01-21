using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumia.Business.Helper
{
    public static class Helper
    {
        public static string SaveFile(string root , string folder , IFormFile file)
        {
            string fileName = file.FileName.Length > 64 ? file.FileName.Substring(file.FileName.Length - 64,64) : file.FileName;
            string newFileName = Guid.NewGuid().ToString() + fileName;
            string path = Path.Combine(root,folder,newFileName);
            using (FileStream stream = new FileStream(path,FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return newFileName;
        }
    }
}
