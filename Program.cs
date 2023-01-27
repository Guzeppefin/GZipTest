using System;
using System.IO;
using System.IO.Compression;

namespace CompressFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFile = @"c:\source\myfile.ext";  // исходный файл, который нужно архивировать 
            string compressedFile = @"c:\compressed\myfile.gz"; // архивированный файл 

            Compress(sourceFile, compressedFile);

            Console.WriteLine("Compression complete.");

            

            Console.ReadKey();  // для остановки программы  

        }

        public static void Compress(string sourceFile, string compressedFile)   // метод для архивации  
        {
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate)) //создаем FileStream (поток) c исходным файлом  
            {

                using (FileStream targetStream = File.Create(compressedFile)) //создаем FileStream c сжатым файлом  

                {                      //связываем 2-е Stream-ы - sourceStream (откуда) & targetStream (куда).  

                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))

                    {                         //копируем sourceSteam-у в compressionSteam-у (кудa).  

                        sourceStream.CopyTo(compressionStream); Console.WriteLine("Compression {0} complete.", sourceFile);
                    }
                }
            }
        }
        
    } 
}