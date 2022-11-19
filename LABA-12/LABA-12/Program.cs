using System;

namespace LABA12
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                PVGLog.WriteLogInfo();
                PVGDiskInfo.GetDiskInfo();
                PVGFileInfo.GetFileInfo();
                PVGDirInfo.GetDirInfo();
                PVGFileManager.VADFiles();
                PVGFileManager.MakeArchive();
                PVGFileManager.VADInspect();

                PVGLog.ReadLog();
                PVGLog.SearchLog();
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine("Ошибка! Директорий не найден.\n" + e.Message);
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("Ошибка! Файл уже существует или используется другим процессом.\n" +
                                  e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Непредвиденная ошибка!\n" + e.Message 
                                 );
            }
        }
    }
}