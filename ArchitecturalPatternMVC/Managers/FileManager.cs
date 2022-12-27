using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace ArchitecturalPatternMVC.Managers
{
    public static class FileManager
    {
        public static string GetUniqueNameAndSavePhotoToDisk(this IFormFile pictureFile, IWebHostEnvironment webHostEnvironment)
        {
            string uniqueFileName = null;

            if (pictureFile is not null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + pictureFile.FileName; //Dosyalarımın tekrar eklendiklerinde, yolların çakışmasını önlemek için, string manipulation yaparak başlarına yeni bir guid ve "_" karakterleriyle modifikaysyona uğratıp uniqueleştirmeye çalışıyoruz.

                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images"); //Sistem yolunu al, wwwroot içerisinde ki images klasörüne dosyamı yükle!!! Startup.cs içerisinde app.UseStaticFiles() methodunu yazmazsanız, dışarıdan wwwroot'a kullanıcı ulaşamaz!!

                string filePath = Path.Combine(uploadsFolder, uniqueFileName); //Dosya uzantısını artık oluşturmakta bir engelemiz kalmadı. dosya yolunu ve ismini belirterek combine ediyoruz.

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    pictureFile.CopyTo(fileStream); //copyTo methodu ile dosya yazma işlemini tamamlıyoruz.
                }
            }
            return uniqueFileName;
        }
        

        public static void RemoveImageFromDisk(string imageName, IWebHostEnvironment webHostEnvironment)
        {
            if (!string.IsNullOrEmpty(imageName))
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                string filePath = Path.Combine(uploadsFolder, imageName);
                File.Delete(filePath);
            }
        }
    }
}
