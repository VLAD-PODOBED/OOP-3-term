using System;
using System.IO;

namespace LABA12
{
    public static class PVGFileInfo
    {
        public static void GetFileInfo()
        {
            string path = Path.GetFullPath(@"D:\ООП\LABA-12\pvglog.txt");
            string classLogInfo = "\n=========================================   PVGFileInfo   ================================================\n";
            string fileInfoLog = "";

            FileInfo fileInfo = new FileInfo(path);

            if (fileInfo.Exists)
                fileInfoLog = classLogInfo +
                              "\nПолный путь:              " + path +
                              "\nИмя файла:                " + fileInfo.Name +
                              "\nРазмер файла:             " + fileInfo.Length + " KB" +
                              "\nРасширение:               " + fileInfo.Extension +
                              "\nДата изменения:           " + fileInfo.LastWriteTime;

            PVGLog.WriteInLog(fileInfoLog);
        }
    }
}