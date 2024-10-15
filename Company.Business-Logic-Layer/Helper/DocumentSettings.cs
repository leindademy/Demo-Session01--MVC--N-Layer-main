using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Business_Logic_Layer.Helper
{
    public class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            // (1) get folder path
            //  var FolderPath = @"";
            var FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files\\" + folderName);
            // (2) get file name
            var FileName = $"{Guid.NewGuid()}-{file.FileName }"; //namefolder is Unique
            // (3) combile FolderPth + FileName
            var filepath = Path.Combine(FolderPath, FileName);
            // (4) save file
            using var fileStream = new FileStream(filepath, FileMode.Create);

            file.CopyTo(fileStream);

            return FileName;

        }
    }
}
