using System;
using System.IO;
using System.Threading;
using System.IO.Compression;
using System.Linq;

namespace LABA12
{
    public static class PVGFileManager
    {
        public static void VADInspect()
        {
            string classLogInfo = "\n=======================================   PVGFileManager   ===============================================\n";            /// инфа для логгера
            string inspectLog = "";

            DriveInfo[] drives = DriveInfo.GetDrives();                 /// получили инфу о всех дисках
            string inspectPath = drives[1].Name;                        /// путь диска D:\ полученный от DriveInfo.GetDrives()
            DirectoryInfo directory = new DirectoryInfo(@"D:\ООП\LABA-12");   /// тот же путь, только типа данных DirectoryInfo

            directory.Create();                                         /// создаем субдерикторий D:\LABA-12\PVGInspect
            directory.CreateSubdirectory(@"PVGInspect");

            DirectoryInfo VADInspectFiles = new DirectoryInfo(Path.GetFullPath(@"D:\ООП\LABA-12\PVGInspect\PVGFiles"));
            if (VADInspectFiles.Exists)
                VADInspectFiles.Delete(true);

            string filePath = Path.GetFullPath(@"D:\ООП\LABA-12\PVGInspect\pvgdirinfo.txt");
            FileInfo fileInfo = new FileInfo(filePath);                 /// fileInfo шобы всё работало
            using (StreamWriter sw = fileInfo.CreateText())             /// создаем файл и сразу пишем поток
            {
                sw.WriteLine("Поздравляем с др Никитоса.\n" +
                             "с Днём Рождения 30.11.2021! Желаем, чтобы разрабы не\n" +
                             "были даунами, меньше рейджей и, конечно же, как можно\n" +
                             "больше гачи донатов!");
                sw.Close();                                             /// и закрываем нахуй а то мало ли
            }


            string renamePath = Path.GetFullPath(@"D:\ООП\LABA-12\PVGInspect\pvgdirinfoRENAMED.txt");
            FileInfo renameBuf = new FileInfo(renamePath);              /// буфер чтобы удалить созданный ранее RENAMED
            renameBuf.Delete();

            fileInfo.CopyTo(renamePath);
            fileInfo.Delete();


            DirectoryInfo inspectDirInfo = new DirectoryInfo(Path.GetFullPath(@"D:\ООП\LABA-12\PVGInspect"));
            string files = "";
            for (int i = 0; i < inspectDirInfo.GetFiles().Length; i++)
                files += inspectDirInfo.GetFiles()[i].Name + "; ";          /// имена всех файлов записываем в строку

            string directories = "";
            for (int i = 0; i < inspectDirInfo.GetDirectories().Length; i++)
                directories += inspectDirInfo.GetDirectories()[i];          /// имена всех директориев

            if (inspectDirInfo.Exists)
                inspectLog = classLogInfo +
                             "\nФайлы:                    " + files +
                             "\nПоддиректории:            " + directories +
                             "\nРодительский директорий:  " + inspectDirInfo.Parent.Name +
                             "\n\n==========================================================================================================";


            PVGLog.WriteInLog(inspectLog);
        }

        public static void VADFiles()
        {
            string rootDrivePath = Path.GetFullPath(@"D:\ООП\LABA-12");
            string VADFilesPath = Path.GetFullPath(rootDrivePath + @"\PVGFiles");
            string VADInspectFilesPath = Path.GetFullPath(rootDrivePath + @"\PVGInspect\PVGFiles");
            string VADUnzipPath = Path.GetFullPath(rootDrivePath + @"\PVGInspect\PVGUnzip");
            string musicPath = Path.GetFullPath(rootDrivePath + @"\Music");
            string ZIPPath = Path.GetFullPath(rootDrivePath + @"\PVGInspect\PVGFiles.zip");


            DirectoryInfo VADFiles = new DirectoryInfo(VADFilesPath);                        /// создать PVGFIles
            DirectoryInfo VADInspectFiles = new DirectoryInfo(VADInspectFilesPath);          /// создать Inspect\Files
            DirectoryInfo VADUnzip = new DirectoryInfo(VADUnzipPath);

            if (!VADFiles.Exists)                                                            /// если нет папки Files,
                VADFiles.Create();                                                           /// то создаем ее, а хуле

            if (VADUnzip.Exists)
                VADUnzip.Delete(true);

            if (File.Exists(ZIPPath))
                File.Delete(ZIPPath);


            DirectoryInfo musicDirInfo = new DirectoryInfo(musicPath);                       /// путь к Music 
            FileInfo[] filesMusic = musicDirInfo.GetFiles();                                 /// получить все файлы из Music
            foreach (FileInfo file in filesMusic)
                if (file.Extension == ".mp3")
                    file.CopyTo(Path.Combine(VADFilesPath.ToString(), file.Name), true);     /// скопировать все .mp3 в PVGFiles

            if (VADInspectFiles.Exists)                                                      /// если есть Inspect\Files,
                VADInspectFiles.Delete(true);                                                /// то он нам нахуй не нужен
            if (VADFiles.Exists)
                VADFiles.MoveTo(VADInspectFilesPath);                                        /// перемещаем в Inspect\Files
        }

        public static void MakeArchive()
        {
            string lab13Path = Path.GetFullPath(@"D:\ООП\LABA-12\");
            string VADFilesPath = Path.GetFullPath(lab13Path + @"PVGFiles");
            string VADInspectFilesPath = Path.GetFullPath(lab13Path + @"PVGInspect\PVGFiles");
            string VADInspectUnzipPath = Path.GetFullPath(lab13Path + @"PVGInspect\PVGUnzip");
            string ZIPPath = Path.GetFullPath(lab13Path + @"PVGInspect\PVGFiles.zip");


            DirectoryInfo VADFiles = new DirectoryInfo(VADFilesPath);
            ZipFile.CreateFromDirectory(VADInspectFilesPath, ZIPPath);                      /// архивируем

            DirectoryInfo VADInspectFiles = new DirectoryInfo(VADInspectFilesPath);         /// если остался Inspect\Files,
            if (VADInspectFiles.Exists)                                                     /// то удаляем его
                VADInspectFiles.Delete(true);

            DirectoryInfo VADInspectUnzip = new DirectoryInfo(VADInspectUnzipPath);         /// создаем папку для разархивации,
            if (VADInspectUnzip.Exists)                                                     /// а если на существует,
                VADInspectUnzip.Delete(true);                                               /// то удаляем ее нахуй
            VADInspectUnzip.Create();

            using (ZipArchive archive = ZipFile.OpenRead(ZIPPath))                          
            {                                                                               
                var result = from currEntry in archive.Entries
                             where !String.IsNullOrEmpty(currEntry.Name)
                             select currEntry;
                foreach (ZipArchiveEntry entry in result)
                    entry.ExtractToFile(Path.Combine(VADInspectUnzipPath, entry.Name));    
            }


        }
    }
}