using System;
using System.IO;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcePath = Path.GetTempFileName();
            string result;

            if (file.Length > 0)
            {
                using var stream = new FileStream(sourcePath, FileMode.Create);
                file.CopyTo(stream);
            }

            result = NewPath(file);

            File.Move(sourcePath, result);


            return result;
        }

        public static string Update(IFormFile file, string sourcePath)
        {
            var result = NewPath(file);

            if (sourcePath.Length > 0)
            {
                using var stream = new FileStream(result, FileMode.Create);
                file.CopyTo(stream);
            }
            File.Delete(sourcePath);

            return result;
        }

        public static IResult Delete(string sourcePath)
        {
            var file = Directory.GetFiles(sourcePath).Length;
            try
            {
                if (file == 0)
                {
                    return new ErrorResult();
                }

                File.Delete(sourcePath);
            }
            catch (Exception e)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public static string NewPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;

            var uniqueFileName = $"{DateTime.Now.Month}/" +
                                 $"{DateTime.Now.Day}/" +
                                 $"{DateTime.Now.Year}-" +
                                 $"{Guid.NewGuid():B} " +
                                 $"{fileExtension}";

            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\CarImages");

            string result = $@"{path}\{uniqueFileName}";

            return result;
        }
    }
}