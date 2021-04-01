using System;
using System.IO;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        //private static string Path = System.IO.Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName);

        private static readonly string Path = Environment.CurrentDirectory + @"\wwwroot";


        /// <summary>
        /// return new path from added file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string Add(IFormFile file)
        {
            var sourcePath = System.IO.Path.GetTempFileName();

            if (file.Length > 0)
            {
                using var stream = new FileStream(sourcePath, FileMode.Create);
                file.CopyTo(stream);
            }

            var (filePath, sqlPath) = NewPath(file);


            File.Move(sourcePath, filePath);

            return sqlPath;
        }


        /// <summary>
        /// sourcePath will be deleted,return new path from added file
        /// </summary>
        /// <param name="file"></param>
        /// <param name="sourcePath"></param>
        /// <returns></returns>
        public static string Update(IFormFile file, string sourcePath)
        {
            var (filePath, sqlPath) = NewPath(file);


            try
            {
                if (sourcePath.Length > 0)
                {
                    using var stream = new FileStream(filePath, FileMode.Create);
                    file.CopyTo(stream);
                }

                File.Delete(sourcePath);
            }
            catch
            {
                throw new Exception();
            }

            return sqlPath;
        }

        public static IResult Delete(string sourcePath)
        {

            try
            {
                File.Delete(sourcePath);
            }
            catch
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public static (string filePath, string sqlPath) NewPath(IFormFile file)
        {
            //string CurrentPath = @"C:\Users\SKUCUK\source\repos\ReCapProject\Images\CarImages";

            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;

            var uniqueFileName = $"{DateTime.Now.Day}_" +
                                 $"{DateTime.Now.Month}_" +
                                 $"{DateTime.Now.Year}_" +
                                 $"_{Guid.NewGuid():N}" +
                                 $"{fileExtension}";

            //Directory.GetCurrentDirectory() // Wep api klasörünü dahil ediyor
            //Environment.CurrentDirectory

            //var extension = Path.GetExtension(file.FileName);
            //var newPath = Directory.GetCurrentDirectory() + @"\wwwroot\Images\" + Guid.NewGuid().ToString("N") + extension;

            //Directory.GetCurrentDirectory() +

            string sqlPath = $@"Images\{uniqueFileName}";

            string filePath = $@"{Path}\{sqlPath}";

            return (filePath, sqlPath);
        }

        //if (!File.Exists(result))
        //{
        //    using (FileStream fs = File.Create(result)) { }

        //}
    }
}