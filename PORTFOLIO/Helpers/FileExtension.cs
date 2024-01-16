﻿namespace PORTFOLIO.Helpers
{
    public static class FileExtension
    {
        public static async Task<string> SaveAsync(this IFormFile file,string path)
        {
            string extension = Path.GetExtension(file.FileName);
            string fileName = Path.GetFileName(file.FileName).Length > 32 ?
                file.FileName.Substring(0, 32) :
                Path.GetFileName(file.FileName);
            fileName = Path.Combine(path, Path.GetRandomFileName() + fileName + extension);
            using(FileStream fs = File.Create(Path.Combine(PathConst.RootPath, fileName)))
            {
                await file.CopyToAsync(fs);
            }
            return fileName;
        }
    }
}
